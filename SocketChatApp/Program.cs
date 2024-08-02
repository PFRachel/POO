using System;
using System.Windows.Forms;

namespace SocketChatApp
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            //Configuraciones de la ventana
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Verifica los argumentos de la linea de comandos.
            // Asegurate de que hay al menos 2 argumentos y que el primer argumento es "-port" y el segundo es un numero de puerto valido.
            if (args.Length < 2 || args[0] != "-port" || !int.TryParse(args[1], out int port))
            {
                MessageBox.Show("El formato debe ser: dotnet run --project <nombre-del-proyecto> -port <puerto-escucha>");
                return;
            }

            // Inicia la aplicacion con un nuevo formulario `Form1`, pasando el puerto como argumento al constructor.
            Application.Run(new Form1(port));
        }
    }
}
