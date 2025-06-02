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
    public partial class DaftarPelanggan: Form
    {
        string connString = "Data Source=DESKTOP-UMBBMDS\\MSSQLSERVER01;Initial Catalog=kolam_renang;Integrated Security=True;";
        public DaftarPelanggan()
        {
            InitializeComponent();
            LoadPelanggan();
        }

        private void LoadPelanggan()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllPelanggan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvPelanggan.AutoGenerateColumns = true;
                        dgvPelanggan.DataSource = dt;
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

        private void btnTiket_Click(object sender, EventArgs e)
        {
            // Pindah ke form tiket
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Hide();
        }
    }
}
