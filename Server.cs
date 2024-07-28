using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Server
{
    private int port;
    private TcpListener listener;
    private Dictionary<int, TcpClient> clients = new Dictionary<int, TcpClient>();

    public Server(int port)
    {
        this.port = port;
    }

    public void Start()
    {
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Server started on port {port}");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    private void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        StreamReader reader = new StreamReader(stream);
        StreamWriter writer = new StreamWriter(stream);

        int clientPort = int.Parse(reader.ReadLine());
        lock (clients)
        {
            clients[clientPort] = client;
        }

        while (true)
        {
            try
            {
                string message = reader.ReadLine();
                string[] parts = message.Split(':');
                int targetPort = int.Parse(parts[0]);
                string text = parts[1];

                lock (clients)
                {
                    if (clients.ContainsKey(targetPort))
                    {
                        StreamWriter targetWriter = new StreamWriter(clients[targetPort].GetStream());
                        targetWriter.WriteLine($"{clientPort}: {text}");
                        targetWriter.Flush();
                    }
                }
            }
            catch
            {
                lock (clients)
                {
                    clients.Remove(clientPort);
                }
                client.Close();
                break;
            }
        }
    }

    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: dotnet run <port>");
            return;
        }

        int port = int.Parse(args[0]);
        Server server = new Server(port);
        server.Start();
    }
}
