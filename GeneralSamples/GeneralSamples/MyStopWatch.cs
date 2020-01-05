using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyStopWatch
    {
        public static void TestStartStop()
        {
            Console.WriteLine("Starting stopwatch...");
            Stopwatch sw = Stopwatch.StartNew();

            // Wait for 5 seconds.
            Task.Delay(5000).Wait();
            sw.Stop();
            Console.WriteLine($"StopWatch Elapsed MS after 5 seconds of sleep: {sw.ElapsedMilliseconds}");

            // Wait for another 5 seconds.
            sw.Start();
            Task.Delay(5000).Wait();
            sw.Stop();
            Console.WriteLine($"StopWatch Elapsed MS after 5 more seconds of sleep: {sw.ElapsedMilliseconds}");

            // Wait for another 5 seconds.
            sw.Start();
            Task.Delay(5000).Wait();
            sw.Stop();
            Console.WriteLine($"StopWatch Elapsed MS after 5 more seconds of sleep: {sw.ElapsedMilliseconds}");
        }
    }
}
