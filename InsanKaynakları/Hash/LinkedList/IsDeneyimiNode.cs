using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.LinkedList
{
    public class IsDeneyimiNode
    {
        //Ayrıca her bir düğümde, o kişinin İş Deneyimi yani daha önce çalıştığı işyerlerinin bilgileri(adı, adresi, pozisyon veya görevi) bağlı listede tutulacaktır. 
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Pozisyon { get; set; }
        public string Gorev { get; set; }
        public IsDeneyimiNode Next { get; set; }



    }
}
