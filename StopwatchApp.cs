using System;
using System.Threading;

class StopwatchApp
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.OnStarted += (message) => Console.WriteLine(message);
        stopwatch.OnStopped += (message) => Console.WriteLine(message);
        stopwatch.OnReset += (message) => Console.WriteLine(message);

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Stopwatch App");
            Console.WriteLine("Press 'S' to Start, 'T' to Stop, 'R' to Reset, 'Q' to Quit");
            Console.WriteLine($"Time Elapsed: {stopwatch.TimeElapsed}");

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.S:
                    stopwatch.Start();
                    break;
                case ConsoleKey.T:
                    stopwatch.Stop();
                    break;
                case ConsoleKey.R:
                    stopwatch.Reset();
                    break;
                case ConsoleKey.Q:
                    running = false;
                    break;
            }


            if (stopwatch.IsRunning)
            {
                stopwatch.Tick();
                Thread.Sleep(1000);  
            }
        }
    }
}
