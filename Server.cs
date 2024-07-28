public class Server
{
    public void Start()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Server started on port {port}");

        while (true)
        {
            // Obtenemos nuestro cliente
            TcpClient client = listener.AcceptTcpClient();

            // Obtenemos todo lo necesario para codificar el mensaje entrante
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // Imprimimos el mensaje
            Console.WriteLine($"Received: {message}");

            // Echo the message back to the client
            stream.Write(buffer, 0, bytesRead);

            client.Close();
        }
    }
}
