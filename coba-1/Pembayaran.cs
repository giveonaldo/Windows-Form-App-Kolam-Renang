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
    public partial class Pembayaran: Form
    {

        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific;Integrated Security=True";

        public Pembayaran()
        {
            InitializeComponent();
            LoadTiket();
        }

        private void LoadTiket()
        {          

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT TiketID, Jenis, Harga, Durasi FROM tiket";

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

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTable.SelectedRows[0];
                int tiketID = Convert.ToInt32(selectedRow.Cells["TiketID"].Value);

                int pelangganID = GetLatestPelangganID(); // Asumsikan metode ini masih Anda pakai
                if (pelangganID == -1)
                {
                    MessageBox.Show("Gagal mendapatkan PelangganID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "INSERT INTO transaksi (PelangganID, TiketID, TanggalBeli) " +
                               "VALUES (@PelangganID, @TiketID, GETDATE())"; // Ganti CURRENT_TIMESTAMP jadi GETDATE()

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@PelangganID", pelangganID);
                            cmd.Parameters.AddWithValue("@TiketID", tiketID);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Transaksi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih salah satu tiket terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetLatestPelangganID()
        {
            string query = "SELECT TOP 1 PelangganID FROM [user] ORDER BY PelangganID DESC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return -1;
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTable.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();
                string nama = row.Cells[1].Value.ToString();
                string harga = row.Cells[2].Value.ToString();
            }
        }
    }
}
