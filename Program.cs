using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Uso: dotnet run <server|client> <puerto>");
            return;
        }

        string mode = args[0];
        int port = int.Parse(args[1]);

        if (mode == "server")
        {
            Server server = new Server(port);
            server.Start();
        }
        else if (mode == "client")
        {
            Client client = new Client("127.0.0.1", port);
            await client.StartAsync();
        }
        else
        {
            Console.WriteLine("Modo no válido. Usa 'server' o 'client'.");
        }
    }
}
