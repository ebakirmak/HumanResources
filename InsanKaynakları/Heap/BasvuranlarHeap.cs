using InsanKaynakları.BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.Heap
{
    public class BasvuranlarHeap
    {
        private BasvuranlarNode[] heapArray;

        public int CurrentSize { get; set; }
              
        public int maxSize { get; set; }

        public string ZiyaretElemanlar { get; set; }

        public BasvuranlarHeap(int maxsize)
        {
            this.maxSize = maxsize;
            heapArray = new BasvuranlarNode[this.maxSize];
            this.CurrentSize = 0;

        }       

        //Heap Ağacına başvuran ekleme...
        public bool Insert(object aday)
        {
            if (CurrentSize == maxSize)
                return false;

            BasvuranlarNode newHeapDugum = new BasvuranlarNode((KisiNode)aday);
            if (BasvuranBul(newHeapDugum) == true)
                return false;           
            heapArray[CurrentSize] = newHeapDugum;
            MoveToUp(CurrentSize++);
            return true;
        }

        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            BasvuranlarNode bottom = heapArray[index];
          
            while (index > 0 && heapArray[parent].IseUygunluk < bottom.IseUygunluk )
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }       

        //Bir ilana bir kişi bir sefer başvurabilir.
        private  bool  BasvuranBul(BasvuranlarNode aday)
        {
            for (int m = 0; m < CurrentSize; m++)
            {
                if (heapArray[m].KisiBilgileri.AdayBilgileri.Adi != aday.KisiBilgileri.AdayBilgileri.Adi) { }
                else
                    return true;
            }
            return false;
        }

        //İlana başvuranların hepsini döndürr...
        public BasvuranlarNode[] GetAllBasvuranlar()
        {
            return heapArray;
        }

        //En uygun adayı işe alma (Bu kişi Heap’ten çekilecektir)
        public BasvuranlarNode UygunKisiSec()
        {
           
            BasvuranlarNode aday = heapArray[0];
            
            return aday;

        }

        
    }
}
