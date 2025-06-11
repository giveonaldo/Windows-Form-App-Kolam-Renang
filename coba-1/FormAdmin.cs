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
    public partial class FormAdmin : Form
    {
        string connString = "Data Source=DESKTOP-UMBBMDS\\MSSQLSERVER01;Initial Catalog=kolam_renang;Integrated Security=True;";
        public FormAdmin()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*';
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Option option = new Option();
            option.Show();
            this.Hide();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AdminLogin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("Login berhasil sebagai Admin.");
                                this.Hide();
                                DaftarTransaksi form3 = new DaftarTransaksi(); // Ganti sesuai nama form
                                form3.Show();
                            }
                            else
                            {
                                MessageBox.Show("Login gagal. Pastikan data benar dan Anda adalah Admin.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }

    }
}
