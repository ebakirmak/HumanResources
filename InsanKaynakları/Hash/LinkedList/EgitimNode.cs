using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.LinkedList
{
    public class EgitimNode
    {
        //Eğitim Durumu yani mezun olduğu okulların bilgileri(okul adı, bölümü, başlangıç ve bitiş tarihleri yıl olarak, not ortalaması) bağlı listede tutulacaktır.
        public string OkulAdi { get; set; }
        public string Bolum { get; set; }
        public int BaslangicTarih { get; set; }
        public int BitisTarih { get; set; }
        public double Not { get; set; }
        public EgitimNode Next { get; set; }
    }
}
