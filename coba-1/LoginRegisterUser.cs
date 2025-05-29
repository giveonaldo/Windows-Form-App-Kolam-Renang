
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
    public partial class LoginRegisterUser: Form
    {
        // Initialize MySqlConnection
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific;Integrated Security=True";
        public LoginRegisterUser()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Insert data into database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    string nama = txtNama.Text.Trim();
                    string nowa = txtNo.Text.Trim();

                    if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nowa))
                    {
                        MessageBox.Show("Harap mengisi form terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (nowa.Length < 11 || nowa.Length > 13)
                    {
                        MessageBox.Show("Nomor harus terdiri dari 11 - 13 karakter", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!long.TryParse(nowa, out _))
                    {
                        MessageBox.Show("Nomor harus berupa angka", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        conn.Open();

                        // Cek apakah Nama & NoWA cocok (login sukses)
                        string checkBoth = @"
                    SELECT COUNT(*) FROM [user]
                    WHERE Nama = @Nama AND NoWA = @NoWA AND is_admin = 0";
                        SqlCommand cmdCheckBoth = new SqlCommand(checkBoth, conn);
                        cmdCheckBoth.Parameters.AddWithValue("@Nama", nama);
                        cmdCheckBoth.Parameters.AddWithValue("@NoWA", nowa);

                        int matchBoth = (int)cmdCheckBoth.ExecuteScalar();

                        if (matchBoth > 0)
                        {
                            MessageBox.Show("Selamat datang kembali!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Cek apakah NoWA ada (tapi Nama salah)
                            string checkNoWA = @"SELECT COUNT(*) FROM [user] WHERE NoWA = @NoWA AND is_admin = 0";
                            SqlCommand cmdCheckNoWA = new SqlCommand(checkNoWA, conn);
                            cmdCheckNoWA.Parameters.AddWithValue("@NoWA", nowa);
                            int matchNoWA = (int)cmdCheckNoWA.ExecuteScalar();

                            if (matchNoWA > 0)
                            {
                                MessageBox.Show("Username anda salah", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Cek apakah Nama ada (tapi NoWA salah)
                            string checkNama = @"SELECT COUNT(*) FROM [user] WHERE Nama = @Nama AND is_admin = 0";
                            SqlCommand cmdCheckNama = new SqlCommand(checkNama, conn);
                            cmdCheckNama.Parameters.AddWithValue("@Nama", nama);
                            int matchNama = (int)cmdCheckNama.ExecuteScalar();

                            if (matchNama > 0)
                            {
                                MessageBox.Show("Nomor WhatsApp anda salah", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Jika tidak ditemukan sama sekali → daftar pelanggan baru
                            string insertQuery = @"
                        INSERT INTO [user] (Nama, NoWA)
                        VALUES (@Nama, @NoWA)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@Nama", nama);
                            insertCmd.Parameters.AddWithValue("@NoWA", nowa);

                            int result = insertCmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Pelanggan baru berhasil didaftarkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Gagal menyimpan data pelanggan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Bersihkan input
                        txtNama.Clear();
                        txtNo.Clear();

                        // Pindah ke Form2
                        Pembayaran form2 = new Pembayaran();
                        form2.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Option option = new Option();
            option.Show();
            this.Hide();
        }
    }
}
