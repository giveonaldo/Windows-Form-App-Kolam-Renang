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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPelanggan.SelectedRows.Count > 0)
            {
                int pelangganID = Convert.ToInt32(dgvPelanggan.SelectedRows[0].Cells["PelangganID"].Value);

                DialogResult result = MessageBox.Show("Yakin ingin menghapus pelanggan ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        try
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_DeletePelanggan", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@PelangganID", pelangganID);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Pelanggan berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadPelanggan(); // refresh datagrid
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih pelanggan yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvPelanggan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPelanggan.Rows[e.RowIndex];

                string pelangganID = row.Cells["PelangganID"].Value.ToString();
                string nama = row.Cells["Nama"].Value.ToString();
                string noWA = row.Cells["NoWA"].Value.ToString();
                string createdAt = row.Cells["CreatedAt"].Value.ToString();
            }
        }
    }
}
