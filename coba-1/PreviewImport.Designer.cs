namespace coba_1
{
    partial class PreviewImport
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
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvPreviewdata = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewdata)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(640, 397);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvPreviewdata
            // 
            this.dgvPreviewdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewdata.Location = new System.Drawing.Point(27, 27);
            this.dgvPreviewdata.Name = "dgvPreviewdata";
            this.dgvPreviewdata.RowHeadersWidth = 51;
            this.dgvPreviewdata.RowTemplate.Height = 24;
            this.dgvPreviewdata.Size = new System.Drawing.Size(726, 324);
            this.dgvPreviewdata.TabIndex = 2;
            this.dgvPreviewdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreviewdata_CellContentClick);
            // 
            // PreviewImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPreviewdata);
            this.Controls.Add(this.btnOK);
            this.Name = "PreviewImport";
            this.Text = "PreviewImport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvPreviewdata;
    }
}