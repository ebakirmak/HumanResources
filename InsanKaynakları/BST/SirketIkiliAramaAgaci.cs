using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.BST
{
    public class SirketIkiliAramaAgaci
    {
        private SirketNode Kok { get; set; }

        public string dugumler;

        public SirketIkiliAramaAgaci()
        {

        }     

        public SirketIkiliAramaAgaci(SirketNode kok)
        {
            this.Kok = kok;
        }

        //Ağaca eleman ekleme
        public bool Ekle(Sirket sirket,IsIlani ilan)
        {
            //Yeni eklenecek düğümün parent'ı
            SirketNode tempParent = new SirketNode();
            //Kökten başla ve ilerle
            SirketNode tempSearch = Kok;



            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var, çık.
                if (sirket.Adi == tempSearch.SirketBilgileri.Adi)
                {
                    tempSearch.YeniIsIlaniEkle(ilan);
                    return true;
                }
                else if (String.Compare(sirket.Adi, tempSearch.SirketBilgileri.Adi) < 0)
                    tempSearch = tempSearch.Sol;
                else if (String.Compare(sirket.Adi, tempSearch.SirketBilgileri.Adi) > 0)
                {
                    tempSearch = tempSearch.Sag;
                }
                
            }
            SirketNode eklenecek = new SirketNode(sirket,ilan);
            //Ağaç boş, köke ekle
            if (Kok == null)
            { Kok = eklenecek; return true; }
            else if (String.Compare(sirket.Adi, tempParent.SirketBilgileri.Adi) < 0)
            { tempParent.Sol = eklenecek; return true; }
            else
            { tempParent.Sag = eklenecek; return true; }
        }

        //Ağaçtan Eleman Silme
        public bool Sil(string deger)
        {
            SirketNode current = Kok;
            SirketNode parent = Kok;
            bool issol = true;

            //Düğümü Bul
            while (current.SirketBilgileri.Adi.ToLower() != deger.ToLower())
            {
                parent = current;
                if (String.Compare(deger.ToLower(), current.SirketBilgileri.Adi.ToLower()) < 0)
                {
                    issol = true;
                    current = current.Sol;
                }
                else if (String.Compare(deger.ToLower(), current.SirketBilgileri.Adi.ToLower()) > 0)
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
                SirketNode successor = Successor(current);
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

        //Ağaçta eleman arama
        public SirketNode Ara(string Adi)
        {
            return AraInt(Kok, Adi);
        }

        private SirketNode AraInt(SirketNode dugum, string Adi)
        {
            if (dugum == null)
            {
                return null;
            }
            else if (dugum.SirketBilgileri.Adi == Adi)
            {
                return dugum;
            }
            else if (String.Compare(Adi, dugum.SirketBilgileri.Adi) < 0)
            {
                return (AraInt(dugum.Sol, Adi));
            }
            else
            {
                return AraInt(dugum.Sag, Adi);
            }


        }


        //Kişi Bilgilerini Güncelleme
        public void Guncelle(string Adi, Sirket sirket)
        {
            GuncelleStr(Kok, Adi, sirket);
        }

        private void GuncelleStr(SirketNode dugum, string Adi, Sirket sirket)
        {
            if (dugum == null)
            {
                return;
            }
            else if (dugum.SirketBilgileri.Adi == Adi)
            {
                dugum.SirketBilgileri.Adres = sirket.Adres;
                dugum.SirketBilgileri.Eposta = sirket.Eposta;
                dugum.SirketBilgileri.Faks = sirket.Faks;
                dugum.SirketBilgileri.Telefon = sirket.Telefon;
                
                //eğitim ve deneyim bilgilerini güncellemek için linkedList'e methodlarını yaz...
            }
            else if (String.Compare(Adi, dugum.SirketBilgileri.Adi) < 0)
            {
                GuncelleStr(dugum.Sol, Adi, sirket);
            }
            else
            {
                GuncelleStr(dugum.Sag, Adi, sirket);
            }

        }

        public void IlanGuncelle(string Adi, Sirket sirket)
        {
            IlanGuncelleStr(Kok, Adi, sirket);
        }

        private void IlanGuncelleStr(SirketNode dugum, string Adi, Sirket sirket)
        {
            if (dugum == null)
            {
                return;
            }
            else if (dugum.SirketBilgileri.Adi == Adi)
            {
                dugum.SirketBilgileri.Adres = sirket.Adres;
                dugum.SirketBilgileri.Eposta = sirket.Eposta;
                dugum.SirketBilgileri.Faks = sirket.Faks;
                dugum.SirketBilgileri.Telefon = sirket.Telefon;

                //eğitim ve deneyim bilgilerini güncellemek için linkedList'e methodlarını yaz...
            }
            else if (String.Compare(Adi, dugum.SirketBilgileri.Adi) < 0)
            {
                IlanGuncelleStr(dugum.Sol, Adi, sirket);
            }
            else
            {
                IlanGuncelleStr(dugum.Sag, Adi, sirket);
            }

        }

        //Successor
        private SirketNode Successor(SirketNode silDugum)
        {
            SirketNode successorParent = silDugum;
            SirketNode successor = silDugum;
            SirketNode current = silDugum.Sag;
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
        
        //İş İlanlarını Dön
        List<SirketNode> liste = new List<SirketNode>();

        private void IlanlarZiyaret(SirketNode dugum)
        {
            liste.Add(dugum);
          
        }

        private  void IsIlanlariInt(SirketNode item)
        {

            if (item!=null)
            {
                IsIlanlariInt(item.Sol);
                IlanlarZiyaret(item);
                IsIlanlariInt(item.Sag);
            }
          
               

            
        }

        public List<SirketNode> IsIlanlari()
        {
            IsIlanlariInt(Kok);
            return liste;
        }
    }
}
