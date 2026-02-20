using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeOtomasyon.Models
{
    public class Siparis
    {
        public int ID { get; set; }
        public int MasaID { get; set; }
        public DateTime Tarih { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool Durum { get; set; }
    }
}
