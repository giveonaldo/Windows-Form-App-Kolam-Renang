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
            //MessageBox.Show("Terima kasih telah melakukan pemesanan tiket, " + txtNama.Text + "!");

            if (txtNama.Text == "" || txtNo.Text == "")
            {
                MessageBox.Show("Harap mengisi form terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNo.Text.Length < 11)
            {
                MessageBox.Show("Nomor harus terdiri dari 11 - 12 karakter", "Peringatan",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNo.Text.Length > 13)
            {
                MessageBox.Show("Nomor tidak boleh lebih dari 13 karakter", "Peringatan",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!long.TryParse(txtNo.Text, out _))
            {
                MessageBox.Show("Nomor harus berupa angka", "Peringatan",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Terima kasih telah melakukan pemesanan tiket, " + txtNama.Text + "!");
            }

            this.Close();
        }
    }
}
