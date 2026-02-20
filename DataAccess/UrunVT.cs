using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KafeOtomasyon.Models; // Models içindeki Urun sınıfına ulaşmak için şart

namespace KafeOtomasyon.DataAccess
{
    public class UrunVT
    {
        // Tüm ürünleri kategori isimleriyle birlikte getirir (JOIN Sorgusu)
        public List<Urun> Listeler()
        {
            List<Urun> un = new List<Urun>();
            KafeVT kf = new KafeVT();

            // Sorguda u.* ile tüm ürün bilgilerini, k.KategoriAd ile kategori ismini çekiyoruz
            string sorgu = "SELECT u.*, k.KategoriAd FROM Urunler u JOIN Kategoriler k ON u.KategoriID = k.ID";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Urun u = new Urun();
                u.ID = Convert.ToInt32(reader["ID"]); // Sütun adıyla çağırmak daha garantidir
                u.UrunAd = reader["UrunAd"].ToString();
                u.Fiyat = Convert.ToDecimal(reader["Fiyat"]);
                u.KategoriID = Convert.ToInt32(reader["KategoriID"]);
                u.KategoriAd = reader["KategoriAd"].ToString();
                un.Add(u);
            }
            reader.Close();
            kf.BaglantiAl().Close();
            return un;
        }

        // Sadece seçilen kategoriye ait ürünleri getirir (Filtreleme)
        public List<Urun> ListeleByKategori(int katID)
        {
            List<Urun> urunler = new List<Urun>();
            KafeVT kf = new KafeVT();

            string sorgu = "SELECT u.*, k.KategoriAd FROM Urunler u JOIN Kategoriler k ON u.KategoriID = k.ID WHERE u.KategoriID = @p1";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", katID);

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Urun u = new Urun();
                u.ID = Convert.ToInt32(reader["ID"]);
                u.UrunAd = reader["UrunAd"].ToString();
                u.Fiyat = Convert.ToDecimal(reader["Fiyat"]);
                u.KategoriID = Convert.ToInt32(reader["KategoriID"]);
                u.KategoriAd = reader["KategoriAd"].ToString();
                urunler.Add(u);
            }
            reader.Close();
            kf.BaglantiAl().Close();
            return urunler;
        }
    }
}