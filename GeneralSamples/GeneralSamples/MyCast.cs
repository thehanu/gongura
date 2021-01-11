using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GeneralSamples
{
    class MyCast
    {
        public class MyInteger
        {
            public int i = 0;
            public MyInteger(string value)
            {
                i = int.Parse(value);
            }

        }

        public class MyString
        {
            public string str = string.Empty;
            public MyString(string value)
            {
                str = value;
            }

        }

        public static void VerifyDynamicCast()
        {
            string inputType = string.Empty;
            string inputValue = string.Empty;
            Dictionary<string, Type> map = new Dictionary<string, Type>() { { "int", typeof(MyInteger) }, { "str", typeof(MyString) } };            
            do
            {
                Console.Write("Please enter the type: ");
                inputType = Console.ReadLine();

                if(map.ContainsKey(inputType))
                {
                    Console.Write("Please enter the value: ");
                    inputValue = Console.ReadLine();

                    var myObject = Activator.CreateInstance(map[inputType], inputValue);
                    Console.WriteLine($"Object Json value: {JsonConvert.SerializeObject(myObject)}");
                }
                else
                {
                    Console.WriteLine($"Don't know about this type: {inputType}, try a different one...");
                }
            }
            while (!string.IsNullOrEmpty(inputType));
            
        }
    }
}
