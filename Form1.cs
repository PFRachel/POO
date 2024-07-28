using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private NetworkStream stream;
        private StreamWriter streamw;
        private StreamReader streamr;
        private TcpClient client;
        private string nick;

        private delegate void DaddItem(String s);

        private void AddItem(String s)
        {
            listBox1.Items.Add(s);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    this.Invoke(new DaddItem(AddItem), streamr.ReadLine());
                }
                catch
                {
                    MessageBox.Show("No se ha podido conectar al servidor");
                    Application.Exit();
                }
            }
        }

        private void Conectar()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8000); // Cambia el puerto según sea necesario
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);
                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);
                    streamr = new StreamReader(stream);

                    streamw.WriteLine(nick);
                    streamw.Flush();

                    t.Start();
                }
                else
                {
                    MessageBox.Show("Servidor no Disponible");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servidor no Disponible");
                Application.Exit();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            nick = txtUsuario.Text;
            Conectar();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string targetPort = txtPuerto.Text;
            string message = txtMensaje.Text;

            streamw.WriteLine($"{targetPort}:{message}");
            streamw.Flush();
            txtMensaje.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnEnviar.Location = new Point(277, 250);
            txtMensaje.Location = new Point(25, 250);
            listBox1.Location = new Point(25, 23);
        }
    }
}
