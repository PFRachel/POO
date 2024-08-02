using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace SocketChatApp
{
    // Form1: Ventana principal de la aplicaci�n de chat.
    public partial class Form1 : Form
    {
        //Declara la variable socket para inicizalizarlo m�s adelante
        private Socket? socket;
        //Declaraci�n de CancellationTokenSource que sirve para finalizar las tareas y cerrar el socket
        private CancellationTokenSource? cancellationTokenSource;
        //Puerto donde el socket va a escuchar los mensajes entantres
        private readonly int puertolocal;

        //Constructor de clase, inicializa los componentes de la parte gr�fica e inicializa el socket
        public Form1(int localPort)
        {
            //Llama la funci�n para inicializar los componentes
            InitializeComponent();
            puertolocal = localPort;
            //Llama la funci�n para inicializar el socket
            InicializarSocket();
        }
        //Inicializaci�n y configuraci�n del socket
        private void InicializarSocket()
        {
            try
            {
                // Crea un nuevo socket UDP. AddressFamily.InterNetwork: Ya que se va a utilizar direcciones ipv4
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                // Asocia el socket al puerto local escogido. IPAddress.Any permite recibir datos de cualquier direcci�n ip
                socket.Bind(new IPEndPoint(IPAddress.Any,puertolocal));
                // Muestra un mensaje de que se est� escuchando en el puerto
                MessageBox.Show($"Escuchando el puerto: {puertolocal}");
                // Inicializa el CancellationTokenSource para poder detener la recepci�n de mensajes
                cancellationTokenSource = new CancellationTokenSource();
                //Se crea un hilo (tarea en segundo plano). Este hilo llama a la funci�n RecibirMensajes y se repite hasta el momento que se le pase el token de cancelaci�n.
                Task.Run(() => RecibirMensajes(cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si hay un problema 
                MessageBox.Show($"Error iniciando el socket: {ex.Message}");
            }
        }

        //Funci�n para recibir mensajes desde el socket
        private void RecibirMensajes(CancellationToken cancellationToken)
        {
            // B�fer para almacenar los datos recibidos
            var buffer = new byte[1024];
            //punto de extremo que puede recibir mensajes en cualquier direcci�n IP (Any) y en cualquier puerto asignado autom�ticamente (0)
            var remoteEP = new IPEndPoint(IPAddress.Any, 0) as EndPoint;
            // Bucle para recibir mensajes constantemente hasta que se reciba el mensaje de cancelaci�n
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                { 
                    // Recibe datos desde un punto de extremo remoto y los almacena en el b�fer.
                    int recibido = socket?.ReceiveFrom(buffer, ref remoteEP) ?? 0;
                    //Pregunta si recibi� algo
                    if (recibido > 0)
                    {
                        /// Convierte los bytes recibidos en una cadena de texto UTF-8.
                        string mensaje = Encoding.UTF8.GetString(buffer, 0, recibido);

                        // Si el punto de extremo remoto es un IPEndPoint, obtiene el puerto y muestra el mensaje recibido.
                        if (remoteEP is IPEndPoint remoteIPEndPoint)
                        {
                            int remotePort = remoteIPEndPoint.Port;
                            MostrarMensajes($"De {remotePort}: {mensaje}");
                        }
                    }
                }
                catch (ObjectDisposedException)
                {
                    // El socket se cerr�, sale del bucle
                    break;
                }
                catch (Exception)
                {
                    // Muestra un mensaje de error si hay un problema al inicializar el socket.
                    MessageBox.Show($"Error: Puerto Inv�lido");
                }
            }
        }

        // Muestra un mensaje recibido en el cuadro de texto de la interfaz de usuario.
        private void MostrarMensajes(string mensaje)
        {
            if (textBoxReceived.InvokeRequired)
            {
                //Se usa invoke para actualizar el hilo principal
                textBoxReceived.Invoke(new Action(() => textBoxReceived.AppendText(mensaje + Environment.NewLine)));
            }
            else
            {
                textBoxReceived.AppendText(mensaje + Environment.NewLine);
            }
        }
        }
        //Detiene la escucha cuando se cierra el programa
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListening();
        }

        //Esto es de la interfaz
        private void textBoxReceived_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}