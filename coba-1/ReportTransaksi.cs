using Microsoft.Reporting.WinForms;
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
    public partial class ReportTransaksi : Form
    {
        public ReportTransaksi()
        {
            InitializeComponent();
        }

        private void ReportTransaksi_Load(object sender, EventArgs e)
        {
            SetupReportViewer();
            this.reportViewer1.RefreshReport();
           
        }

        private void SetupReportViewer()
        {
            // Connection string ke database
            string connectionString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_;Integrated Security=True";

            // Nama stored procedure
            string storedProcedureName = "sp_GetTransaksiReport";

            // Membuat DataTable untuk menampung data
            DataTable dt = new DataTable();

            // Menggunakan SqlDataAdapter untuk memanggil stored procedure dan mengisi DataTable
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            // Buat ReportDataSource dan pastikan nama "transaksi" sama dengan nama dataset di RDLC
            ReportDataSource rds = new ReportDataSource("ExportTransaksi", dt);

            // Bersihkan data source lama dan tambahkan data source baru
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Tentukan path ke file RDLC
            reportViewer1.LocalReport.ReportPath = @"D:\Windows-Form-App-Kolam-Renang\coba-1\TransaksiReport.rdlc";

            // Refresh untuk menampilkan laporan
            reportViewer1.RefreshReport();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            DaftarTransaksi daftarTransaksi = new DaftarTransaksi();
            daftarTransaksi.Show();
            this.Hide();
        }
    }
}
