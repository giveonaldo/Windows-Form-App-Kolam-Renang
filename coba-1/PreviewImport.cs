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
        string connectionString = "Data Source=DESKTOP-UMBBMDS\\MSSQLSERVER01;Initial Catalog=kolam_renang;Integrated Security=True;";
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
            string nowa = row["NoWA"].ToString();

            
            if (nowa.Length != 11)
            {
                MessageBox.Show("Nomor harus terdiri dari 11-13 Angka.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Jika perlu, tambahkan validasi lain sesuai dengan kebutuhan (misalnya, pola tertentu untuk NIM)

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

                    string query = "INSERT INTO [user] (PelangganID, Nama, NoWA, CreatedAt) VALUES (@PelangganID, @Nama, @NoWA, @CreatedAt)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@PelangganID", row["PelangganID"]);
                            cmd.Parameters.AddWithValue("@Nama", row["Nama"]);
                            cmd.Parameters.AddWithValue("@NoWA", row["NoWA"]);
                            cmd.Parameters.AddWithValue("@CreatedAt", row["CreatedAt"]);
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
