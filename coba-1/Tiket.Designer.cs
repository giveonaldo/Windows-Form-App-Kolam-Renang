namespace coba_1
{
    partial class Tiket
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
            this.dgvTiket = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPelanggan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTiket
            // 
            this.dgvTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiket.Location = new System.Drawing.Point(35, 191);
            this.dgvTiket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.RowHeadersWidth = 51;
            this.dgvTiket.RowTemplate.Height = 24;
            this.dgvTiket.Size = new System.Drawing.Size(764, 362);
            this.dgvTiket.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Daftar Tiket Kolam Renang Pacific Ocean.";
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(928, 219);
            this.btnPelanggan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(189, 42);
            this.btnPelanggan.TabIndex = 2;
            this.btnPelanggan.Text = "Daftar Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(592, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Admin Panel Kolam Renang Pacific Ocean";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTambah.Location = new System.Drawing.Point(35, 111);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(138, 59);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click_1);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(928, 126);
            this.btnTransaksi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(189, 42);
            this.btnTransaksi.TabIndex = 5;
            this.btnTransaksi.Text = "Daftar Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnKeluar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
<<<<<<< HEAD
            this.btnKeluar.Location = new System.Drawing.Point(928, 312);
            this.btnKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(189, 42);
=======
            this.btnKeluar.Location = new System.Drawing.Point(825, 250);
            this.btnKeluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(168, 34);
>>>>>>> b00702efedaffa67fdfb608e5b90d864df2933fa
            this.btnKeluar.TabIndex = 6;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // Tiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1197, 641);
=======
            this.ClientSize = new System.Drawing.Size(1064, 513);
>>>>>>> b00702efedaffa67fdfb608e5b90d864df2933fa
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPelanggan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTiket);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Tiket";
            this.Text = "Tiket";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTiket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPelanggan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.Button btnKeluar;
    }
}