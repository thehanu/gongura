using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyTask
    {
        public async Task<bool> ProcessWorkAsync()
        {
            for(int i = 0; i < 10; i++)
            {
                // for(int j = 0; j< 500000; j++) { DateTime dt = DateTime.Now;  }
                System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
                await Task.Delay(1000);
                Console.WriteLine($"Slept a second for {i} times under Thread Name:{currentThread.ManagedThreadId}, Priority: {currentThread.Priority}, Bacgground: {currentThread.IsBackground}, Thread Pool: {currentThread.IsThreadPoolThread}");
            }
            return true;
        }

        public static async Task PerformAsnycMethod()
        {
            System.Threading.Thread currentThread = System.Threading.Thread.CurrentThread;
            Console.WriteLine($"Current Thread Id:{currentThread.ManagedThreadId}, Priority: {currentThread.Priority}, Bacgground: {currentThread.IsBackground}, Thread Pool: {currentThread.IsThreadPoolThread}");

            MyTask myTask = new MyTask();
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Calling ProcessWorkAsync using .Wait()");
            myTask.ProcessWorkAsync().Wait();

            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Completed ProcessWorkAsync after .Wait()");
            currentThread = System.Threading.Thread.CurrentThread;
            Console.WriteLine($"Current Thread Id:{currentThread.ManagedThreadId}, Priority: {currentThread.Priority}, Bacgground: {currentThread.IsBackground}, Thread Pool: {currentThread.IsThreadPoolThread}");

            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Calling ProcessWorkAsync using await");
            Task<bool> processWorkTask = myTask.ProcessWorkAsync();            
            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Completed ProcessWorkAsync before await");
            bool ret = await processWorkTask.ConfigureAwait(false);

            Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] Completed ProcessWorkAsync after await, press any key to complete");
            currentThread = System.Threading.Thread.CurrentThread;
            Console.WriteLine($"Current Thread Id:{currentThread.ManagedThreadId}, Priority: {currentThread.Priority}, Bacgground: {currentThread.IsBackground}, Thread Pool: {currentThread.IsThreadPoolThread}");

            Console.ReadLine();
        }
    }
}
