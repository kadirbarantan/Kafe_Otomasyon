using KafeOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeOtomasyon.Models
{
    public class Urun
    {
        public int ID { get; set; }
        public string UrunAd { get; set; }
        public decimal Fiyat { get; set; }
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
    }
}
