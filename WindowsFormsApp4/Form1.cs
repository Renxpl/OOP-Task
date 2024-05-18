using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        /*
         * 0"Çalışanlar",
           1"Tarih",
           2"Saat",
           3"Hizmet",
           4"Hizmet Türü",
           5"Müşteri Adları",
           6"Müşteri Soyadları",
           7"Müşteri Telefonları"
         * 
         * 
         */
        SeriliazableDictionary_3Item<string, string,string> hizmetBilgileri = new SeriliazableDictionary_3Item<string, string, string>();
        SeriliazableDictionary_3Item<string, string, string> calisanVeZaman = new SeriliazableDictionary_3Item<string, string, string>();
        SeriliazableDictionary_3Item<string, string, string> musteriBilgileri = new SeriliazableDictionary_3Item<string, string, string>();
        int randevuIndex = -1;
        public Form1()
        {
            InitializeComponent();
            islemTuru.Items.Add("Randevu Ekle");
            islemTuru.Items.Add("Randevu Düzenle");
            CalisanEkleme();
            HizmetTuruComboBoxEkleme();
            EklemeyinceKapatilacaklar();
            OpenControl();
            randevuKontrol.Items.Clear();
        }

        void RandevuOlustur()
        { 
            hizmetBilgileri.Add(dateTimePicker1.Value.ToString(), Tuple.Create((string)hizmet.SelectedItem, (string)hizmetTuru.SelectedItem));
            calisanVeZaman.Add(dateTimePicker1.Value.ToString(), Tuple.Create((string)calisanlar.SelectedItem, (string)saatler.SelectedItem));
            musteriBilgileri.Add(telefon.Text, Tuple.Create(soyad.Text, isim.Text));
            EklemeyinceKapatilacaklar();
        }
        void RandevuOlustur(int index)
        {
            hizmetBilgileri.OnBeforeSerialize();
            hizmetBilgileri.keys[index] = dateTimePicker1.Value.ToString();
            hizmetBilgileri.values1[index] = (string)hizmet.SelectedItem;
            hizmetBilgileri.values2[index] = (string)hizmetTuru.SelectedItem;
            hizmetBilgileri.OnAfterDeserialize();

            calisanVeZaman.OnBeforeSerialize();
            calisanVeZaman.keys[index] = dateTimePicker1.Value.ToString();
            calisanVeZaman.values1[index] = (string)calisanlar.SelectedItem;
            calisanVeZaman.values2[index] = (string)saatler.SelectedItem;
            calisanVeZaman.OnAfterDeserialize();

            musteriBilgileri.OnBeforeSerialize();
            musteriBilgileri.keys[index] = telefon.Text;
            musteriBilgileri.values1[index] = soyad.Text;
            musteriBilgileri.values2[index] = isim.Text;
            musteriBilgileri.OnAfterDeserialize();

            EklemeyinceKapatilacaklar();
        }

        void OpenControl()
        {
            DosyaYonetim.OpenFile(hizmetBilgileri.keys, 1);  DosyaYonetim.OpenFile(hizmetBilgileri.values1, 3); DosyaYonetim.OpenFile(hizmetBilgileri.values2, 4); 
            DosyaYonetim.OpenFile(calisanVeZaman.keys, 1); DosyaYonetim.OpenFile(calisanVeZaman.values1, 0); DosyaYonetim.OpenFile(calisanVeZaman.values2, 2);
            DosyaYonetim.OpenFile(musteriBilgileri.keys, 7); DosyaYonetim.OpenFile(musteriBilgileri.values1, 6); DosyaYonetim.OpenFile(musteriBilgileri.values2, 5);
            hizmetBilgileri.OnAfterDeserialize();
            calisanVeZaman.OnAfterDeserialize();
            musteriBilgileri.OnAfterDeserialize();
        }

        void CloseControl()
        {
            hizmetBilgileri.OnBeforeSerialize();
            calisanVeZaman.OnBeforeSerialize();
            musteriBilgileri.OnBeforeSerialize();
            DosyaYonetim.CloseFile(hizmetBilgileri.values1, 3); DosyaYonetim.CloseFile(hizmetBilgileri.values2, 4);
            DosyaYonetim.CloseFile(calisanVeZaman.keys, 1); DosyaYonetim.CloseFile(calisanVeZaman.values1, 0); DosyaYonetim.CloseFile(calisanVeZaman.values2, 2);
            DosyaYonetim.CloseFile(musteriBilgileri.keys, 7); DosyaYonetim.CloseFile(musteriBilgileri.values1, 6); DosyaYonetim.CloseFile(musteriBilgileri.values2, 5);
           
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (islemTuru.SelectedItem == null) return;

            if ((string)islemTuru.SelectedItem == "Randevu Ekle")
            {
                hizmetTuru.Visible = true;
                hizmetTuruLabel.Visible = true;
                ekleButonu.Text = "Randevu Ekle";
            }

            else { EklemeyinceKapatilacaklar(); }

            if ((string)islemTuru.SelectedItem == "Randevu Düzenle")
            {
                randevuKontrol.Visible = true;
                silButon.Visible = true;
                duzeltButon.Visible = true;
                ekleButonu.Text = "Randevu Düzenle";
                RandevuYazdir();

            }
            else { randevuKontrol.Visible = false; silButon.Visible = false; duzeltButon.Visible = false; ekleButonu.Text = "Randevu Ekle"; }

        }
        void RandevuYazdir()
        {
            hizmetBilgileri.OnBeforeSerialize();
            calisanVeZaman.OnBeforeSerialize();
            musteriBilgileri.OnBeforeSerialize();
            randevuKontrol.Items.Clear();
            for (int i = 0; i < musteriBilgileri.Count; i++)
            {
                
                randevuKontrol.Items.Add(musteriBilgileri.values2[i] + " " + musteriBilgileri.values1[i] +"  "+ TarihDon(calisanVeZaman.keys[i]) + "  " + calisanVeZaman.values2[i]);
            }
        }

        //telefon numarası iin error yazdır

        string TarihDon(string tarih)
        {
            int nextChar;
            string result = "";

            
            for (int i = 0; (nextChar = tarih[i]) != -1; i++){
                char c = (char)nextChar;
                if (c == ' ')
                {
                    break; 
                }
                result += c;
            }
            return result;

        }

        private void hizmetTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hizmetTuru.SelectedItem == null) return;

            if ((string)hizmetTuru.SelectedItem == "Cilt Bakımı")
            {
                hizmet.Visible = true;
                hizmetLabel.Visible = true;
                HizmetCiltBakımıEkleme();
                calisanlar.Visible= true;
                calisanlarLabel.Visible = true;
                dateTimePicker1.Visible= true;
            }

            else if ((string)hizmetTuru.SelectedItem == "Masaj")
            {
                hizmet.Visible = true;
                hizmetLabel.Visible = true;
                HizmetMasajEkleme();
                calisanlar.Visible = true;
                calisanlarLabel.Visible = true;
                dateTimePicker1.Visible = true;
            }

            else if ((string)hizmetTuru.SelectedItem == "Saç Bakımı ve Stil")
            {
                hizmet.Visible = true;
                hizmetLabel.Visible = true;
                HizmetSacBakımıEkleme();
                calisanlar.Visible = true;
                calisanlarLabel.Visible = true;
                dateTimePicker1.Visible = true;
            }

            else if ((string)hizmetTuru.SelectedItem== "Epilasyon ve Ağda")
            {
                hizmet.Visible = true;
                hizmetLabel.Visible = true;
                HizmetEpilasyonEkleme();
                calisanlar.Visible = true;
                calisanlarLabel.Visible = true;
                dateTimePicker1.Visible = true;
            }

            else if ((string)hizmetTuru.SelectedItem == "Vücut Bakımı")
            {
                hizmet.Visible = true;
                hizmetLabel.Visible = true;
                HizmetVucutBakımıEkleme();
                calisanlar.Visible = true;
                calisanlarLabel.Visible = true;
                dateTimePicker1.Visible = true;
            }

            else { hizmet.Visible = false; hizmetLabel.Visible = false; calisanlar.Visible = false; dateTimePicker1.Visible = false; calisanlarLabel.Visible = false; saatler.Visible = false; saatlerLabel.Visible = false; ekleButonu.Visible = false; SonEklenenleriCikar(); }
            



        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        void EklemeyinceKapatilacaklar()
        {
            hizmetTuru.Visible = false;
            hizmet.Visible = false;
            calisanlar.Visible = false;
            randevuKontrol.Visible = false;
            hizmetTuruLabel.Visible= false;
            hizmetLabel.Visible=false;
            saatler.Visible=false;
            saatlerLabel.Visible=false;
            dateTimePicker1.Visible=false;
            calisanlarLabel.Visible=false;
            silButon.Visible = false; 
            duzeltButon.Visible = false;
            SonEklenenleriCikar();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.Date <= DateTime.Now.Date)
            {

                MessageBox.Show("Geçersiz Tarih Seçimi Yaptınız. Lütfen Başka Bir Tarih Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dateTimePicker1.Value = DateTime.Now.Date;
                saatler.Visible= false; saatlerLabel.Visible= false;
                SonEklenenleriCikar();
            }
            else
            {
                saatlerLabel.Visible=true;  
                saatler.Visible = true;
                RandevuSaatleriniEkle();
            }


        }
        void HizmetTuruComboBoxEkleme()
        {

            hizmetTuru.Items.Add("Cilt Bakımı");
            hizmetTuru.Items.Add("Masaj");
            hizmetTuru.Items.Add("Saç Bakımı ve Stil");
            hizmetTuru.Items.Add("Epilasyon ve Ağda");
            hizmetTuru.Items.Add("Vücut Bakımı");

        }
        void HizmetCiltBakımıEkleme()
        {
            hizmet.Items.Clear();
            hizmet.Items.Add("Temel Cilt Bakımı: 300-500 TL");
            hizmet.Items.Add("Anti-Aging Cilt Bakımı: 500-800 TL");
            hizmet.Items.Add("Akne Tedavisi: 400-600 TL");
            hizmet.Items.Add("Nemlendirme ve Besleyici Bakım: 350-550 TL");

        }
        void HizmetMasajEkleme()
        {
            hizmet.Items.Clear();
            hizmet.Items.Add("Klasik Masaj: 200-400 TL");
            hizmet.Items.Add("Aromaterapi Masajı: 300-500 TL");
            hizmet.Items.Add("Derin Doku Masajı: 350-600 TL");
            hizmet.Items.Add("Sıcak Taş Masajı: 400-700 TL");

        }

        void HizmetSacBakımıEkleme()
        {
            hizmet.Items.Clear();
            hizmet.Items.Add("Saç Kesimi: 100-200 TL");
            hizmet.Items.Add("Saç Boyama: 300-600 TL");
            hizmet.Items.Add("Saç Bakımı ve Maske: 200-400 TL");
            hizmet.Items.Add("Fön ve Şekillendirme: 150-300 TL");

        }
        void HizmetEpilasyonEkleme()
        {
            hizmet.Items.Clear();
            hizmet.Items.Add("Lazer Epilasyon (Bölgesel): 400-800 TL");
            hizmet.Items.Add("Sir Ağda (Bölgesel): 100-200 TL");

        }
        void HizmetVucutBakımıEkleme()
        {
            hizmet.Items.Clear();
            hizmet.Items.Add("Selülit Tedavisi: 300-600 TL");
            hizmet.Items.Add("Vücut Peeling ve Nemlendirme: 350-550 TL");
            hizmet.Items.Add("İnfrared Terapi: 400-700 TL");

        }


        void CalisanEkleme()
        {
            calisanlar.Items.Add("Ayşe Yılmaz");
            calisanlar.Items.Add("Fatma Demir");
            calisanlar.Items.Add("Elif Kaya");
            calisanlar.Items.Add("Zeynep Çelik");
            calisanlar.Items.Add("Merve Şahin");
            calisanlar.Items.Add("Derya Aydın");
            calisanlar.Items.Add("Esra Özkan");
            calisanlar.Items.Add("Buse Arslan");
            calisanlar.Items.Add("Yasemin Karaca");
            calisanlar.Items.Add("Aslı Akın");

        }


        private void calisanlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saatler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ekleButonu.Visible = true; 
            isim.Visible = true;
            soyad.Visible = true;
            telefon.Visible = true;
            isimLabel.Visible = true;
            soyadLabel.Visible = true;
            telefonLabel.Visible = true;
            musteriLabel.Visible = true;
        }

        void RandevuSaatleriniEkle()
        {
            calisanVeZaman.OnBeforeSerialize();

            if (TarihSorustur())
            {
                if (!calisanVeZaman.values2.Contains("8.00-9.00") && !saatler.Items.Contains("8.00-9.00")) { saatler.Items.Add("8.00-9.00"); }
                if (!calisanVeZaman.values2.Contains("9.00-10.00") && !saatler.Items.Contains("9.00-10.00")) { saatler.Items.Add("9.00-10.00"); }
                if (!calisanVeZaman.values2.Contains("10.00-11.00") && !saatler.Items.Contains("10.00-11.00")) { saatler.Items.Add("10.00-11.00"); }
                if (!calisanVeZaman.values2.Contains("11.00-12.00") && !saatler.Items.Contains("11.00-12.00")) { saatler.Items.Add("11.00-12.00"); }
                if (!calisanVeZaman.values2.Contains("12.00-13.00") && !saatler.Items.Contains("12.00-13.00")) { saatler.Items.Add("12.00-13.00"); }
                if (!calisanVeZaman.values2.Contains("13.00-14.00") && !saatler.Items.Contains("13.00-14.00")) { saatler.Items.Add("13.00-14.00"); }
                if (!calisanVeZaman.values2.Contains("14.00-15.00") && !saatler.Items.Contains("14.00-15.00")) { saatler.Items.Add("14.00-15.00"); }
                if (!calisanVeZaman.values2.Contains("15.00-16.00") && !saatler.Items.Contains("15.00-16.00")) { saatler.Items.Add("15.00-16.00"); }
                if (!calisanVeZaman.values2.Contains("16.00-17.00") && !saatler.Items.Contains("16.00-17.00")) { saatler.Items.Add("16.00-17.00"); }


            }

            else
            {
                if (!saatler.Items.Contains("8.00-9.00")) saatler.Items.Add("8.00-9.00");
                if (!saatler.Items.Contains("9.00-10.00")) saatler.Items.Add("9.00-10.00");
                if (!saatler.Items.Contains("10.00-11.00")) saatler.Items.Add("10.00-11.00");
                if (!saatler.Items.Contains("11.00-12.00")) saatler.Items.Add("11.00-12.00");
                if (!saatler.Items.Contains("12.00-13.00")) saatler.Items.Add("12.00-13.00");
                if (!saatler.Items.Contains("13.00-14.00")) saatler.Items.Add("13.00-14.00");
                if (!saatler.Items.Contains("14.00-15.00")) saatler.Items.Add("14.00-15.00");
                if (!saatler.Items.Contains("15.00-16.00")) saatler.Items.Add("15.00-16.00");
                if (!saatler.Items.Contains("16.00-17.00")) saatler.Items.Add("16.00-17.00");
            }

        }
        

        private void ekleButonu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(isim.Text) || string.IsNullOrWhiteSpace(soyad.Text)|| string.IsNullOrWhiteSpace(telefon.Text))
            {

                MessageBox.Show("Müşteri Bilgileri Alanları Boş Geçilemez. Lütfen uygun değerleri girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                musteriBilgileri.OnBeforeSerialize();

                if (ekleButonu.Text == "Randevu Düzenle") { RandevuOlustur(randevuIndex); }

                else if (musteriBilgileri.keys.Contains(telefon.Text))
                {
                    MessageBox.Show("Kayıtta olan bi telefon numarası girdiniz. Farklı bir numara giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SonEklenenleriCikar();
                }
                else if (ekleButonu.Text == "Randevu Ekle") RandevuOlustur();
                
                
               
            }
        }


        void SonEklenenleriCikar()
        {
            ekleButonu.Visible = false;
            isim.Visible = false;
            soyad.Visible = false;
            telefon.Visible = false;
            isimLabel.Visible = false;
            soyadLabel.Visible = false;
            telefonLabel.Visible = false;
            musteriLabel.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseControl();

        }

        private void randevuKontrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void duzeltButon_Click(object sender, EventArgs e)
        {
            if (randevuKontrol.SelectedItem == null) return;
            randevuIndex = randevuKontrol.SelectedIndex;
            duzeltButon.Visible= false;
            silButon.Visible=false;
            RandevuDuzeltme();
        }

        void RandevuDuzeltme()
        {
            randevuKontrol.Visible = false;
            hizmetTuru.Visible = true;
            hizmetTuruLabel.Visible = true;


        }

        private void silButon_Click(object sender, EventArgs e)
        {
            int index = randevuKontrol.SelectedIndex;
            //sil
            hizmetBilgileri.OnBeforeSerialize();
            hizmetBilgileri.keys.RemoveAt(index);
            hizmetBilgileri.values1.RemoveAt(index);
            hizmetBilgileri.values2.RemoveAt(index);
            hizmetBilgileri.OnAfterDeserialize();

            calisanVeZaman.OnBeforeSerialize();
            calisanVeZaman.keys.RemoveAt(index);
            calisanVeZaman.values1.RemoveAt(index);
            calisanVeZaman.values2.RemoveAt(index);
            calisanVeZaman.OnAfterDeserialize();

            musteriBilgileri.OnBeforeSerialize();
            musteriBilgileri.keys.RemoveAt(index);
            musteriBilgileri.values1.RemoveAt(index);
            musteriBilgileri.values2.RemoveAt(index);
            musteriBilgileri.OnAfterDeserialize();


            //yazdır
            RandevuYazdir();
        }

        bool TarihSorustur()
        {
            
            for(int i = 0; i < calisanVeZaman.keys.Count; i++)
            {

                if (TarihDon(dateTimePicker1.Value.ToString()) == TarihDon(calisanVeZaman.keys[i])){ return true; }

            }

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
