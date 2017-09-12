using InsanKaynakları.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.BST
{
    public class SirketNode
    {
        public Sirket SirketBilgileri { get; set; }
        public IsIlani[] IsIlanlari { get; set; }
        public SirketNode Sol { get; set; }
        public SirketNode Sag { get; set; }

        public int Size =0;
        public SirketNode()
        {

        }


        public SirketNode(Sirket sirketBilgileri,IsIlani isIlan)
        {
            this.SirketBilgileri = sirketBilgileri;
            IsIlanlari = new IsIlani[1000];
            this.IsIlanlari[Size++] = isIlan;
            this.Sol = null;
            this.Sag = null;
        }

        public int GetIlanIndis(int ilanNo)
        {
            for (int i = 0; i < Size; i++)
            {
                if (IsIlanlari[i].IlanNo==ilanNo)
                {
                    return i;
                }
            }
            return -1;
        }

        public void YeniIsIlaniEkle(IsIlani ilan)
        {
            this.IsIlanlari[Size++] = ilan;
        }
        
    
}
}
