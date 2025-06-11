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
            // Connection string to your database
            string connectionString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_pacific_;Integrated Security=True";

            // SQL query to retrieve the required data from the database
            string query = @"
        SELECT
            TransaksiID,
            PelangganID,
            TiketID,
            TanggalBeli,
            MetodePembayaran,
            Status
        FROM
            transaksi";

            // Create a DataTable to store the data
            DataTable dt = new DataTable();

            // Use SqlDataAdapter to fill the DataTable with data from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            // Create a ReportDataSource
            ReportDataSource rds = new ReportDataSource("transaksi", dt); // Make sure "DataSet1" matches your RDLC dataset name

            // Clear any existing data sources and add the new data source
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Set the path to the report (.rdlc file)
            // Change this to the actual path of your RDLC file
            reportViewer1.LocalReport.ReportPath = @"D:\Windows-Form-App-Kolam-Renang\coba-1\TransaksiReport.rdlc";

            // Refresh the ReportViewer to show the updated report
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
