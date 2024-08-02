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
    // Form1: Ventana principal de la aplicacion de chat.
    public partial class Form1 : Form
    {
        //Declara la variable socket para inicizalizarlo mas adelante
        private Socket? socket;
        //Declaracion de CancellationTokenSource que sirve para finalizar las tareas y cerrar el socket
        private CancellationTokenSource? cancellationTokenSource;
        //Puerto donde el socket va a escuchar los mensajes entantres
        private readonly int puertolocal;

        //Constructor de clase, inicializa los componentes de la parte grafica e inicializa el socket
        public Form1(int localPort)
        {
            //Llama la función para inicializar los componentes
            InitializeComponent();
            puertolocal = localPort;
            //Llama la función para inicializar el socket
            InicializarSocket();
        }
        //Inicialización y configuración del socket
        private void InicializarSocket()
        {
            try
            {
                // Crea un nuevo socket UDP. AddressFamily.InterNetwork: Ya que se va a utilizar direcciones ipv4
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                // Asocia el socket al puerto local escogido. IPAddress.Any permite recibir datos de cualquier dirección ip
                socket.Bind(new IPEndPoint(IPAddress.Any,puertolocal));
                // Muestra un mensaje de que se este escuchando en el puerto
                MessageBox.Show($"Escuchando el puerto: {puertolocal}");
                // Inicializa el CancellationTokenSource para poder detener la recepción de mensajes
                cancellationTokenSource = new CancellationTokenSource();
                //Se crea un hilo (tarea en segundo plano). Este hilo llama a la función RecibirMensajes y se repite hasta el momento que se le pase el token de cancelación.
                Task.Run(() => RecibirMensajes(cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si hay un problema 
                MessageBox.Show($"Error iniciando el socket: {ex.Message}");
            }
        }

        //Función para recibir mensajes desde el socket
        private void RecibirMensajes(CancellationToken cancellationToken)
        {
            // Bufer para almacenar los datos recibidos
            var buffer = new byte[1024];
            //punto de extremo que puede recibir mensajes en cualquier dirección IP (Any) y en cualquier puerto asignado automaticamente (0)
            var remoteEP = new IPEndPoint(IPAddress.Any, 0) as EndPoint;
            // Bucle para recibir mensajes constantemente hasta que se reciba el mensaje de cancelación
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                { 
                    // Recibe datos desde un punto de extremo remoto y los almacena en el bufer.
                    int recibido = socket?.ReceiveFrom(buffer, ref remoteEP) ?? 0;
                    //Pregunta si recibio algo
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
                    // El socket se cerró, sale del bucle
                    break;
                }
                catch (Exception)
                {
                    // Muestra un mensaje de error si hay un problema al inicializar el socket.
                    MessageBox.Show($"Error: Puerto Inválido");
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

        //Funcion asociada al botón de enviar
        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                //Convierte el texto del cuadro de texto de puerto en un numero entero.
                if (int.TryParse(textBoxPort.Text, out int remotePort))
                {
                    // Obtiene el mensaje del cuadro de texto
                    string message = textBoxMessage.Text;
                    // Convierte el mensaje en una serie de bytes UTF-8
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    // Define el punto de extremo remoto utilizando el puerto elegido
                    EndPoint remoteEP = new IPEndPoint(IPAddress.Loopback, remotePort);
                    //Envia el mensaje por el socket
                    socket?.SendTo(data, remoteEP);
                    MostrarMensajes($"De {puertolocal}: {message}");
                    // Limpia el cuadro de texto de mensaje
                    textBoxMessage.Clear();
                }
                else
                {
                    MessageBox.Show("Puerto inv�lido");
                }
            }
            catch (Exception ex)
            {

                // Muestra un mensaje de error si hay un problema al inicializar el socket.
                MessageBox.Show($"Error enviando el mensaje: {ex.Message}");
            }
        }



        private void StopListening()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                socket?.Shutdown(SocketShutdown.Both);
                socket?.Close();
                socket = null; //  asigna el socket como nulo 
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si hay un problema al inicializar el socket.
                MostrarMensajes($"Error deteniendo la escucha: {ex.Message}");
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
