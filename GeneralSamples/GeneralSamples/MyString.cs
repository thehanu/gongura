using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyString
    {
        public static void ValidateFormat()
        {
            try
            {
                string insufficientFormatedString = string.Format("First {0}, Second: {1}, Third: {2}", "1st", "2nd");
                Console.WriteLine($"insufficientFormatedString: {insufficientFormatedString}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }

            try
            {
                string overflowFormatedString = string.Format("First {0}, Second: {1}, Third: {2}", "1st", "2nd", "3rd", "4th");
                Console.WriteLine($"overflowFormatedString: {overflowFormatedString}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }            
        }
    }
}
