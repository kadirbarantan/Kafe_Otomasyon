using KafeOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SQL komutları için bu şart!

namespace KafeOtomasyon.DataAccess
{
    public class SiparisVT // 'ş' harfini 's' yaptık, sorun çözüldü!
    {
        // 1. GÖREV: Masaya yeni bir sipariş (adisyon) açar ve açılan siparişin ID'sini geri döndürür
        public int SiparisAc(int masaID)
        {
            KafeVT kf = new KafeVT();
            // Siparişi ekle ve o an oluşan ID'yi (SCOPE_IDENTITY) geri al.
            string sorgu = "INSERT INTO Siparisler (MasaID, Tarih, ToplamTutar, Durum) VALUES (@p1, GETDATE(), 0, 0); SELECT SCOPE_IDENTITY();";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", masaID);

            int yeniID = Convert.ToInt32(komut.ExecuteScalar()); // Tek bir değer (ID) döndüğü için ExecuteScalar
            kf.BaglantiAl().Close();
            return yeniID;
        }

        // 2. GÖREV: Masanın şu anki aktif (açık - Durum=0) sipariş ID'sini getirir
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

        // 3. GÖREV: Hesabı kapatır (Toplam tutarı günceller ve durumu '1' yapar)
        public void SiparisKapat(int siparisID, decimal toplamTutar)
        {
            KafeVT kf = new KafeVT();
            // Durum = 1 demek, bu adisyon artık kapandı ve ödendi demektir.
            string sorgu = "UPDATE Siparisler SET ToplamTutar = @p1, Durum = 1 WHERE ID = @p2";
            SqlCommand komut = new SqlCommand(sorgu, kf.BaglantiAl());
            komut.Parameters.AddWithValue("@p1", toplamTutar);
            komut.Parameters.AddWithValue("@p2", siparisID);

            komut.ExecuteNonQuery();
            kf.BaglantiAl().Close();
        }
    }
}