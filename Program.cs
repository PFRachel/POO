using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: dotnet run <server|client> <port>");
            return;
        }

        string mode = args[0].ToLower();
        int port = int.Parse(args[1]);

        if (mode == "server")
        {
            Server server = new Server(port);
            server.Start();
        }
        else if (mode == "client")
        {
            string serverAddress = "127.0.0.1";
            Client client = new Client(serverAddress, port);

            Task.Run(() => client.ReceiveMessages());

            while (true)
            {
                Console.Write("Enter target port and message (format: <port>:<message>): ");
                string input = Console.ReadLine();
                string[] parts = input.Split(':');
                if (parts.Length < 2) continue;

                int targetPort = int.Parse(parts[0]);
                string message = parts[1];

                client.SendMessage(message, targetPort);
            }
        }
        else
        {
            Console.WriteLine("Invalid mode. Use 'server' or 'client'.");
        }
    }
}
