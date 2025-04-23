namespace coba_1
{
    partial class KelolaTiket
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
            this.dgvKelolaTiket = new System.Windows.Forms.DataGridView();
            this.txtJenisTiket = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.txtDurasi = new System.Windows.Forms.TextBox();
            this.lblJenisTiket = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelolaTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKelolaTiket
            // 
            this.dgvKelolaTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKelolaTiket.Location = new System.Drawing.Point(22, 21);
            this.dgvKelolaTiket.Name = "dgvKelolaTiket";
            this.dgvKelolaTiket.RowHeadersWidth = 51;
            this.dgvKelolaTiket.RowTemplate.Height = 24;
            this.dgvKelolaTiket.Size = new System.Drawing.Size(662, 228);
            this.dgvKelolaTiket.TabIndex = 0;
            // 
            // txtJenisTiket
            // 
            this.txtJenisTiket.Location = new System.Drawing.Point(32, 296);
            this.txtJenisTiket.Name = "txtJenisTiket";
            this.txtJenisTiket.Size = new System.Drawing.Size(311, 22);
            this.txtJenisTiket.TabIndex = 1;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(32, 365);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(311, 22);
            this.txtHarga.TabIndex = 2;
            // 
            // txtDurasi
            // 
            this.txtDurasi.Location = new System.Drawing.Point(32, 434);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.Size = new System.Drawing.Size(311, 22);
            this.txtDurasi.TabIndex = 3;
            // 
            // lblJenisTiket
            // 
            this.lblJenisTiket.AutoSize = true;
            this.lblJenisTiket.Location = new System.Drawing.Point(29, 277);
            this.lblJenisTiket.Name = "lblJenisTiket";
            this.lblJenisTiket.Size = new System.Drawing.Size(72, 16);
            this.lblJenisTiket.TabIndex = 4;
            this.lblJenisTiket.Text = "Jenis Tiket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Harga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Durasi";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTambah.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTambah.Location = new System.Drawing.Point(503, 284);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(84, 34);
            this.btnTambah.TabIndex = 7;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(503, 353);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 34);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(503, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 34);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // KelolaTiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 547);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJenisTiket);
            this.Controls.Add(this.txtDurasi);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtJenisTiket);
            this.Controls.Add(this.dgvKelolaTiket);
            this.Name = "KelolaTiket";
            this.Text = "KelolaTiket";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelolaTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKelolaTiket;
        private System.Windows.Forms.TextBox txtJenisTiket;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.TextBox txtDurasi;
        private System.Windows.Forms.Label lblJenisTiket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}