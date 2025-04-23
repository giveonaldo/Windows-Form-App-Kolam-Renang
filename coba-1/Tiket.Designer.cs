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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTiket
            // 
            this.dgvTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiket.Location = new System.Drawing.Point(48, 75);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.RowHeadersWidth = 51;
            this.dgvTiket.RowTemplate.Height = 24;
            this.dgvTiket.Size = new System.Drawing.Size(542, 290);
            this.dgvTiket.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiket";
            // 
            // btnPelanggan
            // 
            this.btnPelanggan.Location = new System.Drawing.Point(657, 83);
            this.btnPelanggan.Name = "btnPelanggan";
            this.btnPelanggan.Size = new System.Drawing.Size(94, 34);
            this.btnPelanggan.TabIndex = 2;
            this.btnPelanggan.Text = "Pelanggan";
            this.btnPelanggan.UseVisualStyleBackColor = true;
            this.btnPelanggan.Click += new System.EventHandler(this.btnPelanggan_Click);
            // 
            // Tiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}