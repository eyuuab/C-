using System;

public class Stopwatch
{
    public TimeSpan TimeElapsed { get; private set; }
    public bool IsRunning { get; private set; }

    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    public Stopwatch()
    {
        TimeElapsed = TimeSpan.Zero;
        IsRunning = false;
    }

    public delegate void StopwatchEventHandler(string message);

    public void Start()
    {
        if (IsRunning) return;
        IsRunning = true;
        OnStarted?.Invoke("Stopwatch Started!");
    }

    public void Stop()
    {
        if (!IsRunning) return;
        IsRunning = false;
        OnStopped?.Invoke("Stopwatch Stopped!");
    }
}