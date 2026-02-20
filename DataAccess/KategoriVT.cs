using KafeOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeOtomasyon.DataAccess
{
    public class KategoriVT
    {
        public List<Kategori> Listeler()
        {
            List<Kategori> ktg = new List<Kategori>();
            KafeVT kf = new KafeVT();

            SqlCommand komut = new SqlCommand("SELECT * FROM Kategoriler", kf.BaglantiAl());
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                Kategori k = new Kategori();
                k.ID = Convert.ToInt32(reader["ID"]);
                k.KategoriAd = reader["KategoriAd"].ToString();
                ktg.Add(k); // Hazırladığın listeye eklemeyi unutmuyoruz
            }

            reader.Close();
            kf.BaglantiAl().Close(); // Kapıyı kapatmayı unutmuyoruz
            return ktg;
        }
    }
}
