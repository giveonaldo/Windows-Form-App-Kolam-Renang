namespace coba_1
{
    partial class DaftarPelanggan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPelanggan = new System.Windows.Forms.DataGridView();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.btnTiket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelanggan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Panel Kolam Renang Pacific Ocean";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daftar transaksi pelanggan kolam renang Pacific Ocean.";
            // 
            // dgvPelanggan
            // 
            this.dgvPelanggan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelanggan.Location = new System.Drawing.Point(62, 106);
            this.dgvPelanggan.Name = "dgvPelanggan";
            this.dgvPelanggan.Size = new System.Drawing.Size(529, 310);
            this.dgvPelanggan.TabIndex = 2;
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.Location = new System.Drawing.Point(654, 106);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(119, 38);
            this.btnTransaksi.TabIndex = 3;
            this.btnTransaksi.Text = "Daftar Transaksi";
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnTiket
            // 
            this.btnTiket.Location = new System.Drawing.Point(654, 172);
            this.btnTiket.Name = "btnTiket";
            this.btnTiket.Size = new System.Drawing.Size(119, 38);
            this.btnTiket.TabIndex = 4;
            this.btnTiket.Text = "Daftar Tiket";
            this.btnTiket.UseVisualStyleBackColor = true;
            this.btnTiket.Click += new System.EventHandler(this.btnTiket_Click);
            // 
            // DaftarPelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTiket);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.dgvPelanggan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DaftarPelanggan";
            this.Text = "DaftarPelanggan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelanggan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPelanggan;
        private System.Windows.Forms.Button btnTransaksi;
        private System.Windows.Forms.Button btnTiket;
    }
}