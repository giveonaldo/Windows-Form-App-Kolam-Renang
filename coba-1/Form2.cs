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
    public partial class Form2: Form
    {
        private Panel selectedPanel = null;
        private readonly Color selectedColor = Color.DarkCyan;
        private readonly Color defaultColor = Color.LightBlue;

        // Initialize MySqlConnection
        static string connString = "server=localhost; database=kolam_renang_pacific; uid=root; pwd=;";

        public Form2()
        {
            InitializeComponent();
            LoadTiket();
        }

        private void LoadTiket()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string query = "SELECT Jenis, Harga, Durasi FROM tiket";
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

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count > 0)
            {
                Application.Exit();
            } else
            {
                MessageBox.Show("Silakan pilih salah satu tiket terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTable.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();
                string nama = row.Cells[1].Value.ToString();
                string harga = row.Cells[2].Value.ToString();
            }
        }
    }
}
