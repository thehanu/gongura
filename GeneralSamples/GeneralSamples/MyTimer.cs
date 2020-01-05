using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GeneralSamples
{
    class MyTimer
    {
        private static Timer aTimer;
        public static readonly TimeSpan PartitioningClientTimerToReadPPMConfiguration = TimeSpan.FromMinutes(1);

        public static void TestTimer()
        {
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(PartitioningClientTimerToReadPPMConfiguration.TotalMilliseconds);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }
}
