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
    public partial class KelolaTiket : Form
    {
        static string connString = "server=localhost; database=kolam_renang_pacific; uid=root; pwd=;";
        public KelolaTiket()
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
                string query = "SELECT TIketID, Jenis, Harga, Durasi FROM tiket";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
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
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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

                        LoadTiket();

                    }
                    else
                    {
                        MessageBox.Show("Data gagal disimpan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKelolaTiket.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        try
                        {
                            string nim = dgvKelolaTiket.SelectedRows[0].Cells["TiketID"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM tiket WHERE TiketID = @tiket";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@tiket", nim);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadTiket();
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                        } catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
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

            if (txtJenisTiket.Text == "" && txtHarga.Text == "" && txtDurasi.Text == "")
            {
                MessageBox.Show(
                    "Tidak ada data yang diubah!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
                return;
            }

            StringBuilder queryBuilder = new StringBuilder("UPDATE tiket SET ");
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(txtJenisTiket.Text))
            {
                queryBuilder.Append("Jenis = @Jenis, ");
                parameters.Add(new MySqlParameter("@Jenis", txtJenisTiket.Text));
            }

            if (!string.IsNullOrEmpty(txtHarga.Text))
            {
                queryBuilder.Append("Harga = @Harga, ");
                parameters.Add(new MySqlParameter("@Harga", txtHarga.Text));
            }

            if (!string.IsNullOrEmpty(txtDurasi.Text))
            {
                queryBuilder.Append("Durasi = @Durasi, ");
                parameters.Add(new MySqlParameter("@Durasi", txtDurasi.Text));
            }

            queryBuilder.Remove(queryBuilder.Length - 2, 2);

            queryBuilder.Append(" WHERE TiketID = @TiketID");
            parameters.Add(new MySqlParameter("@TiketID", TiketID));

            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), conn);

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
}
