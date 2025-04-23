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
    public partial class Form1: Form
    {
        // Initialize MySqlConnection
        static string connString = "server=localhost; database=kolam_renang_pacific; uid=root; pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Insert data into database
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                if (txtNama.Text == "Admin" && txtNo.Text == "Admin")
                {
                    MessageBox.Show("Selamat Datang Admin", "Success", MessageBoxButtons.OK);
                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }
                else if (txtNama.Text == "" || txtNo.Text == "")
                {
                    MessageBox.Show("Harap mengisi form terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtNo.Text.Length < 11)
                {
                    MessageBox.Show("Nomor harus terdiri dari 11 - 12 karakter", "Peringatan",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtNo.Text.Length > 13)
                {
                    MessageBox.Show("Nomor tidak boleh lebih dari 13 karakter", "Peringatan",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!long.TryParse(txtNo.Text, out _))
                {
                    MessageBox.Show("Nomor harus berupa angka", "Peringatan",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Bikin quey input ke database
                    conn.Open();
                    string query = "INSERT INTO pelanggan (Nama, NoWA) VALUES (@Nama, @NoWA)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@NoWA", txtNo.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear text box
                        txtNama.Clear();
                        txtNo.Clear();

                        // Berpindah ke form selanjutnya
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal disimpan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
