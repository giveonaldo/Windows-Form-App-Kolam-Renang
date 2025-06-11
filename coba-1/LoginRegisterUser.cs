
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
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_;Integrated Security=True";
        public LoginRegisterUser()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string nowa = txtNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nowa))
            {
                MessageBox.Show("Harap mengisi form terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_ProcessUserLoginOrRegister", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@NoWA", nowa);

                    // Output parameters
                    SqlParameter resultParam = new SqlParameter("@ActionResult", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255);
                    messageParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(messageParam);

                    cmd.ExecuteNonQuery();

                    int actionResult = (int)resultParam.Value;
                    string message = messageParam.Value.ToString();

                    MessageBox.Show(message,
                        actionResult == 1 ? "Sukses" :
                        actionResult == 2 ? "Informasi" : "Peringatan",
                        MessageBoxButtons.OK,
                        actionResult > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (actionResult > 0)
                    {
                        txtNama.Clear();
                        txtNo.Clear();
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
