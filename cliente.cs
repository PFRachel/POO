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

    public async Task StartAsync()
    {
        TcpClient client = new TcpClient();
        await client.ConnectAsync(server, port);
        NetworkStream stream = client.GetStream();

        byte[] initialData = Encoding.ASCII.GetBytes(port.ToString());
        await stream.WriteAsync(initialData, 0, initialData.Length);

        _ = Task.Run(async () => await ReceiveMessages(stream));

        while (true)
        {
            Console.Write("Enter target port and message (format: port:message): ");
            string input = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(input);
            await stream.WriteAsync(data, 0, data.Length);
        }
    }

    private async Task ReceiveMessages(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 0) break;

            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received: {message}");
        }
    }
}
