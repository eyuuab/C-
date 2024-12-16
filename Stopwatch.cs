using System;

public class Stopwatch
{
    // Delegate for stopwatch events
    public delegate void StopwatchEventHandler(string message);

    // Events
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    // Fields
    private TimeSpan timeElapsed;
    private DateTime startTime;
    private bool isRunning;

    // Properties
    public TimeSpan TimeElapsed => timeElapsed;
    public bool IsRunning => isRunning;

    // Constructor
    public Stopwatch()
    {
        timeElapsed = TimeSpan.Zero;
        isRunning = false;
    }

    // Start method
    public void Start()
    {
        if (!isRunning)
        {
            startTime = DateTime.Now;
            isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
        }
    }

    // Stop method
    public void Stop()
    {
        if (isRunning)
        {
            timeElapsed += DateTime.Now - startTime;
            isRunning = false;
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
    }

    // Reset method
    public void Reset()
    {
        timeElapsed = TimeSpan.Zero;
        isRunning = false;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    // Tick method to get current elapsed time
    public TimeSpan Tick()
    {
        if (isRunning)
        {
            return timeElapsed + (DateTime.Now - startTime);
        }
        return timeElapsed;
    }
}
