using MySql.Data.MySqlClient;
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
    public partial class Tiket: Form
    {
        string connString = "Data Source=DESKTOP-UMBBMDS\\MSSQLSERVER01;Initial Catalog=kolam_renang;Integrated Security=True;";
        public Tiket()
        {
            InitializeComponent();
            LoadTiket();
        }

        private void LoadTiket()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllTiket", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTiket.AutoGenerateColumns = true;
                        dgvTiket.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            // Pindah ke form transaksi
            DaftarTransaksi form3 = new DaftarTransaksi();
            form3.Show();
            this.Hide();
        }

        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            // Pindah ke Kelola tiket
            KelolaTiket kelolaTiket = new KelolaTiket();
            kelolaTiket.Show();
            this.Hide();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            DaftarPelanggan daftarPelanggan = new DaftarPelanggan();
            daftarPelanggan.Show();
            this.Hide();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
            this.Hide();
        }
    }
}
