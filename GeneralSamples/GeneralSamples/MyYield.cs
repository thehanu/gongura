using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneralSamples
{
    class MyYield
    {
        public static void TestYield()
        {
            Console.WriteLine("In My TestYield Funciton");
            int number = 2;
            // Display powers of 2 up to the exponent of 8:

            Console.WriteLine($"Calling Power function with Yield...");
            foreach (int power in Power(number, 8))
            {
                Console.WriteLine($"In this ireration power of {number} is {power}");
            }

            Console.WriteLine($"Calling Power function with Inline...");
            foreach (int i in PowerInline(number, 8))
            {
                Console.WriteLine($"{i} power from Inline of {number} ");
            }
        }

        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                Console.WriteLine($"Calculating power of {i} with result {result}.");
                result = result * number;
                yield return result;
            }
        }

        public static System.Collections.Generic.IEnumerable<int> PowerInline(int number, int exponent)
        {
            int result = 1;
            System.Collections.Generic.List<int> results = new List<int>();

            for (int i = 0; i < exponent; i++)
            {
                Console.WriteLine($"Calculating power of {i} with result {result}.");
                result = result * number;
                results.Add(result);
            }
            return results;
        }
    }
}