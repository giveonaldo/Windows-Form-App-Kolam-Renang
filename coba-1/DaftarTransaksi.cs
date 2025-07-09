using MySqlConnector;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace coba_1
{
    public partial class DaftarTransaksi : Form
    {
        Koneksi kn = new Koneksi();
        string connString = "Data Source=MSI\\WILDAN_INDI;" + "Initial Catalog=kolam_renang_;Integrated Security=True";
        public DaftarTransaksi()
        {
            InitializeComponent();
            LoadTransaksi();
            LoadChartTransaksi();
        }

        private void LoadTransaksi()
        {
            using (SqlConnection conn = new SqlConnection(kn.connectionString()))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllTransaksi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTable.AutoGenerateColumns = true;
                        dgvTable.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnTiket_Click(object sender, EventArgs e)
        {
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Hide();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            DaftarPelanggan daftarPelanggan = new DaftarPelanggan();
            daftarPelanggan.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportTransaksi reportTransaksi = new ReportTransaksi();
            reportTransaksi.Show();
            this.Hide();
        }


        

        private void LoadChartTransaksi()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetTransaksiChart", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        chartTransaksi.Series.Clear();
                        chartTransaksi.ChartAreas[0].AxisX.Title = "Jenis Tiket";
                        chartTransaksi.ChartAreas[0].AxisY.Title = "Jumlah Pembelian";

                        Series series = new Series("Pembelian");
                        series.ChartType = SeriesChartType.Column;

                        foreach (DataRow row in dt.Rows)
                        {
                            string jenis = row["Jenis"].ToString();
                            int jumlah = Convert.ToInt32(row["JumlahPembelian"]);
                            series.Points.AddXY(jenis, jumlah);
                        }

                        chartTransaksi.Series.Add(series);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading chart: " + ex.Message);
                }
            }
        }
    }
}
