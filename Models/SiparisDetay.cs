using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeOtomasyon.Models
{
     public class SiparisDetay
    {
        public int ID { get; set; }
        public int SiparisID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }

        public string UrunAd { get; set; }
    }
}
