namespace KafeOtomasyon
{
    partial class SiparisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpKategoriler = new System.Windows.Forms.FlowLayoutPanel();
            this.lvSepet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnİptal = new System.Windows.Forms.Button();
            this.btnOdeme_Al = new System.Windows.Forms.Button();
            this.btnSiparis_Onayla = new System.Windows.Forms.Button();
            this.flpUrunler = new System.Windows.Forms.Panel();
            this.lblToplam = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpKategoriler
            // 
            this.flpKategoriler.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpKategoriler.Location = new System.Drawing.Point(0, 0);
            this.flpKategoriler.Name = "flpKategoriler";
            this.flpKategoriler.Size = new System.Drawing.Size(200, 549);
            this.flpKategoriler.TabIndex = 0;
            // 
            // lvSepet
            // 
            this.lvSepet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvSepet.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvSepet.FullRowSelect = true;
            this.lvSepet.GridLines = true;
            this.lvSepet.HideSelection = false;
            this.lvSepet.Location = new System.Drawing.Point(1058, 0);
            this.lvSepet.MultiSelect = false;
            this.lvSepet.Name = "lvSepet";
            this.lvSepet.Size = new System.Drawing.Size(243, 549);
            this.lvSepet.TabIndex = 1;
            this.lvSepet.UseCompatibleStateImageBehavior = false;
            this.lvSepet.View = System.Windows.Forms.View.Details;
            this.lvSepet.Click += new System.EventHandler(this.lvSepet_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Adı";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adet";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fiyat";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Toplam";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnİptal);
            this.panel1.Controls.Add(this.btnOdeme_Al);
            this.panel1.Controls.Add(this.btnSiparis_Onayla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(200, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnİptal
            // 
            this.btnİptal.Location = new System.Drawing.Point(334, 35);
            this.btnİptal.Name = "btnİptal";
            this.btnİptal.Size = new System.Drawing.Size(126, 41);
            this.btnİptal.TabIndex = 2;
            this.btnİptal.Text = "İptal";
            this.btnİptal.UseVisualStyleBackColor = true;
            this.btnİptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnOdeme_Al
            // 
            this.btnOdeme_Al.Location = new System.Drawing.Point(186, 35);
            this.btnOdeme_Al.Name = "btnOdeme_Al";
            this.btnOdeme_Al.Size = new System.Drawing.Size(126, 41);
            this.btnOdeme_Al.TabIndex = 1;
            this.btnOdeme_Al.Text = "Ödeme Al";
            this.btnOdeme_Al.UseVisualStyleBackColor = true;
            this.btnOdeme_Al.Click += new System.EventHandler(this.btnOdeme_Al_Click);
            // 
            // btnSiparis_Onayla
            // 
            this.btnSiparis_Onayla.Location = new System.Drawing.Point(43, 35);
            this.btnSiparis_Onayla.Name = "btnSiparis_Onayla";
            this.btnSiparis_Onayla.Size = new System.Drawing.Size(126, 41);
            this.btnSiparis_Onayla.TabIndex = 0;
            this.btnSiparis_Onayla.Text = "Sipariş Onayla";
            this.btnSiparis_Onayla.UseVisualStyleBackColor = true;
            this.btnSiparis_Onayla.Click += new System.EventHandler(this.btnSiparis_Onayla_Click);
            // 
            // flpUrunler
            // 
            this.flpUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpUrunler.Location = new System.Drawing.Point(200, 0);
            this.flpUrunler.Name = "flpUrunler";
            this.flpUrunler.Size = new System.Drawing.Size(858, 449);
            this.flpUrunler.TabIndex = 3;
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplam.Location = new System.Drawing.Point(1122, 449);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(34, 24);
            this.lblToplam.TabIndex = 5;
            this.lblToplam.Text = "00";
            // 
            // SiparisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 549);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.flpUrunler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvSepet);
            this.Controls.Add(this.flpKategoriler);
            this.Name = "SiparisForm";
            this.Text = "SiparisForm";
            this.Load += new System.EventHandler(this.SiparisForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpKategoriler;
        private System.Windows.Forms.ListView lvSepet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnİptal;
        private System.Windows.Forms.Button btnOdeme_Al;
        private System.Windows.Forms.Button btnSiparis_Onayla;
        private System.Windows.Forms.Panel flpUrunler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblToplam;
    }
}