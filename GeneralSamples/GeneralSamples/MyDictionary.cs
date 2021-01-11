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

        public int id { get; set; }
        public string desc;
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

        public static void CheckTupleValueIncrement()
        {
            Dictionary<string, Tuple<DateTime, int>> OperationToCountDictionary = null;

            if (OperationToCountDictionary == null)
            {
                OperationToCountDictionary = new Dictionary<string, Tuple<DateTime, int>>();
            }

            OperationToCountDictionary.Add("hi", new Tuple<DateTime, int>(DateTime.UtcNow, 100));

            OperationToCountDictionary["hi"] = new Tuple<DateTime, int>(OperationToCountDictionary["hi"].Item1, OperationToCountDictionary["hi"].Item2);

        }

        public static void ValidateNoKey()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("one", "One is one");
            dictionary.Add("two", "Two is two");
            dictionary.Add("three", "Three is three");

            var result = dictionary.Where(set => set.Value != "One is one");

            IDictionary<string, string> dictionary1 = new Dictionary<string, string>();
            //dictionary1.Add("one", "One is one");
            //dictionary1.Add("two", "One is one");
            //dictionary1.Add("three", "One is one");

            var result1 = dictionary1.Where(set => set.Value != "One is one");
        }

        public static void VerifyJsonSerialize()
        {
            Dictionary<string, Dictionary<string, string>> jsonResponse = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, object>> response = new Dictionary<string, Dictionary<string, object>>();

            for(int j = 0; j < 2; j++)
            {
                string endpoint = $"endpoint{j}";
                for (int i = 0; i < 3; i++)
                {
                    MyGroup myGroup = new MyGroup(i, $"Group: {i}");
                    string key = $"key{i}";
                    if (!jsonResponse.ContainsKey(key))
                    {
                        jsonResponse[endpoint] = new Dictionary<string, string>();
                        response[endpoint] = new Dictionary<string, object>();
                    }

                    jsonResponse[endpoint].Add(key, Newtonsoft.Json.JsonConvert.SerializeObject(myGroup));
                    response[endpoint].Add(key, myGroup);
                }
            }

            Console.WriteLine($"jsonResponse dictionary with converted json value: {Newtonsoft.Json.JsonConvert.SerializeObject(jsonResponse)}");
            Console.WriteLine($"response dictionary with object value: {Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented)}");
        }
    }
    
}
