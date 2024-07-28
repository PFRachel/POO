using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Server
{
    private int port;
    private Dictionary<int, TcpClient> clients = new Dictionary<int, TcpClient>();

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
            Task.Run(() => HandleClient(client));
        }
    }

    private async Task HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string initialMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        int clientPort = int.Parse(initialMessage);

        lock (clients)
        {
            clients[clientPort] = client;
        }

        Console.WriteLine($"Client connected on port {clientPort}");

        while (true)
        {
            try
            {
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;

                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                string[] parts = message.Split(':');
                int targetPort = int.Parse(parts[0]);
                string actualMessage = parts[1];

                Console.WriteLine($"Received from {clientPort}: {actualMessage}");

                if (clients.ContainsKey(targetPort))
                {
                    TcpClient targetClient = clients[targetPort];
                    NetworkStream targetStream = targetClient.GetStream();
                    byte[] data = Encoding.ASCII.GetBytes(actualMessage);
                    await targetStream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                break;
            }
        }

        lock (clients)
        {
            clients.Remove(clientPort);
        }

        client.Close();
    }
}
