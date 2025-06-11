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

        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific_;Integrated Security=True";

        public Pembayaran()
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

                        dgvTable.AutoGenerateColumns = true;
                        dgvTable.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTable.SelectedRows[0];
                int tiketID = Convert.ToInt32(selectedRow.Cells["TiketID"].Value);

                int pelangganID = GetLatestPelangganID();
                if (pelangganID == -1)
                {
                    MessageBox.Show("Gagal mendapatkan PelangganID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_InsertTransaksi", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PelangganID", pelangganID);
                            cmd.Parameters.AddWithValue("@TiketID", tiketID);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Transaksi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginRegisterUser loginRegisterUser = new LoginRegisterUser();
                        loginRegisterUser.Show();
                        this.Hide();
                        
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
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetLatestPelangganID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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
