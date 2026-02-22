using KafeOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KafeOtomasyon.DataAccess
{
    public class SiparisDetayVT
    {
        public void UrunEkle(SiparisDetay detay)
        {
            KafeVT kf = new KafeVT();
            string sorgu = "INSERT INTO SiparisDetay (SiparisID, UrunID, Adet, BirimFiyat) VALUES (@p1, @p2, @p3, @p4)";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());

            komut.Parameters.AddWithValue("@p1", detay.SiparisID);
            komut.Parameters.AddWithValue("@p2", detay.UrunID);
            komut.Parameters.AddWithValue("@p3", detay.Adet);
            komut.Parameters.AddWithValue("@p4", detay.BirimFiyat);

            komut.ExecuteNonQuery();
            kf.BaglantiAl().Close();
        }

        public List<SiparisDetay> DetaylariGetir(int siparisID)
        {
            List<SiparisDetay> liste = new List<SiparisDetay>();
            KafeVT kf = new KafeVT();

            string sorgu = "SELECT sd.*, u.UrunAd FROM SiparisDetay sd JOIN Urunler u ON sd.UrunID = u.ID WHERE sd.SiparisID = @p1";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", siparisID);

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                SiparisDetay d = new SiparisDetay();
                d.ID = Convert.ToInt32(reader["ID"]);
                d.SiparisID = Convert.ToInt32(reader["SiparisID"]);
                d.UrunID = Convert.ToInt32(reader["UrunID"]);
                d.Adet = Convert.ToInt32(reader["Adet"]);
                d.BirimFiyat = Convert.ToDecimal(reader["BirimFiyat"]);
                d.UrunAd = reader["UrunAd"].ToString();

                liste.Add(d);
            }
            reader.Close();
            kf.BaglantiAl().Close();
            return liste;
        }
    }
}