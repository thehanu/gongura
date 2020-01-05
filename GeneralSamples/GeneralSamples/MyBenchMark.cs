using System;
using System.Diagnostics;

namespace GeneralSamples
{
    class MyBenchMark
    {
        public static void PerformBenchMarks()
        {
            BenchMarkTickCount(10000000);
            BenchMarkDateTimeNow(10000000);
            BenchMarkStopwatch(10000000);
        }
        static void BenchMarkTickCount(int c)
        {
            var sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            for (var i = 0; i < c; i++)
            {
                sum += Environment.TickCount;
            }
            sw.Stop();
            Console.WriteLine("Test1 " + c + ": " + sw.ElapsedMilliseconds + "   (ignore: " + sum + ")");
        }

        static void BenchMarkDateTimeNow(int c)
        {
            var sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            for (var i = 0; i < c; i++)
            {
                sum += DateTime.Now.Ticks;
            }
            sw.Stop();
            Console.WriteLine("Test2 " + c + ": " + sw.ElapsedMilliseconds + "   (ignore: " + sum + ")");
        }
        static void BenchMarkStopwatch(int c)
        {
            var sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < c; i++)
            {
                sum += stopwatch.ElapsedMilliseconds;
            }
            sw.Stop();
            Console.WriteLine("Test3 " + c + ": " + sw.ElapsedMilliseconds + "   (ignore: " + sum + ")");
        }
    }
}
