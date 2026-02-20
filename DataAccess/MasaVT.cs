using System;
using System.Collections.Generic;
using KafeOtomasyon.Models; // Models klasöründeki Masa sınıfı için
using System.Data.SqlClient; // SQL kütüphanesi

namespace KafeOtomasyon.DataAccess
{
    public class MasaVT
    {
        // 1. GÖREV: Tüm masaları veritabanından getirir
        public List<Masa> Listeler()
        {
            List<Masa> masalar = new List<Masa>();
            KafeVT kf = new KafeVT();

            SqlCommand komut = new SqlCommand("SELECT * FROM Masalar", kf.BaglantiAl());
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                Masa m = new Masa();
                m.ID = Convert.ToInt32(reader["ID"]);
                m.MasaNo = reader["MasaNo"].ToString();
                m.Durum = Convert.ToBoolean(reader["Durum"]); // 0: Boş, 1: Dolu

                masalar.Add(m);
            }

            reader.Close();
            kf.BaglantiAl().Close();
            return masalar;
        }

        // 2. GÖREV: Masanın durumunu günceller (Sipariş açıldığında veya kapandığında)
        public void DurumGuncelle(int masaID, bool yeniDurum)
        {
            KafeVT kf = new KafeVT();

            // SQL'de bit tipi C#'ta bool olarak karşılık bulur
            string sorgu = "UPDATE Masalar SET Durum = @p1 WHERE ID = @p2";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());

            komut.Parameters.AddWithValue("@p1", yeniDurum);
            komut.Parameters.AddWithValue("@p2", masaID);

            komut.ExecuteNonQuery(); // Select işlemi olmadığı için ExecuteNonQuery kullanıyoruz
            kf.BaglantiAl().Close();
        }
    }
}