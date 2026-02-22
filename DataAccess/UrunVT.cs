using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KafeOtomasyon.Models; 

namespace KafeOtomasyon.DataAccess
{
    public class UrunVT
    {
        public List<Urun> Listeler()
        {
            List<Urun> un = new List<Urun>();
            KafeVT kf = new KafeVT();

            string sorgu = "SELECT u.*, k.KategoriAd FROM Urunler u JOIN Kategoriler k ON u.KategoriID = k.ID";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Urun u = new Urun();
                u.ID = Convert.ToInt32(reader["ID"]); 
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