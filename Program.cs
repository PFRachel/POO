using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Task.Run(() => {
            Server server9000 = new Server(9000);
            server9000.Start();
        });

        Task.Run(() => {
            Server server8000 = new Server(8000);
            server8000.Start();
        });

        Task.Delay(1000).Wait(); // Wait for the servers to start

        Client client1 = new Client("127.0.0.1", 9000);
        client1.SendMessage("Hello from Client 1");

        Client client2 = new Client("127.0.0.1", 8000);
        client2.SendMessage("Hello from Client 2");

        Console.ReadLine(); // Keep the main thread alive
    }
}
