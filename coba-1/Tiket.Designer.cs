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
            this.btnTiket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTiket
            // 
            this.dgvTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiket.Location = new System.Drawing.Point(31, 120);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.RowHeadersWidth = 51;
            this.dgvTiket.RowTemplate.Height = 24;
            this.dgvTiket.Size = new System.Drawing.Size(542, 290);
            this.dgvTiket.TabIndex = 0;
            this.dgvTiket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiket_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Daftar Tiket Kolam Renang Pacific Ocean.";
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(634, 162);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(122, 34);
            this.btnPelanggan.TabIndex = 2;
            this.btnPelanggan.Text = "Daftar Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Admin Panel Kolam Renang Pacific Ocean";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTambah.Location = new System.Drawing.Point(31, 74);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(90, 31);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(634, 89);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(122, 34);
            this.btnTransaksi.TabIndex = 5;
            this.btnTransaksi.Text = "Daftar Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            // 
            // btnTiket
            // 
            this.btnTiket.BackColor = System.Drawing.Color.Lime;
            this.btnTiket.Location = new System.Drawing.Point(634, 238);
            this.btnTiket.Name = "btnTiket";
            this.btnTiket.Size = new System.Drawing.Size(122, 34);
            this.btnTiket.TabIndex = 6;
            this.btnTiket.Text = "Daftar Tiket";
            this.btnTiket.UseVisualStyleBackColor = false;
            // 
            // Tiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTiket);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPelanggan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTiket);
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
        private System.Windows.Forms.Button btnTiket;
    }
}