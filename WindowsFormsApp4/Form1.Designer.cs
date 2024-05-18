namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.islemTuru = new System.Windows.Forms.ComboBox();
            this.hizmetTuru = new System.Windows.Forms.ComboBox();
            this.islemTuruLabel = new System.Windows.Forms.Label();
            this.hizmetTuruLabel = new System.Windows.Forms.Label();
            this.hizmet = new System.Windows.Forms.ComboBox();
            this.hizmetLabel = new System.Windows.Forms.Label();
            this.calisanlar = new System.Windows.Forms.ComboBox();
            this.saatler = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.randevuKontrol = new System.Windows.Forms.ListBox();
            this.calisanlarLabel = new System.Windows.Forms.Label();
            this.saatlerLabel = new System.Windows.Forms.Label();
            this.ekleButonu = new System.Windows.Forms.Button();
            this.isim = new System.Windows.Forms.TextBox();
            this.soyad = new System.Windows.Forms.TextBox();
            this.telefon = new System.Windows.Forms.TextBox();
            this.musteriLabel = new System.Windows.Forms.Label();
            this.isimLabel = new System.Windows.Forms.Label();
            this.soyadLabel = new System.Windows.Forms.Label();
            this.telefonLabel = new System.Windows.Forms.Label();
            this.silButon = new System.Windows.Forms.Button();
            this.duzeltButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // islemTuru
            // 
            this.islemTuru.FormattingEnabled = true;
            this.islemTuru.Location = new System.Drawing.Point(71, 38);
            this.islemTuru.Name = "islemTuru";
            this.islemTuru.Size = new System.Drawing.Size(121, 21);
            this.islemTuru.TabIndex = 0;
            this.islemTuru.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // hizmetTuru
            // 
            this.hizmetTuru.FormattingEnabled = true;
            this.hizmetTuru.Location = new System.Drawing.Point(305, 38);
            this.hizmetTuru.Name = "hizmetTuru";
            this.hizmetTuru.Size = new System.Drawing.Size(121, 21);
            this.hizmetTuru.TabIndex = 1;
            this.hizmetTuru.SelectedIndexChanged += new System.EventHandler(this.hizmetTuru_SelectedIndexChanged);
            // 
            // islemTuruLabel
            // 
            this.islemTuruLabel.AutoSize = true;
            this.islemTuruLabel.Location = new System.Drawing.Point(103, 22);
            this.islemTuruLabel.Name = "islemTuruLabel";
            this.islemTuruLabel.Size = new System.Drawing.Size(56, 13);
            this.islemTuruLabel.TabIndex = 2;
            this.islemTuruLabel.Text = "İşlem Türü\r\n";
            // 
            // hizmetTuruLabel
            // 
            this.hizmetTuruLabel.AutoSize = true;
            this.hizmetTuruLabel.Location = new System.Drawing.Point(330, 22);
            this.hizmetTuruLabel.Name = "hizmetTuruLabel";
            this.hizmetTuruLabel.Size = new System.Drawing.Size(64, 13);
            this.hizmetTuruLabel.TabIndex = 3;
            this.hizmetTuruLabel.Text = "Hizmet Türü\r\n";
            // 
            // hizmet
            // 
            this.hizmet.FormattingEnabled = true;
            this.hizmet.Location = new System.Drawing.Point(520, 38);
            this.hizmet.Name = "hizmet";
            this.hizmet.Size = new System.Drawing.Size(206, 21);
            this.hizmet.TabIndex = 4;
            // 
            // hizmetLabel
            // 
            this.hizmetLabel.AutoSize = true;
            this.hizmetLabel.Location = new System.Drawing.Point(606, 22);
            this.hizmetLabel.Name = "hizmetLabel";
            this.hizmetLabel.Size = new System.Drawing.Size(39, 13);
            this.hizmetLabel.TabIndex = 5;
            this.hizmetLabel.Text = "Hizmet";
            // 
            // calisanlar
            // 
            this.calisanlar.FormattingEnabled = true;
            this.calisanlar.Location = new System.Drawing.Point(71, 118);
            this.calisanlar.Name = "calisanlar";
            this.calisanlar.Size = new System.Drawing.Size(121, 21);
            this.calisanlar.TabIndex = 6;
            this.calisanlar.SelectedIndexChanged += new System.EventHandler(this.calisanlar_SelectedIndexChanged);
            // 
            // saatler
            // 
            this.saatler.FormattingEnabled = true;
            this.saatler.Location = new System.Drawing.Point(530, 119);
            this.saatler.Name = "saatler";
            this.saatler.Size = new System.Drawing.Size(182, 21);
            this.saatler.TabIndex = 7;
            this.saatler.SelectedIndexChanged += new System.EventHandler(this.saatler_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(274, 119);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // randevuKontrol
            // 
            this.randevuKontrol.FormattingEnabled = true;
            this.randevuKontrol.Items.AddRange(new object[] {
            "item1",
            "item2"});
            this.randevuKontrol.Location = new System.Drawing.Point(71, 121);
            this.randevuKontrol.Name = "randevuKontrol";
            this.randevuKontrol.Size = new System.Drawing.Size(655, 264);
            this.randevuKontrol.TabIndex = 9;
            this.randevuKontrol.SelectedIndexChanged += new System.EventHandler(this.randevuKontrol_SelectedIndexChanged);
            // 
            // calisanlarLabel
            // 
            this.calisanlarLabel.AutoSize = true;
            this.calisanlarLabel.Location = new System.Drawing.Point(94, 103);
            this.calisanlarLabel.Name = "calisanlarLabel";
            this.calisanlarLabel.Size = new System.Drawing.Size(78, 13);
            this.calisanlarLabel.TabIndex = 10;
            this.calisanlarLabel.Text = "Çalışan Seçiniz";
            // 
            // saatlerLabel
            // 
            this.saatlerLabel.AutoSize = true;
            this.saatlerLabel.Location = new System.Drawing.Point(586, 103);
            this.saatlerLabel.Name = "saatlerLabel";
            this.saatlerLabel.Size = new System.Drawing.Size(78, 13);
            this.saatlerLabel.TabIndex = 11;
            this.saatlerLabel.Text = "Randevu Saati";
            // 
            // ekleButonu
            // 
            this.ekleButonu.Location = new System.Drawing.Point(467, 224);
            this.ekleButonu.Name = "ekleButonu";
            this.ekleButonu.Size = new System.Drawing.Size(103, 23);
            this.ekleButonu.TabIndex = 12;
            this.ekleButonu.Text = "Randevu Ekle";
            this.ekleButonu.UseVisualStyleBackColor = true;
            this.ekleButonu.Click += new System.EventHandler(this.ekleButonu_Click);
            // 
            // isim
            // 
            this.isim.Location = new System.Drawing.Point(208, 186);
            this.isim.Name = "isim";
            this.isim.Size = new System.Drawing.Size(151, 20);
            this.isim.TabIndex = 13;
            // 
            // soyad
            // 
            this.soyad.Location = new System.Drawing.Point(208, 224);
            this.soyad.Name = "soyad";
            this.soyad.Size = new System.Drawing.Size(151, 20);
            this.soyad.TabIndex = 14;
            // 
            // telefon
            // 
            this.telefon.Location = new System.Drawing.Point(208, 259);
            this.telefon.Name = "telefon";
            this.telefon.Size = new System.Drawing.Size(151, 20);
            this.telefon.TabIndex = 15;
            // 
            // musteriLabel
            // 
            this.musteriLabel.AutoSize = true;
            this.musteriLabel.Location = new System.Drawing.Point(246, 170);
            this.musteriLabel.Name = "musteriLabel";
            this.musteriLabel.Size = new System.Drawing.Size(76, 13);
            this.musteriLabel.TabIndex = 16;
            this.musteriLabel.Text = "Müşteri Bilgileri";
            // 
            // isimLabel
            // 
            this.isimLabel.AutoSize = true;
            this.isimLabel.Location = new System.Drawing.Point(179, 186);
            this.isimLabel.Name = "isimLabel";
            this.isimLabel.Size = new System.Drawing.Size(23, 13);
            this.isimLabel.TabIndex = 17;
            this.isimLabel.Text = "Ad:";
            // 
            // soyadLabel
            // 
            this.soyadLabel.AutoSize = true;
            this.soyadLabel.Location = new System.Drawing.Point(167, 224);
            this.soyadLabel.Name = "soyadLabel";
            this.soyadLabel.Size = new System.Drawing.Size(40, 13);
            this.soyadLabel.TabIndex = 18;
            this.soyadLabel.Text = "Soyad:";
            // 
            // telefonLabel
            // 
            this.telefonLabel.AutoSize = true;
            this.telefonLabel.Location = new System.Drawing.Point(161, 262);
            this.telefonLabel.Name = "telefonLabel";
            this.telefonLabel.Size = new System.Drawing.Size(46, 13);
            this.telefonLabel.TabIndex = 19;
            this.telefonLabel.Text = "Telefon:";
            // 
            // silButon
            // 
            this.silButon.Location = new System.Drawing.Point(520, 405);
            this.silButon.Name = "silButon";
            this.silButon.Size = new System.Drawing.Size(75, 23);
            this.silButon.TabIndex = 20;
            this.silButon.Text = "Sil";
            this.silButon.UseVisualStyleBackColor = true;
            this.silButon.Click += new System.EventHandler(this.silButon_Click);
            // 
            // duzeltButon
            // 
            this.duzeltButon.Location = new System.Drawing.Point(170, 405);
            this.duzeltButon.Name = "duzeltButon";
            this.duzeltButon.Size = new System.Drawing.Size(75, 23);
            this.duzeltButon.TabIndex = 21;
            this.duzeltButon.Text = "Düzenle";
            this.duzeltButon.UseVisualStyleBackColor = true;
            this.duzeltButon.Click += new System.EventHandler(this.duzeltButon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.duzeltButon);
            this.Controls.Add(this.silButon);
            this.Controls.Add(this.telefonLabel);
            this.Controls.Add(this.soyadLabel);
            this.Controls.Add(this.isimLabel);
            this.Controls.Add(this.musteriLabel);
            this.Controls.Add(this.telefon);
            this.Controls.Add(this.soyad);
            this.Controls.Add(this.isim);
            this.Controls.Add(this.ekleButonu);
            this.Controls.Add(this.saatlerLabel);
            this.Controls.Add(this.calisanlarLabel);
            this.Controls.Add(this.randevuKontrol);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.saatler);
            this.Controls.Add(this.calisanlar);
            this.Controls.Add(this.hizmetLabel);
            this.Controls.Add(this.hizmet);
            this.Controls.Add(this.hizmetTuruLabel);
            this.Controls.Add(this.islemTuruLabel);
            this.Controls.Add(this.hizmetTuru);
            this.Controls.Add(this.islemTuru);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox islemTuru;
        private System.Windows.Forms.ComboBox hizmetTuru;
        private System.Windows.Forms.Label islemTuruLabel;
        private System.Windows.Forms.Label hizmetTuruLabel;
        private System.Windows.Forms.ComboBox hizmet;
        private System.Windows.Forms.Label hizmetLabel;
        private System.Windows.Forms.ComboBox calisanlar;
        private System.Windows.Forms.ComboBox saatler;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox randevuKontrol;
        private System.Windows.Forms.Label calisanlarLabel;
        private System.Windows.Forms.Label saatlerLabel;
        private System.Windows.Forms.Button ekleButonu;
        private System.Windows.Forms.TextBox isim;
        private System.Windows.Forms.TextBox soyad;
        private System.Windows.Forms.TextBox telefon;
        private System.Windows.Forms.Label musteriLabel;
        private System.Windows.Forms.Label isimLabel;
        private System.Windows.Forms.Label soyadLabel;
        private System.Windows.Forms.Label telefonLabel;
        private System.Windows.Forms.Button silButon;
        private System.Windows.Forms.Button duzeltButon;
    }
}

