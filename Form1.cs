using KafeOtomasyon.DataAccess;
using KafeOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafeOtomasyon
{
    public partial class Form1 : Form
    {
        MasaVT mvt=new MasaVT();
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            MasaListele();
        }

        public void MasaListele()
        {
            flowLayoutPanelMasalar.Controls.Clear();
            List<Masa> masaListesi = mvt.Listeler();

            foreach (var masa in masaListesi)
            {
                Button btn =new Button();
                btn.Text = masa.MasaNo;
                btn.Name = "btnMasa_" + masa.ID;
                btn.Size = new Size(150, 100);
                btn.Tag = masa.ID;

                if (masa.Durum==false)
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    
                    btn.BackColor=Color.Red;
                    btn.ForeColor=Color.White;
                }

                btn.Click += Masa_Click;

                flowLayoutPanelMasalar.Controls.Add(btn);
            }
        }
        private void Masa_Click(object sender, EventArgs e)
        {
            Button tiklananButon = (Button)sender;
            int secilenMasaID = (int)tiklananButon.Tag;

            MessageBox.Show(secilenMasaID + " numaralı masaya tıklandı");
            Button btn = (Button)sender;
            int masaID = (int)btn.Tag; // Masanın ID'sini butondan alıyoruz

            SiparisForm frm = new SiparisForm();
            frm.secilenMasaID = masaID; // ID'yi diğer forma gönderiyoruz
            frm.ShowDialog(); // Sipariş formunu açıyoruz

            // Form kapandıktan sonra masaların rengini güncellemek için:
            MasaListele();
        }
    }
    }

