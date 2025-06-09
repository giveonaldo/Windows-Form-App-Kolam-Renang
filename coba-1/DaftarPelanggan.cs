using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coba_1
{
    public partial class DaftarPelanggan: Form
    {
        static string connString = "server=localhost; database=kolam_renang_pacific; uid=root; pwd=;";
        public DaftarPelanggan()
        {
            InitializeComponent();
            LoadPelanggan();
        }

        private void LoadPelanggan()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string query = "SELECT PelangganID, Nama, NoWA FROM pelanggan";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvPelanggan.AutoGenerateColumns = true;
                dgvPelanggan.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
