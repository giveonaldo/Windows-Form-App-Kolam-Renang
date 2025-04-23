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
    public partial class DaftarPelanggan: Form
    {
        public DaftarPelanggan()
        {
            InitializeComponent();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            // Pindah ke form transaksi
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void btnTiket_Click(object sender, EventArgs e)
        {
            // Pindah ke form tiket
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Hide();
        }
    }
}
