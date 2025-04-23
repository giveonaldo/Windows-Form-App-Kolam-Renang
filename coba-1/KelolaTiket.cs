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
                string query = "SELECT TiketID, Jenis, Harga, Durasi FROM tiket";
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

    }
}
