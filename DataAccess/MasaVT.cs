using System;
using System.Collections.Generic;
using KafeOtomasyon.Models; 
using System.Data.SqlClient;

namespace KafeOtomasyon.DataAccess
{
    public class MasaVT
    {
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
                m.Durum = Convert.ToBoolean(reader["Durum"]);

                masalar.Add(m);
            }

            reader.Close();
            kf.BaglantiAl().Close();
            return masalar;
        }

        
        public void DurumGuncelle(int masaID, bool yeniDurum)
        {
            KafeVT kf = new KafeVT();

            string sorgu = "UPDATE Masalar SET Durum = @p1 WHERE ID = @p2";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());

            komut.Parameters.AddWithValue("@p1", yeniDurum);
            komut.Parameters.AddWithValue("@p2", masaID);

            komut.ExecuteNonQuery(); 
            kf.BaglantiAl().Close();
        }
    }
}