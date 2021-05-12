using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
namespace Server
{
    class Program
    {
        static int port = 8005;
        static int players = 2;
        static IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        static List<Socket> sockets = new List<Socket>();
        static Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.WriteLine("Number of players...");
            int.TryParse(Console.ReadLine(), out players);
            try
            {
                listenSocket.Bind(ipPoint);

                ConnectPlayers();
                Console.WriteLine("Settings up...");
                while (true)
                {
                    UpdateSocketsInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ConnectPlayers()
        {
            Console.WriteLine("Connecting players...");
            listenSocket.Listen(players);
            while (sockets.Count < players)
                sockets.Add(listenSocket.Accept());
        }
        static void ReSendData(byte[] data, Socket socket)
        {
            foreach (var player in sockets)
            {
                if (player != socket)
                    socket.Send(data);
            }
        }
        static (byte[], int) ListenSocketReceive(Socket player)
        {

            byte[] data = new byte[512];
            int bytes = 0;
            do
            {
                bytes = player.Receive(data, data.Length, 0);
            }
            while (player.Available > 0);
            return (data, bytes);
        }
        static void UpdateSocketsInfo()
        {
            foreach (var socket in sockets)
            {
                if (socket.Available > 0)
                    ReSendData(ListenSocketReceive(socket).Item1, socket);
            }
        }
    }
}
