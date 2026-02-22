using KafeOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; 

namespace KafeOtomasyon.DataAccess
{
    public class SiparisVT 
    {
        public int SiparisAc(int masaID)
        {
            KafeVT kf = new KafeVT();
            string sorgu = "INSERT INTO Siparisler (MasaID, Tarih, ToplamTutar, Durum) VALUES (@p1, GETDATE(), 0, 0); SELECT SCOPE_IDENTITY();";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", masaID);

            int yeniID = Convert.ToInt32(komut.ExecuteScalar());
            kf.BaglantiAl().Close();
            return yeniID;
        }

        public int GetAktifSiparisID(int masaID)
        {
            KafeVT kf = new KafeVT();
            string sorgu = "SELECT ID FROM Siparisler WHERE MasaID = @p1 AND Durum = 0";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", masaID);

            object sonuc = komut.ExecuteScalar();
            kf.BaglantiAl().Close();

            return sonuc != null ? Convert.ToInt32(sonuc) : 0;
        }

        public void SiparisKapat(int siparisID, decimal toplamTutar)
        {
            KafeVT kf = new KafeVT();
            string sorgu = "UPDATE Siparisler SET ToplamTutar = @p1, Durum = 1 WHERE ID = @p2";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", toplamTutar);
            komut.Parameters.AddWithValue("@p2", siparisID);

            komut.ExecuteNonQuery();
            kf.BaglantiAl().Close();
        }
    }
}