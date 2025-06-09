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
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKelolaTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKelolaTiket
            // 
            this.dgvKelolaTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKelolaTiket.Location = new System.Drawing.Point(25, 26);
            this.dgvKelolaTiket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvKelolaTiket.Name = "dgvKelolaTiket";
            this.dgvKelolaTiket.RowHeadersWidth = 51;
            this.dgvKelolaTiket.RowTemplate.Height = 24;
            this.dgvKelolaTiket.Size = new System.Drawing.Size(745, 285);
            this.dgvKelolaTiket.TabIndex = 0;
            this.dgvKelolaTiket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKelolaTiket_CellContentClick);
            // 
            // txtJenisTiket
            // 
            this.txtJenisTiket.Location = new System.Drawing.Point(36, 370);
            this.txtJenisTiket.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJenisTiket.Name = "txtJenisTiket";
            this.txtJenisTiket.Size = new System.Drawing.Size(349, 26);
            this.txtJenisTiket.TabIndex = 1;
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(36, 456);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(349, 26);
            this.txtHarga.TabIndex = 2;
            // 
            // txtDurasi
            // 
            this.txtDurasi.Location = new System.Drawing.Point(36, 542);
            this.txtDurasi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.Size = new System.Drawing.Size(349, 26);
            this.txtDurasi.TabIndex = 3;
            // 
            // lblJenisTiket
            // 
            this.lblJenisTiket.AutoSize = true;
            this.lblJenisTiket.Location = new System.Drawing.Point(33, 346);
            this.lblJenisTiket.Name = "lblJenisTiket";
            this.lblJenisTiket.Size = new System.Drawing.Size(84, 20);
            this.lblJenisTiket.TabIndex = 4;
            this.lblJenisTiket.Text = "Jenis Tiket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Harga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Durasi";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTambah.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTambah.Location = new System.Drawing.Point(566, 355);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(94, 42);
            this.btnTambah.TabIndex = 7;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(566, 441);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 42);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(566, 528);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 42);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(42, 611);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 27);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // KelolaTiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 684);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.button1);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBack;
    }
}