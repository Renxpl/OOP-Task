using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace WindowsFormsApp4
{
    public class DosyaYonetim
    {
       
        static List<string> dosyalar = new List<string>
        {
            "Çalışanlar",
            "Tarih",
            "Saat",
            "Hizmet",
            "Hizmet Türü",
            "Müşteri Adları",
            "Müşteri Soyadları",
            "Müşteri Telefonları"
        };
        static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        public DosyaYonetim() 
        {
         
        }


        //dosya yoksa yaratma varsa açma ve içini okuyup dağıtma

        static public void OpenFile(List<string> a, int k)
        {
            string filePath = Path.Combine(documentsPath, dosyalar[k]);
            if (!File.Exists(filePath))
            {
                // Dosya yoksa oluştur
                using (StreamWriter sw = File.CreateText(filePath))
                {
                }
            }

            // Dosyayı oku
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    a.Add(s);
                }

            }

            

        }





        //kapatırken ise (veya kaydederken) ögeleri txt dosyalara aktarmalı

        static public void CloseFile(List<string> a, int k) 
        {


            string filePath = Path.Combine(documentsPath, dosyalar[k]);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string line in a)
                {
                    sw.WriteLine(line);
                }
            }

        }





    }





}
