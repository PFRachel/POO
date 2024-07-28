using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client
{
    private string server;
    private int port;

    public Client(string server, int port)
    {
        this.server = server;
        this.port = port;
    }

    public void SendMessage(string message, int targetPort)
    {
        TcpClient client = new TcpClient(server, targetPort);
        NetworkStream stream = client.GetStream();

        string formattedMessage = $"{port}:{message}";
        byte[] data = Encoding.ASCII.GetBytes(formattedMessage);
        stream.Write(data, 0, data.Length);
        Console.WriteLine($"Sent to {targetPort}: {message}");

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Received: {response}");

        client.Close();
    }

    public async Task ReceiveMessages()
    {
        TcpClient client = new TcpClient(server, port);
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 0) break;

            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received: {message}");
        }

        client.Close();
    }
}
