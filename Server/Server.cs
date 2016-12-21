using System;
using NetMQ;
using NetMQ.Sockets;

namespace Server
{
    internal class Server
    {
        static void Main()
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");

                Console.WriteLine("Original Pi number is: 3.141592653589793238462643383279502884...");

                Console.WriteLine("Please, enter duration in seconds for pi approximation calculation:");

                int seconds;

                bool validNumber = int.TryParse(Console.ReadLine(), out seconds);

                if (!validNumber)
                {
                    Console.WriteLine($"Entered input {seconds} is not number. Server shutdown.");

                    Environment.Exit(0);
                }

                Console.WriteLine("Waiting for client.");

                server.ReceiveFrameString();

                Console.WriteLine("Client is running. Sending duration to run for.");

                server.SendFrame($"{seconds}");

                string resultMessage = server.ReceiveFrameString();

                Console.WriteLine(resultMessage);

                Environment.Exit(0);
            }
        }
    }
}