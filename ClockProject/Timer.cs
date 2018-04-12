using System;
using System.Threading;

namespace ClockProject
{
    public class Timer
    {
        public event EventHandler<TimeEndedEventArgs> TimeEnded;

        public void SetNewTimer(int miliseconds)
        {
            Console.WriteLine($"Timer set on {miliseconds} miliseconds");
            OnTimeEnded(this, new TimeEndedEventArgs(miliseconds));
            Console.WriteLine("Execution ended");
        }

        protected virtual void OnTimeEnded(object source, TimeEndedEventArgs e)
        {
            TimeEnded?.Invoke(this, e);
        }
    }

    public sealed class TimeEndedEventArgs : EventArgs
    {
        private int miliseconds;
        public int Miliseconds
        {
            get { return miliseconds; }
        }

        public TimeEndedEventArgs(int miliseconds)
        {
            this.miliseconds = miliseconds;
        }
    }

    public sealed class Listener
    {
        public Listener() { }

        public void Register(Timer timer)
        {
            timer.TimeEnded += WaitTime;
        }

        public void Unregister(Timer timer)
        {
            timer.TimeEnded -= WaitTime;
        }

        public void WaitTime(object source, TimeEndedEventArgs eventArgs)
        {
            Thread.Sleep(eventArgs.Miliseconds);
        }
    }
}
