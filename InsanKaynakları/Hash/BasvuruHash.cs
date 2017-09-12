using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynakları.Hash;
using InsanKaynakları.Heap;

namespace InsanKaynakları.Hash
{
    public class BasvuruHash
    {
        public int TABLE_SIZE { get; set; }
        private BasvuruNode[] Basvurular;
        public BasvuruHash()
        {
            this.TABLE_SIZE = 1000;
            Basvurular = new BasvuruNode[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                Basvurular[i] = null;
        }
        public BasvuruHash(int size)
        {
            this.TABLE_SIZE = size;
            Basvurular = new BasvuruNode[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                Basvurular[i] = null;
        }

       //Anahtaragöre böyle bir şirket varmı yokmu ona bakılıyor.        
        public bool GetSirket(int key)
        {
            int hash = (key % TABLE_SIZE);
            while (Basvurular[hash] != null && Basvurular[hash].Anahtar != key)
                return false;

            return true;
        }

        //İlana başvuran aday bilgileri, başvurulan sirketin bilgilerini ve ilan no tutuluyor.
        public bool IlanBasvuru(int ilanNo, object aday,object sirket)
        {
            int hash = (ilanNo % TABLE_SIZE);
            //Hash tablosunda aynı key ile bir şirket varsa yeni şirketi bir basamak ileri atıyor yoksa boş yere yerleştiriyor.
            if (GetSirket(ilanNo)==true)
            {
                
                while (Basvurular[hash] != null && Basvurular[hash].IlanNo != ilanNo)
                    hash = (hash + 1) % TABLE_SIZE;
                Basvurular[hash] = new BasvuruNode(ilanNo, sirket, aday);
                return true;
            }
            else
            {
               return Basvurular[hash].BasvuranKisiler.Insert(aday);
            }
            
        }

        //Tüm hast tablosunu döndürüyor.
        public BasvuruNode[] AllGetBasvurular()
        {
            return Basvurular;
        }

        //Başvurusayısını döndüyor.
        public int[] BasvuruSayisi()
        {
            int[] BasvuranSayilari = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                BasvuranSayilari[i] = Basvurular[i].BasvuranKisiler.CurrentSize;
            }

            return BasvuranSayilari;
        }

        //Uygun Adayı Seç
        public string UygunKisiSec()
        {
           
            string UygunAdaylar = "";
            for (int i = 0; i < TABLE_SIZE; i++)
            {
                if (Basvurular[i]!=null)               
                UygunAdaylar += UygunKisileriYazdır(Basvurular[i].UygunKisiSec(),Basvurular[i]);
            }

            return UygunAdaylar;
        }

        private string UygunKisileriYazdır(BasvuranlarNode aday,BasvuruNode sirket)
        {
            string UygunAdaylar = "";         
            UygunAdaylar +="Aday Adı: "+ aday.KisiBilgileri.AdayBilgileri.Adi + " Aday İşe Uygunluk Değeri: " + aday.IseUygunluk+"Başvurulan Şirket: "+sirket.IsyeriBilgileri.SirketBilgileri.Adi+" Şirket İlan No:"+sirket.IlanNo+"\n";            
            return UygunAdaylar;
        }
       

    }
}
