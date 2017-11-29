using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace GeneralSamples
{
    class MyRegistry
    {
        public static void WaitForDebuggerAttach()
        {
            string valueName = @"SOFTWARE\Rnm\UnitTest";
            int sleepIntervalInSeconds = 5;            
            int remainingTimeInSeconds = 2 * 60; 
            while (true)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(valueName, false);
                if (key == null || (int)key.GetValue("WaitForDebugger", 0) == 0 ||
                    remainingTimeInSeconds < 0)
                { break; }

                remainingTimeInSeconds -= sleepIntervalInSeconds;
                Console.WriteLine("Waiting for debugger... {0:00}m:{1:00}s more.", remainingTimeInSeconds / 60, remainingTimeInSeconds % 60);
                System.Threading.Thread.Sleep(sleepIntervalInSeconds * 1000);                
            }
        }


    }
}
