using System;
using System.Timers;

namespace Client.Domain
{
    public class LeibnizMethod : IPiCalculationMethod
    {
        private double _piResult;

        private static bool IsRunning { get; set; } = true;

        public void Calculate(int durationInSeconds)
        {
            Console.WriteLine("Leibniz method Pi calculation started.");

            double currentPi = 1;

            long nextNumber = 1;

            var resultRefresher = new Timer();

            resultRefresher.Interval = 1000;

            resultRefresher.Elapsed += (sender, args) =>
            {
                Console.Write("\r{0}", currentPi * 4);
            };

            resultRefresher.Start();

            var stopTimer = new Timer();
            
            stopTimer.Interval = durationInSeconds * 1000;

            stopTimer.Elapsed += (sender, args) =>
            {
                IsRunning = false;
            };

            stopTimer.Start();

            while (IsRunning)
            {
                nextNumber += 2;

                currentPi -= 1d / nextNumber;

                nextNumber += 2;

                currentPi += 1d / nextNumber;
            }

            _piResult = currentPi * 4;

            Console.WriteLine(string.Empty);

            Console.WriteLine($"Pi = {_piResult}");

            Console.WriteLine($"Accuracy resulting from approximately {Math.Round(nextNumber / 4d).ToString("#,##0")} steps");

            Console.WriteLine($"Calculation time {TimeSpan.FromMilliseconds(stopTimer.Interval)}");
        }

        public double GetResult()
        {
            return _piResult;
        }
    }
}
