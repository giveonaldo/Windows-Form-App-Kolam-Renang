﻿namespace coba_1
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
            this.dgvTiket.Location = new System.Drawing.Point(31, 153);
            this.dgvTiket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.RowHeadersWidth = 51;
            this.dgvTiket.RowTemplate.Height = 24;
            this.dgvTiket.Size = new System.Drawing.Size(679, 290);
            this.dgvTiket.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Daftar Tiket Kolam Renang Pacific Ocean.";
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(825, 175);
            this.btnPelanggan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(168, 34);
            this.btnPelanggan.TabIndex = 2;
            this.btnPelanggan.Text = "Daftar Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
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
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTambah.Location = new System.Drawing.Point(31, 89);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(123, 47);
            this.btnTambah.TabIndex = 4;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click_1);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(825, 101);
            this.btnTransaksi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(168, 34);
            this.btnTransaksi.TabIndex = 5;
            this.btnTransaksi.Text = "Daftar Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnTiket
            // 
            this.btnTiket.BackColor = System.Drawing.Color.Lime;
            this.btnTiket.Location = new System.Drawing.Point(825, 250);
            this.btnTiket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTiket.Name = "btnTiket";
            this.btnTiket.Size = new System.Drawing.Size(168, 34);
            this.btnTiket.TabIndex = 6;
            this.btnTiket.Text = "Daftar Tiket";
            this.btnTiket.UseVisualStyleBackColor = false;
            // 
            // Tiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 513);
            this.Controls.Add(this.btnTiket);
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
        private System.Windows.Forms.Button btnTiket;
    }
}