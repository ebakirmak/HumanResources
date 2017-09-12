using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynakları.LinkedList;
using InsanKaynakları.BST;
namespace InsanKaynakları.BST
{
    public class KisiIkiliAramaAgaci
    {
        private KisiNode Kok { get; set; }
       
        public string dugumler;

        public string dilBilen;

        public string ortalamaYuksek;

        public KisiIkiliAramaAgaci()
        {

        }

        public KisiIkiliAramaAgaci(KisiNode kok)
        {
            this.Kok = kok;
        }

        private int elemanSayisi = 0;
      

        //Ağaca eleman ekleme
        public void Ekle(Aday aday,EgitimNode egitim,IsDeneyimiNode deneyim )
        {
            //Yeni eklenecek düğümün parent'ı
            KisiNode tempParent = new KisiNode();
            //Kökten başla ve ilerle
            KisiNode tempSearch = Kok;

           

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var, çık.
                if (aday.Adi == tempSearch.AdayBilgileri.Adi)
                    return;
                else if (String.Compare(aday.Adi, tempSearch.AdayBilgileri.Adi)<0)
                    tempSearch = tempSearch.Sol;
                else
                    tempSearch = tempSearch.Sag;
            }
            KisiNode eklenecek = new KisiNode(aday,egitim,deneyim);
            //Ağaç boş, köke ekle
            if (Kok == null)
                Kok = eklenecek;
       
            else if (String.Compare(aday.Adi, tempParent.AdayBilgileri.Adi) < 0)
                tempParent.Sol = eklenecek;
            else
                tempParent.Sag = eklenecek;
        }

        public void Ekle(KisiNode kisi)
        {
            //Yeni eklenecek düğümün parent'ı
            KisiNode tempParent = new KisiNode();
            //Kökten başla ve ilerle
            KisiNode tempSearch = Kok;



            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var, çık.
                if (kisi.AdayBilgileri.Adi == tempSearch.AdayBilgileri.Adi)
                    return;
                else if (String.Compare(kisi.AdayBilgileri.Adi, tempSearch.AdayBilgileri.Adi) < 0)
                    tempSearch = tempSearch.Sol;
                else
                    tempSearch = tempSearch.Sag;
            }
            KisiNode eklenecek = new KisiNode(kisi.AdayBilgileri);
            //Ağaç boş, köke ekle
            if (Kok == null)
                Kok = eklenecek;

