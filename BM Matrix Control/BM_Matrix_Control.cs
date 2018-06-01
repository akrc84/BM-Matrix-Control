using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace BM_Matrix_Control
{
    public partial class BM_Matrix_Control : Form
    {
        public BM_Matrix_Control()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e1)
        {
            
            try
            {
                TcpClient client = new TcpClient("192.168.216.197", 9990);
                Byte[] data = Encoding.ASCII.GetBytes("VIDEO OUTPUT ROUTING:" + Environment.NewLine + "0" + " " + "4" + Environment.NewLine + Environment.NewLine);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[8086];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);

                textBox1.Text = responseData;

                // Close everything.
         //       stream.Close();
         //       client.Close();
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }

        private void BM_Matrix_Control_Load(object sender, EventArgs e)
        {

        }
    }
}
