#  Stok Takip Sistemi

Bu uygulama, modern yazılım geliştirme prensipleri ve işletme yönetimi ihtiyaçları doğrultusunda hazırlanmış basit seviye bir envanter yönetim aracıdır. İşletmelerin stok süreçlerini dijitalleştirmesi, veri bütünlüğünü koruması ve operasyonel verimliliği artırması için tasarlanmıştır.

---

##  Kullanılan Teknolojiler

* **Dil:** C# (Windows Forms)
* **Veritabanı:** MS SQL Server
* **Sürüm Kontrolü:** Git

---

##  Temel Özellikler

* **Dinamik Envanter Yönetimi:** Ürünlerin eklenmesi, güncellenmesi ve silinmesi (CRUD) işlemlerini yönetir.
* **Hızlı Arama:** Ürün adına göre veritabanı üzerinde anlık filtreleme yaparak istenen veriye saniyeler içinde ulaşılmasını sağlar.
* **Veri Güvenliği:** SQL parametreleri kullanılarak veritabanı sorgularının güvenli, stabil ve SQL Injection riskine karşı korumalı çalışması sağlanmıştır.
* **Akıllı Arayüz:** `DataGridView` üzerinden satır seçimi yapıldığında, verilerin form alanlarına otomatik olarak aktarılmasıyla kullanıcı deneyimi artırılmıştır.

---

##  Kurulum ve Kullanım

1. **Veritabanı Kurulumu:** `vt.sql` dosyasını SQL Server Management Studio (SSMS) üzerinde çalıştırarak tablo yapısını oluşturun.
2. **Bağlantı Ayarı:** `UrunVT.cs` dosyası içerisindeki bağlantı adresini (Connection String) kendi SQL Server bilgilerinizle güncelleyin:
   ```csharp
   string connectionString = "Server=YOUR_SERVER_NAME; Database=StokTakip; Integrated Security=True";
---
*Bu proje Kadir Baran TAN tarafından, yazılım geliştirme prensipleri ve modern veritabanı yönetim teknikleri uygulanarak geliştirilmiştir.*
