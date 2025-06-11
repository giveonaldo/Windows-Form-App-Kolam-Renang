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
    public partial class KelolaTiket : Form
    {
        string connString = "Data Source=DESKTOP-UMBBMDS\\MSSQLSERVER01;Initial Catalog=kolam_renang;Integrated Security=True;";

        private MemoryCache cache = MemoryCache.Default;

        public KelolaTiket()
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

                        dgvKelolaTiket.AutoGenerateColumns = true;
                        dgvKelolaTiket.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Validate empty fields first (client-side validation)
            if (string.IsNullOrWhiteSpace(txtJenisTiket.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(txtDurasi.Text))
            {
                MessageBox.Show("Field Tidak Boleh Kosong!", "Peringatan",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate numeric price
            if (!decimal.TryParse(txtHarga.Text, out decimal harga))
            {
                MessageBox.Show("Harga harus berupa angka!", "Peringatan",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Create command for stored procedure
                    SqlCommand cmd = new SqlCommand("sp_InsertTicket", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    cmd.Parameters.AddWithValue("@Jenis", txtJenisTiket.Text.Trim());
                    cmd.Parameters.AddWithValue("@Harga", harga);
                    cmd.Parameters.AddWithValue("@Durasi", txtDurasi.Text.Trim());

                    // Add output parameters
                    SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                    messageParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(messageParam);

                    // Execute the procedure
                    cmd.ExecuteNonQuery();

                    // Get results
                    int result = (int)resultParam.Value;
                    string message = messageParam.Value.ToString();

                    // Show appropriate message
                    if (result > 0)
                    {
                        MessageBox.Show(message, "Informasi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear fields
                        txtJenisTiket.Clear();
                        txtHarga.Clear();
                        txtDurasi.Clear();

                        // Refresh data
                        LoadTiket();
                    }
                    else
                    {
                        MessageBox.Show(message, "Peringatan",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Kesalahan",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKelolaTiket.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        try
                        {
                            string tiketID = dgvKelolaTiket.SelectedRows[0].Cells["TiketID"].Value.ToString();
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand("sp_DeleteTiket", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@TiketID", tiketID);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadTiket(); // Refresh DataGridView
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void dgvKelolaTiket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKelolaTiket.Rows[e.RowIndex];

                // Ambil berdasarkan nama kolom, bukan indeks
                txtJenisTiket.Text = row.Cells["Jenis"].Value.ToString();
                txtHarga.Text = row.Cells["Harga"].Value.ToString();
                txtDurasi.Text = row.Cells["Durasi"].Value.ToString();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvKelolaTiket.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtJenisTiket.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(txtDurasi.Text))
            {
                MessageBox.Show("Semua field harus diisi untuk update!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Apakah yakin ingin mengubah data ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            string TiketID = dgvKelolaTiket.SelectedRows[0].Cells["TiketID"].Value.ToString();

            // Validasi harga
            if (!decimal.TryParse(txtHarga.Text.Trim(), out decimal harga))
            {
                MessageBox.Show("Format harga tidak valid!", "Kesalahan",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateTiket", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TiketID", TiketID);
                        cmd.Parameters.AddWithValue("@Jenis", txtJenisTiket.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga", harga);
                        cmd.Parameters.AddWithValue("@Durasi", txtDurasi.Text.Trim()); // Sudah teks, bukan int

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diubah", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTiket();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan atau gagal diubah!", "Kesalahan",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Close();
        }
    }
}
