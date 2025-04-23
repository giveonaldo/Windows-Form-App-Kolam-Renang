using MySql.Data.MySqlClient;
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
    public partial class Tiket: Form
    {
        static string connString = "server=localhost; database=kolam_renang_pacific; uid=root; pwd=;";
        public Tiket()
        {
            InitializeComponent();
            LoadTiket();
        }

        private void LoadTiket()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string query = "SELECT Jenis, Harga, Durasi FROM tiket";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvTiket.AutoGenerateColumns = true;
                dgvTiket.DataSource = dt;

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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Pindah ke form kelola tiket
            KelolaTiket kelolaTiket = new KelolaTiket();
            kelolaTiket.Show();
            this.Hide();
        }
    }
}
