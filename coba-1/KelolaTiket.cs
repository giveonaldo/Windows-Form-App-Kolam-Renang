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
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific;Integrated Security=True";
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
                    string query = "SELECT TiketID, Jenis, Harga, Durasi FROM tiket";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvKelolaTiket.AutoGenerateColumns = true;
                    dgvKelolaTiket.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    if (txtJenisTiket.Text == "" || txtHarga.Text == "" || txtDurasi.Text == "")
                    {
                        MessageBox.Show("Field Tidak Boleh Kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        conn.Open();
                        string query = "INSERT INTO tiket (Jenis, Harga, Durasi) VALUES (@Jenis, @Harga, @Durasi)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Jenis", txtJenisTiket.Text);
                        cmd.Parameters.AddWithValue("@Harga", txtHarga.Text);
                        cmd.Parameters.AddWithValue("@Durasi", txtDurasi.Text);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Data berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear text box
                            txtJenisTiket.Clear();
                            txtHarga.Clear();
                            txtDurasi.Clear();

                            LoadTiket(); // Panggil ulang data
                        }
                        else
                        {
                            MessageBox.Show("Data gagal disimpan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            string query = "DELETE FROM tiket WHERE TiketID = @tiket";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@tiket", tiketID);
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
                MessageBox.Show(
                    "Pilih data yang akan diubah!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            string TiketID = dgvKelolaTiket.SelectedRows[0].Cells["TiketID"].Value.ToString();

            if (string.IsNullOrEmpty(txtJenisTiket.Text) && string.IsNullOrEmpty(txtHarga.Text) && string.IsNullOrEmpty(txtDurasi.Text))
            {
                MessageBox.Show(
                    "Tidak ada data yang diubah!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Apakah yakin ingin mengubah data ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
            {
                return;
            }

            StringBuilder queryBuilder = new StringBuilder("UPDATE tiket SET ");
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(txtJenisTiket.Text))
            {
                queryBuilder.Append("Jenis = @Jenis, ");
                parameters.Add(new SqlParameter("@Jenis", txtJenisTiket.Text));
            }

            if (!string.IsNullOrEmpty(txtHarga.Text))
            {
                queryBuilder.Append("Harga = @Harga, ");
                parameters.Add(new SqlParameter("@Harga", txtHarga.Text));
            }

            if (!string.IsNullOrEmpty(txtDurasi.Text))
            {
                queryBuilder.Append("Durasi = @Durasi, ");
                parameters.Add(new SqlParameter("@Durasi", txtDurasi.Text));
            }

            // Hapus koma dan spasi terakhir
            queryBuilder.Remove(queryBuilder.Length - 2, 2);

            queryBuilder.Append(" WHERE TiketID = @TiketID");
            parameters.Add(new SqlParameter("@TiketID", TiketID));

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn);

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Data berhasil diubah", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        LoadTiket();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Data tidak ditemukan atau gagal diubah!", "Kesalahan",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error: " + ex.Message, "Kesalahan",
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
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
