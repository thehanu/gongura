using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MySwitch
    {
        public static void TestFallthroughCase()
        {

            int value = 1;
            while (value != 0)
            {
                switch (value)
                {
                    case 1:
                        Console.WriteLine($"I am in Case {value}");
                        break;
                    case 2:
                    case 3:
                        Console.WriteLine($"I am in joint case 2 and 3 with value: {value}");
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Console.WriteLine($"I am in joint case 4, 5, 6 with value: {value}");
                        break;
                    default:
                        Console.WriteLine($"I am in case default with value: {value}");
                        break;

                }
                Console.WriteLine($"Please enter a numeric value to switch, [enter 0 to exit]:");
                value = int.Parse(Console.ReadLine());
            }
        }
    }
}
