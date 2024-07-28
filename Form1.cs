using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private NetworkStream? stream;
        private StreamWriter? streamw;
        private StreamReader? streamr;
        private TcpClient? client;

        private delegate void DaddItem(string s);

        private void AddItem(string s)
        {
            listBox1.Items.Add(s);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Listen()
        {
            while (client?.Connected == true)
            {
                try
                {
                    this.Invoke(new DaddItem(AddItem), streamr?.ReadLine() ?? string.Empty);
                }
                catch
                {
                    MessageBox.Show("No se ha podido conectar al servidor");
                    Application.Exit();
                }
            }
        }

        private void Conectar(string targetPort)
        {
            try
            {
                int port = int.Parse(targetPort);
                client = new TcpClient("127.0.0.1", port);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);
                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);
                    streamr = new StreamReader(stream);

                    t.Start();
                }
                else
                {
                    MessageBox.Show("Servidor no Disponible");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Servidor no Disponible");
                Application.Exit();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string targetPort = txtPuertoDestino.Text;
            string message = txtMensaje.Text;

            if (client == null || !client.Connected)
            {
                Conectar(targetPort);
            }

            streamw?.WriteLine(message);
            streamw?.Flush();
            txtMensaje.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnEnviar.Location = new Point(360, 350);
            txtMensaje.Location = new Point(25, 350);
            listBox1.Location = new Point(25, 20);
            txtPuertoDestino.Location = new Point(80, 310);
            lbPuertoDestino.Location = new Point(25, 313);
        }
    }
}
