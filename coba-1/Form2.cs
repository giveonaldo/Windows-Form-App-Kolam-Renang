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

        public Form2()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Set up panel selection behavior
            panel1.Click += Panel_Click;
            panel2.Click += Panel_Click;

            // Set up button
            btnBayar.Click += btnBayar_Click;

            // Initialize panel appearance
            panel1.BackColor = defaultColor;
            panel2.BackColor = defaultColor;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            // Reset previous selection
            if (selectedPanel != null)
            {
                selectedPanel.BackColor = defaultColor;
            }

            // Set new selection
            selectedPanel = sender as Panel;
            selectedPanel.BackColor = selectedColor;

            // Label warna
            lblReguler.ForeColor = Color.Black;
            lblMember.ForeColor = Color.Black;
            lblHarian.ForeColor = Color.Black;
            lblBulanan.ForeColor = Color.Black;
            lblPanel1.ForeColor = Color.Black;
            lblPanel2.ForeColor = Color.Black;
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null)
            {
                MessageBox.Show("Silakan pilih salah satu tiket terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = "";

            if (selectedPanel == panel1)
            {
                message = "Anda memilih:\n" +
                          "Jenis: Reguler\n" +
                          "Waktu: Harian\n" +
                          "Harga: Rp. 15,000";
            }
            else if (selectedPanel == panel2)
            {
                message = "Anda memilih:\n" +
                          "Jenis: Member\n" +
                          "Waktu: Bulanan\n" +
                          "Harga: Rp. 100,000";
            }

            MessageBox.Show(message, "Konfirmasi Tiket",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
