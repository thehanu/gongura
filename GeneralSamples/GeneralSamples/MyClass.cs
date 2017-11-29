using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GeneralSamples
{
    class MyClass
    {
        public Dictionary<string, List<string>> TagMap { get; set; }
        private string subscriptionId;
        private Guid id;
        private string value;
        public List<string> myList = null;

        public MyClass(string subscriptionId, Guid id)
        {
            Init(subscriptionId, id);
        }

        public MyClass(string subscriptionId, Guid id, string value) : this(subscriptionId, id)
        {
            this.value = value;
        }

        private void Init(string subscriptionId, Guid id)
        {
            this.subscriptionId = subscriptionId;
            this.id = id;
        }
        public void GetValues()
        {
            Console.WriteLine("SubscriptionID: {0}, id: {1}, TagMap: {2}, value: {3}", subscriptionId, id, TagMap, value);
        }

        public static void TestMyClass()
        {
            MyClass myClass = new MyClass("MySubscriptionID", Guid.Empty);
            myClass.GetValues();
            MyClass myClass1 = new MyClass("MySubscriptionID1", Guid.NewGuid(), "MyValue1");
            myClass1.GetValues();

            MyClass myClassNull = null;
            myClassNull?.GetValues();
        }

        public static void VerifyNullLoop()
        {
            ICollection<int> intlist = null;

            foreach (int i in intlist)
            {
                Console.WriteLine("Int value in loop: {0}", i);
            }
        }

        public static void VerifyStringFormat()
        {
            MyClass myClass = new MyClass("Sub1", Guid.NewGuid());
            string str = $"MyClass sub: {myClass.myList} ";
            Console.WriteLine(str);
        }
    }

    public class MyPublicClass
    {
        public static int GetValue()
        {
            return 6;
        }
    }
}
