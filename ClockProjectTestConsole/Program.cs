using System;
using ClockProject;

namespace ClockProjectTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            Listener listener = new Listener();
            listener.Register(timer);

            timer.SetNewTimer(5000);
        }
    }
}
