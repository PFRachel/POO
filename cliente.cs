using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    private string server;
    private int port;

    public Client(string server, int port)
    {
        this.server = server;
        this.port = port;
    }

    public void SendMessage(string message)
    {
        // Crear cliente con el servidor y el puerto
        TcpClient client = new TcpClient(server, port);
        NetworkStream stream = client.GetStream();

        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine($"Sent: {message}");

        // Receive response from server
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Received: {response}");

        client.Close();
    }
}
