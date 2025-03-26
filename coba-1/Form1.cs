using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coba_1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            TextBox txtNama = new TextBox();
            TextBox txtEmail = new TextBox();

            if (txtNama.Text != "" || txtEmail.Text != "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Data sudah diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                MessageBox.Show($"Data berhasil disimpan!\nNama : {txtNama.Text}\nEmail : {txtEmail.Text}", "Sukses!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtEmail.Clear();
                txtNama.Clear();
            }
        }

        
    }
}
