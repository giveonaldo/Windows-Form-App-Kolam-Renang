using MySqlConnector;
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
    public partial class Form3 : Form
    {
        static string connString = "server=localhost; database=kolam_renang_pacific; uid=root; pwd=;";
        public Form3()
        {
            InitializeComponent();
            LoadTransaksi();
        }

        private void LoadTransaksi()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string query = "SELECT * FROM transaksi";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvTable.AutoGenerateColumns = true;
                dgvTable.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = dgvTable.Rows[e.RowIndex];
        //        string id = row.Cells[0].Value.ToString();
        //        string nama = row.Cells[1].Value.ToString();
        //        string harga = row.Cells[2].Value.ToString();
        //    }
        //}

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnTiket_Click(object sender, EventArgs e)
        {
            Tiket tiket = new Tiket();
            tiket.Show();
            this.Hide();
        }
    }
}
