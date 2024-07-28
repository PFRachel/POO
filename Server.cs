using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Servidor
{
    class Server
    {
        static List<StreamWriter> clients = new List<StreamWriter>();
        static TcpListener? listener = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el puerto para el servidor:");
            int port = int.Parse(Console.ReadLine());

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine($"Servidor iniciado en el puerto {port}...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    StreamReader reader = new StreamReader(client.GetStream());

                    clients.Add(writer);

                    Thread thread = new Thread(() => HandleClient(client, reader, writer));
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                listener?.Stop();
            }
        }

        static void HandleClient(TcpClient client, StreamReader reader, StreamWriter writer)
        {
            string? nick = reader.ReadLine();
            Console.WriteLine($"{nick} se ha unido");

            try
            {
                while (client.Connected)
                {
                    string? msg = reader.ReadLine();
                    if (msg != null)
                    {
                        BroadcastMessage($"{nick}: {msg}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                clients.Remove(writer);
                client.Close();
            }
        }

        static void BroadcastMessage(string msg)
        {
            foreach (StreamWriter writer in clients)
            {
                writer.WriteLine(msg);
                writer.Flush();
            }
        }
    }
}
