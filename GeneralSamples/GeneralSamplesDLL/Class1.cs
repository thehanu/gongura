using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamplesDLL
{
    class MySampleSubClass
    {
        public int i;
        public HashSet<int> set;

        public MySampleSubClass()
        {
            this.i = 0;
            this.set = null;
        }

        MySampleSubClass(int i, HashSet<int> set)
        {
            this.i = i;
            this.set = set;
        }
    }
    class MySampleClass
    {
        public string val;
        public MySampleSubClass subClass;

        public MySampleClass()
        {
            val = "hi";
            subClass = new MySampleSubClass();
        }
    }
    public static class MyPublicClass
    {
        public static int GetValue(string mystring)
        {
            Console.WriteLine("I got {0}", mystring);
            return 6;
        }
        public static string GetValueString(string mystring)
        {
            Console.WriteLine("I got {0}", mystring);
            return string.Format("Hello ... {0}", mystring);
        }

        public static void CallValidation()
        {
            MySampleClass sampleClass = new MySampleClass();
            string str = $"SubClass: {sampleClass?.subClass}, set: {sampleClass?.subClass?.set}";
            bool str1 = sampleClass.subClass?.set.Any() ?? false;
            if (null == sampleClass?.subClass?.set)
            {
                Console.WriteLine(str);
                Console.WriteLine("Yeah it is null");
            }
        }
    }
}
