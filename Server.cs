using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    private int port;

    public Server(int port)
    {
        this.port = port;
    }

    public void Start()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Server started on port {port}");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received: {message}");

            stream.Write(buffer, 0, bytesRead);
            client.Close();
        }
    }
}
