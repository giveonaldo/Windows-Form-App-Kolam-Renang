using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coba_1
{
    public partial class DaftarTransaksi : Form
    {
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific;Integrated Security=True";
        public DaftarTransaksi()
        {
            InitializeComponent();
            LoadTransaksi();
        }

        private void LoadTransaksi()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM transaksi"; // Gunakan query SQL Server

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn); // Ganti dari MySqlDataAdapter
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTable.AutoGenerateColumns = true;
                    dgvTable.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTiket_Click(object sender, EventArgs e)
        {
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Hide();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            DaftarPelanggan daftarPelanggan = new DaftarPelanggan();
            daftarPelanggan.Show();
            this.Hide();
        }
    }
}
