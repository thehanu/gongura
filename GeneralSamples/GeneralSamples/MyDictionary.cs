using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyGroup
    {
        public MyGroup(int i, string d) { id= i; desc = d; }

        int id;
        string desc;
    }
    public class MyDictionary
    {
        public static void TestKeyAlreadyAddedException()
        {
            try
            {
                Dictionary<Tuple<Guid, int>, ICollection<MyGroup>> myDictionary = new Dictionary<Tuple<Guid, int>, ICollection<MyGroup>>();
                Tuple<Guid, int> myEmptyKey = new Tuple<Guid, int>(Guid.Empty, 1);
                ICollection<MyGroup> myEmptyValue = new System.Collections.ObjectModel.Collection<MyGroup>();
                myEmptyValue.Add(new MyGroup(1, "one"));
                myDictionary[myEmptyKey] = myEmptyValue;

                ICollection<MyGroup> mySimpleValue = new System.Collections.ObjectModel.Collection<MyGroup>();
                mySimpleValue.Add(new MyGroup(2, "two"));
                myDictionary[myEmptyKey] = mySimpleValue;

                ICollection<MyGroup> myThirdValue = new System.Collections.ObjectModel.Collection<MyGroup>();
                myThirdValue.Add(new MyGroup(3, "three"));
                myDictionary.Add(myEmptyKey, myThirdValue);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

        public static void ValidateNotNullOrEmpty(IDictionary<string, string> strings)
        {
            foreach (KeyValuePair<string, string> strPair in strings)
            {
                if (string.IsNullOrEmpty(strPair.Value))
                {
                    Console.WriteLine($"{strPair.Key} null or empty");
                    throw new ArgumentNullException($"{strPair.Key}");
                }
            }
        }

        public static void ValidateDuplicateAdds()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("one", "One is one");
            dictionary.Add("two", "Two is two");
            dictionary.Add("three", "Three is three");
            dictionary.Add("one", "One is four now");

            foreach (string key in dictionary.Keys)
            {
                Console.WriteLine($"Key: {key}, value: {dictionary[key]}");
            }
        }

        public static void ValidateNullKeys()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("", "Empty is one");
            dictionary.Add(null, "Null is two");

            foreach (string key in dictionary.Keys)
            {
                Console.WriteLine($"Key: {key}, value: {dictionary[key]}");
            }
        }

        public static void ValidateKeyIndex()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("one", "One is one");
            dictionary.Add("two", "Two is two");

            bool contains = dictionary.ContainsKey("one");

            try
            {
                string valueOfNull = dictionary[null];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception detail: {e}");
            }
            
            try
            {
                string valueOfNoKey = dictionary["three"];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception detail: {e}");
            }
        }
    }
    
}
