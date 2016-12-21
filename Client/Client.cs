using System;
using Client.Domain;
using NetMQ;
using NetMQ.Sockets;

namespace Client
{
    internal class Client
    {
        static void Main()
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");

                Console.WriteLine("Client is running.");

                Console.WriteLine("Sending server a message.");

                client.SendFrame("Client is running.");

                int durationInSeconds = int.Parse(client.ReceiveFrameString());

                Console.WriteLine($"Client is running pi approximation calculation for {durationInSeconds} seconds.");

                IPiCalculationMethod leibnizMethod = new LeibnizMethod();

                leibnizMethod.Calculate(durationInSeconds);

                Console.WriteLine("Pi approximation calculation is done. Sending results to server.");

                client.SendFrame($"Pi result: {leibnizMethod.GetResult()}");
            }

            Console.WriteLine("Client job is done. Exit.");

            Environment.Exit(0);
        }
    }
}
