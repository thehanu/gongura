using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyAsync
    {
        public static Task<string> GetUserInputAsync()
        {
            return Task.Run(() => Console.ReadLine());
        }

        public static async Task<string> TestAsync()
        {
            Console.WriteLine("hello started the ");
            return await GetUserInputAsync();
        }
    }
}
