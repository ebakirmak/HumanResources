using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları
{
    public class OkumaYazma
    {
        static void DosyayaYaz()
        {
            //StreamWriter classından dosya isimli bir nesne oluşturalım
            StreamWriter dosya = new StreamWriter("c:\\eleman.txt");

            //Dosyamıza birinci satırı yazalım
            dosya.WriteLine("Metin dosyamızın ilk satırı");

            //Buda dosyamıza yazdığımız ikinci satır
            dosya.WriteLine("İkinci satır...");

            //Dosyamızın kapatılım..
            dosya.Close();

            //Yazma işlemini başarı ile tamamladığımızı kullanıcıya bildirelim..
            Console.WriteLine("Dosya yazımı Başarı ile tamamlandı...");

        }

        static void DosyadanOku(string dosyaIsmi)
        {
            // Text dosyasından okuyan StreamReader sınıfına ait bir 
            // dosyaOku nesnesini oluşturuyoruz
            StreamReader dosyaOku;

            // dosyadan okuyacağımız yazıyı string olarak depolamak için
            // yazı nesnemizi oluşturuyoruz.
            string yazi;

            //Dosyamızı okumak için açıyoruz..
            dosyaOku = File.OpenText(dosyaIsmi);

            //Dosyamızı okumak için açıyoruz ve ilk satırını okuyoruz..
            yazi = dosyaOku.ReadLine();

            /* okuduğumuz satırı ekrana bastırıp bir sonraki satıra geçiyoruz
           * Eğer sonraki satırda da yazı varsa onu da okuyup ekrana bastırıyoruz. 
           * Bu işlemleri dosyanın sonuna kadar devam ettiriyoruz.. */

            while (yazi != null)
            {
                Console.WriteLine(yazi);
                yazi = dosyaOku.ReadLine();
            }

            // dosyamızı kapatıyoruz..
            dosyaOku.Close();
        }

        static void DosyayaEkle(string dosyaIsmi)
        {
            //StreamWriter classından dosya isimli bir nesne oluşturalım
            StreamWriter dosya;

            // dosyamızın sonuna birşeyler eklememek için açıyoruz..
            dosya = File.AppendText(dosyaIsmi);

            // dosyanın sonuna birşey ekliyoruz..
            dosya.WriteLine("Bu da en son Append ile eklediğimiz satır...");

            // Dosyamızı kapatıyoruz..
            dosya.Close();

            Console.WriteLine("Dosyanın sonuna başarı ile ekledik...");
        }

    }
}
