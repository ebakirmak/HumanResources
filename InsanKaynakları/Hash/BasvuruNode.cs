using InsanKaynakları.BST;
using InsanKaynakları.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.Hash
{
    //Hash Table’da işyeri bilgileri ve başvuru yapan kişiler, ilana göre (ilan numarası olabilir) bir Hash Table içerisinde tutulacaktır.
    //Hash Table‘da her bir iş ilanı için bir Heap(ağaç şeklindeki öncelik kuyruğu) tutulacaktır.
    public class BasvuruNode
    {
        private int anahtar;

        public int Anahtar
        {
            get { return anahtar; }
            set { anahtar = value; }
        }

        private int ilanNo;

        public int IlanNo
        {
            get { return ilanNo; }
            set { ilanNo = value; }
        }

        public BasvuruNode()
        {

        }

        public BasvuruNode(int ilanNo, object isyeriBilgileri, object adayBilgi)
        {
            this.IlanNo = (int)ilanNo;
            this.IsyeriBilgileri = (SirketNode)isyeriBilgileri;
            int indis = IsyeriBilgileri.GetIlanIndis(IlanNo);
            this.BasvuranKisiler = new BasvuranlarHeap(this.IsyeriBilgileri.IsIlanlari[indis].BasvuruSayi);
            this.BasvuranKisiler.Insert(adayBilgi);

        }

        private SirketNode isyeriBilgileri;

        public SirketNode IsyeriBilgileri
        {
            get { return isyeriBilgileri; }
            set { isyeriBilgileri = value; }
        }

        private BasvuranlarHeap basvuranKisiler;

        public BasvuranlarHeap BasvuranKisiler
        {
            get { return basvuranKisiler; }
            set { basvuranKisiler = value; }
        }

        public BasvuranlarNode UygunKisiSec()
        {
            return BasvuranKisiler.UygunKisiSec();
        }


    }
}
