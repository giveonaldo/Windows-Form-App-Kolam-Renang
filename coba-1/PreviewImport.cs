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
    public partial class PreviewImport : Form
    {
        string connectionString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_;Integrated Security=True";
        public PreviewImport(DataTable data)
        {
            InitializeComponent();
            dgvPreviewdata.DataSource = data;
        }

        private void dgvPreviewdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPreviewdata.AutoResizeColumns();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ini ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {            
                ImportDataToDatabase();
            }
        }

        private bool ValidateRow(DataRow row)
        {
            string nowa = row["NoWA"].ToString().Trim();

            // Cek panjang minimal dan maksimal
            if (nowa.Length < 11 || nowa.Length > 13)
            {
                MessageBox.Show($"Nomor WA \"{nowa}\" harus terdiri dari 11–13 angka.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Pastikan hanya angka
            if (!nowa.All(char.IsDigit))
            {
                MessageBox.Show($"Nomor WA \"{nowa}\" hanya boleh berisi angka.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void ImportDataToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPreviewdata.DataSource;

                foreach (DataRow row in dt.Rows)
                {
                    // Validasi setiap baris sebelum diimpor
                    if (!ValidateRow(row))
                    
                    {
                        // Jika validasi gagal, lanjutkan ke baris berikutnya
                        continue; // Lewati baris ini jika tidak valid
                    }

                    string query = "INSERT INTO [user] (Nama, NoWA) VALUES ( @Nama, @NoWA)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            
                            cmd.Parameters.AddWithValue("@Nama", row["Nama"]);
                            cmd.Parameters.AddWithValue("@NoWA", row["NoWA"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Data berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Tutup PreviewForm setelah data diimpor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     }
}
