using InsanKaynakları.BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.Heap
{
   public class BasvuranlarNode
    {
        public KisiNode KisiBilgileri { get; set; }

        public double IseUygunluk { get; set; }

        public BasvuranlarNode()
        {

        }
        public BasvuranlarNode(KisiNode kisi)
        {
            Random rastgele = new Random();
            
            KisiBilgileri = new KisiNode();
            this.KisiBilgileri = kisi;
            this.IseUygunluk = rastgele.Next(0, 10);
           
        }
    }
}