            else if (String.Compare(kisi.AdayBilgileri.Adi, tempParent.AdayBilgileri.Adi) < 0)
                tempParent.Sol = eklenecek;
            else
                tempParent.Sag = eklenecek;
        }
        //Ağaçtan Eleman Silme-  Successor
        public bool Sil(string deger)
        {
            KisiNode current = Kok;
            KisiNode parent = Kok;
            bool issol = true;

            //Düğümü Bul
            while (current.AdayBilgileri.Adi.ToLower() != deger.ToLower())
            {
                parent = current;
                if (String.Compare(deger.ToLower(), current.AdayBilgileri.Adi.ToLower()) < 0)
                {
                    issol = true;
                    current = current.Sol;
                }
                else if (String.Compare(deger.ToLower(), current.AdayBilgileri.Adi.ToLower()) > 0)            
                {
                    issol = false;
                    current = current.Sag;
                }
                else
                {

                }
                if (current == null)
                {
                    return false;
                }
            }

            //Durum 1=>Yaprak Düğüm
            if (current.Sol == null && current.Sag == null)
            {
                if (current == Kok)
                {
                    Kok = null;
                }
                else if (issol)
                {
                    parent.Sol = null;
                }
                else
                {
                    parent.Sag = null;
                }
            }
            //Durum 2=>Tek Çocuklu Düğüm
            else if (current.Sag == null)
            {
                if (current == Kok)
                {
                    Kok = current.Sol;
                }
                else if (issol)
                {
                    parent.Sol = current.Sol;
                }
                else
                {
                    parent.Sag = current.Sol;
                }
            }
            else if (current.Sol == null)
            {
                if (current == Kok)
                {
                    Kok = current.Sag;
                }
                else if (issol)
                {
                    parent.Sol = current.Sag;
                }
                else
                {
                    parent.Sag = current.Sag;
                }
            }

            else
            {
                KisiNode successor = Successor(current);
                if (current == Kok)
                {
                    Kok = successor;
                }
                else if (issol)
                {
                    parent.Sol = successor;
                }
                else
                {
                    parent.Sag = successor;
                }
                successor.Sol = current.Sol;
            }
            return true;
        }
      
        private KisiNode Successor(KisiNode silDugum)
        {
            KisiNode successorParent = silDugum;
            KisiNode successor = silDugum;
            KisiNode current = silDugum.Sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Sol;
            }
            if (successor != silDugum.Sag)
            {
                successorParent.Sol = successor.Sag;
                successor.Sag = silDugum.Sag;
            }
            return successor;
        }

        //Kişi Bilgilerini Güncelleme
        public void Guncelle(string Adi, Aday aday, EgitimNode egitim, IsDeneyimiNode deneyim)
        {
            GuncelleStr(Kok, Adi, aday, egitim, deneyim);
        }

        private void GuncelleStr(KisiNode dugum, string Adi, Aday aday, EgitimNode egitim, IsDeneyimiNode deneyim)
        {
            if (dugum == null)
            {
                return;
            }
            else if (dugum.AdayBilgileri.Adi == Adi)
            {
                dugum.AdayBilgileri.Adres = aday.Adres;
                dugum.AdayBilgileri.DogumTarih = aday.DogumTarih;
                dugum.AdayBilgileri.DogumYeri = aday.DogumYeri;
                dugum.AdayBilgileri.E_Posta = aday.E_Posta;
                dugum.AdayBilgileri.IlgiAlanlari = aday.IlgiAlanlari;
                dugum.AdayBilgileri.MedeniDurum = aday.MedeniDurum;
                dugum.AdayBilgileri.Referans = aday.Referans;
                dugum.AdayBilgileri.Telefon = aday.Telefon;
                dugum.AdayBilgileri.Uyruk = aday.Uyruk;
                dugum.AdayBilgileri.YabanciDil = aday.YabanciDil;
                //eğitim ve deneyim bilgilerini güncellemek için linkedList'e methodlarını yaz...
            }
            else if (String.Compare(Adi, dugum.AdayBilgileri.Adi) < 0)
            {
                GuncelleStr(dugum.Sol, Adi, aday, egitim, deneyim);
            }
            else
            {
                GuncelleStr(dugum.Sag, Adi, aday, egitim, deneyim);
            }

        }


        //Ağaçta eleman arama
        public KisiNode AdaGoreAra(string Adi)
        {
            return AdaGoreAraInt(Kok, Adi);
        }

        private KisiNode AdaGoreAraInt(KisiNode dugum, string Adi)
        {
            if (dugum == null)
            {
                return null;
            }
            else if (dugum.AdayBilgileri.Adi == Adi)
            {
                return dugum;
            }
            else if (String.Compare((Adi.ToLower()),(dugum.AdayBilgileri.Adi.ToLower())) < 0)
            {
                return (AdaGoreAraInt(dugum.Sol, Adi));
            }
            else
            {
                return AdaGoreAraInt(dugum.Sag, Adi);
            }
         

        }

        //İngilizce Bilenleri Arama
        //Ağaçta eleman arama
        public string DileGoreAra()
        {
            return DileGoreAraInt(Kok);
        }

        private string DileGoreAraInt(KisiNode dugum)
        {
            KisiIkiliAramaAgaci ingilizceBilenler = new KisiIkiliAramaAgaci();
            if (dugum == null)
            {
                return null;
            }
            else if (dugum.AdayBilgileri.YabanciDil == "İngilizce")
            {
                ingilizceBilenler.Ekle(dugum);
                DilZiyaret(dugum);
            }
           
            DileGoreAraInt(dugum.Sol);
            DileGoreAraInt(dugum.Sag);


            return dilBilen;
        }    

        private void DilZiyaret(KisiNode kisi)
        {
            this.dilBilen+= "\nAdi: " + kisi.AdayBilgileri.Adi;
        }

        //Ortalaması 90'dan büyük olanları Arama
        //Ağaçta eleman arama
        public string OrtalamaGoreAra()
        {
            return OrtalamaGoreAraInt(Kok);
        }

        private string OrtalamaGoreAraInt(KisiNode dugum)
        {
            KisiIkiliAramaAgaci OrtalamasıYuksek = new KisiIkiliAramaAgaci();
            if (dugum == null)
            {
                return null;
            }
            else if (dugum.EgitimBilgileri.GetElementOrt(1)>=90 )
            {
                OrtalamasıYuksek.Ekle(dugum);
                OrtalamaZiyaret(dugum);
            }

            OrtalamaGoreAraInt(dugum.Sol);
            OrtalamaGoreAraInt(dugum.Sag);


            return ortalamaYuksek;
        }

        private void OrtalamaZiyaret(KisiNode kisi)
        {
            this.ortalamaYuksek += "\nAdi: " + kisi.AdayBilgileri.Adi;
        }

        //PreOrder, InOrder, PostOrder
        private void Ziyaret(KisiNode dugum)
        {
            dugumler += dugum.AdayBilgileri.Adi + "     ";
        }
        //PreOrder
        private void PreOrderInt(KisiNode dugum)
        {
            if (dugum == null) return;
            
            Ziyaret(dugum);
            PreOrderInt(dugum.Sol);
            PreOrderInt(dugum.Sag);
        }

        public void PreOrder()
        {
            dugumler = "\nPREORDER\n";
            
            PreOrderInt(Kok);
        }

        //InOrder
        private void InOrderInt(KisiNode dugum)
        {
            if (dugum == null) return;
            InOrderInt(dugum.Sol);
            Ziyaret(dugum);
            InOrderInt(dugum.Sag);
        }

        public void InOrder()
        {
            dugumler = "\nINORDER\n";
            PreOrderInt(Kok);
        }

        //PostOrder
        private void PostOrderInt(KisiNode dugum)
        {
            if (dugum == null) return;
            PostOrderInt(dugum.Sol);
            PostOrderInt(dugum.Sag);
            Ziyaret(dugum);
        }

        public void PostOrder()
        {
            dugumler = "\nPOSTOREDER\n";
            PostOrderInt(Kok);
        }

        //Kisileri Dön
        List<KisiNode> liste = new List<KisiNode>();

        private void KisilerZiyaret(KisiNode dugum)
        {
            liste.Add(dugum);

        }

        private void KisilerInt(KisiNode item)
        {

            if (item != null)
            {
                KisilerZiyaret(item);
                KisilerInt(item.Sol);
                KisilerInt(item.Sag);
            }




        }
      
        public List<KisiNode> Kisiler()
        {
            liste.Clear();
            KisilerInt(Kok);
            return liste;
        }
        //Ağacın eleman sayısını bulma
        private int ElemanSayisiInt(KisiNode kok)
        {
            if (kok == null)
                return elemanSayisi;

            elemanSayisi += 1;

            ElemanSayisiInt(kok.Sol);
            ElemanSayisiInt(kok.Sag);

            return elemanSayisi;
        }

        public int ElemanSayisi()
        {
            elemanSayisi = 0;
            return ElemanSayisiInt(Kok);
        }
    }
}
