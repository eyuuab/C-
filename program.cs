using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += HandleStarted;
        stopwatch.OnStopped += HandleStopped;
        stopwatch.OnReset += HandleReset;

        Console.WriteLine("Stopwatch Console Application");
        Console.WriteLine("Commands:");
        Console.WriteLine("S - Start");
        Console.WriteLine("T - Stop");
        Console.WriteLine("R - Reset");
        Console.WriteLine("Q - Quit");

        while (true)
        {
            // Display current time
            if (stopwatch.IsRunning)
            {
                Console.SetCursorPosition(0, 6);
                Console.Write($"Current Time: {TimeFormatter.FormatTime(stopwatch.Tick())}   ");
            }

            // Check for user input
            if (Console.KeyAvailable)
            {
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
                        return;
                }
            }

            // Small sleep to prevent high CPU usage
            Thread.Sleep(100);
        }
    }

    // Event handler methods
    static void HandleStarted(string message)
    {
        Console.WriteLine(message);
    }

    static void HandleStopped(string message)
    {
        Console.WriteLine(message);
    }

    static void HandleReset(string message)
    {
        Console.WriteLine(message);
    }
}