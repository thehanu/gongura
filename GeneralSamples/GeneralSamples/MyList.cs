using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyList
    {
        public static void VerifyDeleteItems()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                strings.Add($"StringValue{i}");
            }

            foreach (string str in strings)
            {
                strings.Remove(str);
            }
        }

        public static void ConvertToString()
        {
            List<string> strings = new List<string>();
            strings.Add("One");
            strings.Add("two");
            strings.Add("three");

            Console.WriteLine($" Joined strings: {string.Join(",", strings)}");
        }

        public static void VerifyNullCollection()
        {
            List<string> strings = null;

            foreach(string str in strings)
            {
                Console.WriteLine($"str in strings: {str}");
            }
        }

        public static void VerifyNullValuesInList()
        {
            IEnumerable<string> strings = new List<string> { "One", "two", null, "four" };

            foreach (string str in strings)
            {
                Console.WriteLine($"str in strings: {str}");
            }
        }

        public static void VerifyEquals()
        {
            IEnumerable<string> strings = new List<string> { "One", "two", null, "four" };
            IEnumerable<string> stringsCopy = new List<string> { "One", "two", null, "four" };

            Console.WriteLine("Are string and stringsCopy equal?: {0}", strings.SequenceEqual(stringsCopy));
        }

        public static void VerifyCopy()
        {
            List<string> strings = new List<string> { "One", "two", null, "four", "Five" };
            List<string> stringsCopy = new List<string> { "One", "two", null, "four" };
            List<string> stringsCopy1 = strings;
            stringsCopy = strings.ToList();

            strings.Remove("four");

            Console.WriteLine("Updated strings: {0}, direct assigned copy: {1}, ToList copy: {2}", string.Join(",", strings), string.Join(",", stringsCopy1), string.Join(",", stringsCopy));
        }

        public static void VerifyFirstOrDefault()
        {
            List<string> strings = new List<string> { };

            string firstOrDefault = strings.FirstOrDefault();
            string last = strings.Last();
            Console.WriteLine($"With Empty list, first or default: {firstOrDefault}, Last: {last}");

            strings.AddRange(new List<string> { "One", "two", null, "four", "Five" });
            firstOrDefault = strings.FirstOrDefault();
            last = strings.Last();
            Console.WriteLine($"With Empty list, first or default: {firstOrDefault}, Last: {last}");
        }

        public static void VerifyDeleteInLoop()
        {
            List<string> strings = new List<string> { "first", "second", "third", "fourth" };

            strings.AddRange(new List<string> { "One", "two", null, "four", "Five" });
            for (int index = strings.Count; index > -1; index--)
            {
                if (strings[index] == "") ;
            }
            foreach (string workingString in strings)
            {
                strings.Remove(workingString);
            }
        }

        public static void VerifyInitializeComplexObjects()
        {
            IEnumerable<MyTestCode> strings = new List<MyTestCode> { new MyTestCode() };

        }
    }

}
