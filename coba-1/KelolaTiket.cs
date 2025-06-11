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
using System.Runtime.Caching;
using System.Transactions;


namespace coba_1
{
    public partial class KelolaTiket : Form
    {
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_;Integrated Security=True";

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
                lblmessage.Text = "Field Tidak Boleh Kosong!";
                return;
            }

            // Validate numeric price
            if (!decimal.TryParse(txtHarga.Text, out decimal harga))
            {
                MessageBox.Show("Harga harus berupa angka!", "Peringatan",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblmessage.Text = "Harga harus berupa angka!";
                return;
            }


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertTicket", conn, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Jenis", txtJenisTiket.Text.Trim());
                    cmd.Parameters.AddWithValue("@Harga", harga);
                    cmd.Parameters.AddWithValue("@Durasi", txtDurasi.Text.Trim());

                    SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(resultParam);

                    SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messageParam);

                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    int result = (int)resultParam.Value;
                    string message = messageParam.Value.ToString();

                    if (result > 0)
                    {
                        MessageBox.Show(message, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtJenisTiket.Clear();
                        txtHarga.Clear();
                        txtDurasi.Clear();
                        LoadTiket();
                    }
                    else
                    {
                        MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Transaksi gagal: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblmessage.Text = "Error: " + ex.Message;
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
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string tiketID = dgvKelolaTiket.SelectedRows[0].Cells["TiketID"].Value.ToString();
                            conn.Open();

                            using (SqlCommand cmd = new SqlCommand("sp_DeleteTiket", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@TiketID", tiketID);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblmessage.Text = "Data berhasil dihapus!";
                                    LoadTiket();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lblmessage.Text = "Data tidak ditemukan atau gagal dihapus!";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction?.Rollback();
                            MessageBox.Show("Error saat hapus: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblmessage.Text = "Error: " + ex.Message;
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
                lblmessage.Text = "Pilih data yang akan diubah!";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtJenisTiket.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(txtDurasi.Text))
            {
                MessageBox.Show("Semua field harus diisi untuk update!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblmessage.Text = "Semua field harus diisi untuk update!";
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
                lblmessage.Text = "Format harga tidak valid!";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateTiket", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TiketID", TiketID);
                        cmd.Parameters.AddWithValue("@Jenis", txtJenisTiket.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga", txtHarga.Text.Trim());
                        cmd.Parameters.AddWithValue("@Durasi", txtDurasi.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("Data berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblmessage.Text = "Data berhasil diubah";
                            LoadTiket();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Data tidak ditemukan atau gagal diubah!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblmessage.Text = "Data tidak ditemukan atau gagal diubah!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error saat update: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblmessage.Text = "Error: " + ex.Message;
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
