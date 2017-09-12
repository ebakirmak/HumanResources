using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsanKaynakları.LinkedList;

namespace InsanKaynakları.BST
{
    public class KisiNode
    {
        public Aday AdayBilgileri { get; set; }
        public LinkedListEgitim EgitimBilgileri { get; set; }
        public LinkedListIsDeneyimi DeneyimBilgileri { get; set; }
        public KisiNode Sol { get; set; }
        public KisiNode Sag { get; set; }

        public KisiNode()
        {

        }
        public KisiNode(Aday aday)
        {
            AdayBilgileri = aday;
        }

        public KisiNode(Aday aday,EgitimNode egitim,IsDeneyimiNode deneyim)
        {
            AdayBilgileri = new Aday();
            this.AdayBilgileri = aday;

            this.EgitimBilgileri = new LinkedListEgitim();
            this.EgitimBilgileri.InsertLast(egitim);


            this.DeneyimBilgileri = new LinkedListIsDeneyimi();
            this.DeneyimBilgileri.InsertLast(deneyim);


            this.Sol = null;
            this.Sag = null;
        }
    }
}
