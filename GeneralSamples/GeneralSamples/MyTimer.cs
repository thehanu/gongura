using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GeneralSamples
{
    class MyTimer
    {
        private static System.Timers.Timer aTimer;
        public static readonly TimeSpan myTimeSpan = TimeSpan.FromSeconds(8);

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
            aTimer = new System.Timers.Timer(myTimeSpan.TotalMilliseconds);
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

    class MyThreadingTimer
    {
        private static System.Threading.Timer aTimer;
        private static System.Threading.Timer aSyncTimer;
        public static readonly TimeSpan myTimeSpan = TimeSpan.FromSeconds(2);

        public static void TestTimer()
        {
            SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine($"The application started at {DateTime.Now}");
            Console.ReadLine(); 
            
            if(aTimer != null)
            {
                aTimer.Dispose();
            }            
            aSyncTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            // aTimer = new System.Threading.Timer(OnTimedEvent, null, (int)myTimeSpan.TotalMilliseconds, (int)myTimeSpan.TotalMilliseconds);
            aSyncTimer = new System.Threading.Timer(OnTimedEventInternal, null, myTimeSpan, myTimeSpan);         
        }

        private static void OnTimedEvent(Object state)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"On Timed Event triggered with state: {state} at: {dateTime}");
        }

        private static void OnTimedEventInternal(Object state)
        {
            aSyncTimer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                OnTimedEventAsync(state).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception happened during on timed event async call: {ex}");
            }
            finally
            {
                TimeSpan timeSpan = TimeSpan.FromMinutes(15);
                Console.WriteLine($"Setting back the timer original values... {myTimeSpan}, test TimeSpan: {timeSpan}");
                aSyncTimer.Change(myTimeSpan, myTimeSpan);
            }
        }

        private static async Task OnTimedEventAsync(Object state)
        {
            System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
            Console.WriteLine($"Current Thread Id:{currentThread.ManagedThreadId}, Priority: {currentThread.Priority}, Bacgground: {currentThread.IsBackground}, Thread Pool: {currentThread.IsThreadPoolThread}");

            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"ASYNC - On Timed Event triggered Thread Id:{currentThread.ManagedThreadId} with state: {state} at: {dateTime}");
            await Task.Delay(5000);
            Console.WriteLine($"---- ---- On Timed Event completed Thread Id:{currentThread.ManagedThreadId} with state: {state} at: {dateTime}");
        }
    }
}
