using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları
{
    public class IsIlani
    {
        public int IlanNo { get; set; }

        public string IsTanimi { get; set; }

        public string ArananOzellikler { get; set; }

        public int BasvuruSayi { get; set; }
        Random rastgele; 
        public IsIlani()
        {
           rastgele = new Random();
            this.IlanNo = rastgele.Next(0, 1000);
        }

    }
}
