﻿using MySql.Data.MySqlClient;
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
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific_;Integrated Security=True";
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

                    // Use the stored procedure instead of raw SQL
                    SqlCommand cmd = new SqlCommand("sp_GetAllTickets", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Configure DataGridView
                    dgvTiket.AutoGenerateColumns = false;  // Better to set to false and define columns manually
                    dgvTiket.DataSource = dt;

                    // Optional: Format columns if needed
                    if (dgvTiket.Columns.Count == 0)
                    {
                        dgvTiket.Columns.Add("TiketID", "ID Tiket");
                        dgvTiket.Columns.Add("Jenis", "Jenis Tiket");
                        dgvTiket.Columns.Add("Harga", "Harga");
                        dgvTiket.Columns.Add("Durasi", "Durasi");

                        // Format the price column
                        dgvTiket.Columns["Harga"].DefaultCellStyle.Format = "N0";
                        dgvTiket.Columns["Harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading ticket data: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
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
<<<<<<< HEAD
            {
                DaftarPelanggan daftarPelanggan = new DaftarPelanggan();
                daftarPelanggan.Show();
                this.Hide();
            }
=======
            DaftarPelanggan daftarPelanggan = new DaftarPelanggan();
            daftarPelanggan.Show();
            this.Hide();
>>>>>>> b00702efedaffa67fdfb608e5b90d864df2933fa
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Form1 form1 = new Form1();
            form1.Show();
=======
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
>>>>>>> b00702efedaffa67fdfb608e5b90d864df2933fa
            this.Hide();
        }
    }
}
