using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace coba_1
{
    internal class Koneksi
    {
        public string connectionString() // untuk membangun dan mengembalikan string koneksi ke database
        {
            string connectStr = "";
            try
            {
                string localIP = GetLocalIPAddress(); // mendeklarasikan ipaddress
                connectStr = $"Server={localIP};Initial Catalog=kolam_renang_;" +
                             $"Integrated Security=True;";

                return connectStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public static string GetLocalIPAddress() // untuk mengambil IP Address pada PC yang menjalankan aplikasi
        {
            // mengambil informasi tentang local host
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) // Mengambil IPv4
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Tidak ada alamat IP yang ditemukan.");
        }
    }
}
