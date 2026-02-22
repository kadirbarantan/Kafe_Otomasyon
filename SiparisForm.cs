using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KafeOtomasyon.DataAccess;
using KafeOtomasyon.Models;

namespace KafeOtomasyon
{
    public partial class SiparisForm : Form
    {
        public int secilenMasaID;

        KategoriVT ktg = new KategoriVT();
        UrunVT uvt = new UrunVT();
        SiparisVT svt = new SiparisVT();
        SiparisDetayVT sdvt = new SiparisDetayVT();
        MasaVT mvt = new MasaVT();

        public SiparisForm()
        {
            InitializeComponent();
        }

        private void SiparisForm_Load(object sender, EventArgs e)
        {
            if (secilenMasaID == 0) secilenMasaID = 1;

            this.Text = "Masa " + secilenMasaID + " - Sipariş Paneli";

            KategoriListele();
            SepetiDoldur();
        }

        public void KategoriListele()
        {
            flpKategoriler.Controls.Clear();
            List<Kategori> kategoriListesi = ktg.Listeler();

            foreach (var kategori in kategoriListesi)
            {
                Button btn = new Button();
                btn.Text = kategori.KategoriAd;
                btn.Name = "btnKategori_" + kategori.ID;
                btn.Size = new Size(150, 100);
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.Tag = kategori.ID;

                btn.Click += Kategori_Click;
                flpKategoriler.Controls.Add(btn);
            }
        }

        private void Kategori_Click(object sender, EventArgs e)
        {
            Button basilan = (Button)sender;
            int katID = (int)basilan.Tag;
            UrunleriListele(katID);
        }

        public void UrunleriListele(int katID)
        {
            flpUrunler.Controls.Clear();
            List<Urun> urunler = uvt.ListeleByKategori(katID);

            foreach (var urun in urunler)
            {
                Button btnUrun = new Button();
                btnUrun.Text = urun.UrunAd + "\n" + urun.Fiyat.ToString("C2");
                btnUrun.Size = new Size(130, 90);
                btnUrun.BackColor = Color.LightSkyBlue;
                btnUrun.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnUrun.Tag = urun;

                btnUrun.Click += Urun_Click;
                flpUrunler.Controls.Add(btnUrun);
            }
        }

        private void Urun_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Urun secilenUrun = (Urun)btn.Tag;

            bool bulundu = false;

            foreach (ListViewItem item in lvSepet.Items)
            {
                if (item.Text == secilenUrun.UrunAd)
                {
                    int mevcutAdet = int.Parse(item.SubItems[1].Text);
                    mevcutAdet++;
                    item.SubItems[1].Text = mevcutAdet.ToString();

                    decimal yeniSatirToplami = mevcutAdet * secilenUrun.Fiyat;
                    item.SubItems[3].Text = yeniSatirToplami.ToString("C2");

                    bulundu = true;
                    break;
                }
            }

            if (!bulundu)
            {
                ListViewItem satir = new ListViewItem(secilenUrun.UrunAd);
                satir.SubItems.Add("1");
                satir.SubItems.Add(secilenUrun.Fiyat.ToString("C2"));
                satir.SubItems.Add(secilenUrun.Fiyat.ToString("C2"));
                satir.Tag = secilenUrun.ID;

                lvSepet.Items.Add(satir);
            }

            GenelToplamHesapla();
        }

        private void GenelToplamHesapla()
        {
            decimal toplamTutar = 0;
            foreach (ListViewItem item in lvSepet.Items)
            {
                string fiyatMetni = item.SubItems[3].Text.Replace("₺", "").Trim();
                toplamTutar += decimal.Parse(fiyatMetni);
            }
            lblToplam.Text = "Toplam Tutar: " + toplamTutar.ToString("C2");
        }

        private void btnSiparis_Onayla_Click(object sender, EventArgs e)
        {
            if (lvSepet.Items.Count == 0)
            {
                MessageBox.Show("Lütfen önce ürün seçiniz!");
                return;
            }

            int yeniSiparisID = svt.SiparisAc(secilenMasaID);

            foreach (ListViewItem item in lvSepet.Items)
            {
                SiparisDetay detay = new SiparisDetay();
                detay.SiparisID = yeniSiparisID;
                detay.UrunID = (int)item.Tag;
                detay.Adet = int.Parse(item.SubItems[1].Text);
                string fiyatTemiz = item.SubItems[2].Text.Replace("₺", "").Trim();
                detay.BirimFiyat = decimal.Parse(fiyatTemiz);

                sdvt.UrunEkle(detay);
            }

            mvt.DurumGuncelle(secilenMasaID, true);
            MessageBox.Show("Sipariş başarıyla kaydedildi.");
            this.Close();
        }

        private void btnOdeme_Al_Click(object sender, EventArgs e)
        {
            int aktifSiparisID = svt.GetAktifSiparisID(secilenMasaID);

            if (aktifSiparisID == 0)
            {
                MessageBox.Show("Aktif sipariş bulunamadı!");
                return;
            }

            decimal toplamTutar = 0;
            foreach (ListViewItem item in lvSepet.Items)
            {
                string tutarMetni = item.SubItems[3].Text.Replace("₺", "").Trim();
                toplamTutar += decimal.Parse(tutarMetni);
            }

            svt.SiparisKapat(aktifSiparisID, toplamTutar);
            mvt.DurumGuncelle(secilenMasaID, false);

            MessageBox.Show($"{toplamTutar:C2} ödeme alındı.");
            this.Close();
        }

        public void SepetiDoldur()
        {
            lvSepet.Items.Clear();
            int aktifSiparisID = svt.GetAktifSiparisID(secilenMasaID);

            if (aktifSiparisID > 0)
            {
                List<SiparisDetay> detaylar = sdvt.DetaylariGetir(aktifSiparisID);

                foreach (var detay in detaylar)
                {
                    ListViewItem satir = new ListViewItem(detay.UrunAd);
                    satir.SubItems.Add(detay.Adet.ToString());
                    satir.SubItems.Add(detay.BirimFiyat.ToString("C2"));
                    decimal satirToplami = detay.Adet * detay.BirimFiyat;
                    satir.SubItems.Add(satirToplami.ToString("C2"));
                    satir.Tag = detay.UrunID;
                    lvSepet.Items.Add(satir);
                }
                GenelToplamHesapla();
            }
        }

        private void lvSepet_DoubleClick(object sender, EventArgs e)
        {
            if (lvSepet.SelectedItems.Count > 0)
            {
                lvSepet.Items.Remove(lvSepet.SelectedItems[0]);
                GenelToplamHesapla();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istiyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}