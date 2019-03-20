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

        public DhcpOptions DhcpOptions
        { get
            {
                if (DhcpOptions == null)
                {
                    DhcpOptions = new DhcpOptions();
                }
                return DhcpOptions;
            }
            set
            {
                DhcpOptions = value;
            }
        }

        public virtual void CopyTo(MyClass destination)
        {
            destination.myList = this.myList;
        }

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

        public static void TestMyPublicProperty()
        {
            MyClass myClass = new MyClass("MySubscriptionID", Guid.Empty);
            myClass.GetValues();

            myClass.DhcpOptions = null;
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

        public static void VerifyStringFormatCurly()
        {
            string str = string.Format("{{ 'name': '{0}'}}", "value");
            string value = "value";
            string dollarStr = $"{{ 'name': '{value}'}}";
            Console.WriteLine(str);
            Console.WriteLine("Dolloar Str: {0}", dollarStr);
        }

        public static void VerifyStringSplit()
        {
            // Get splits on empty string
            string str = string.Empty;
            string[] splits = str.Split('@');
            Console.WriteLine($"Splits of '@' on Empty string: {string.Join(",", splits)}");

            // Get splits on one split char string.
            str = "@";
            splits = str.Split('@');
            Console.WriteLine($"Splits of '@' on '@' string: {string.Join(",", splits)}");

            // Get splits on one char string.
            str = "d";
            splits = str.Split('@');
            Console.WriteLine($"Splits of '@' on 'd' string: {string.Join(",", splits)}");
        }

        public static void VerifyOverrides()
        {
            MyClassOne myClassOne = new MyClassOne("sub1", new Guid());
            MyClassTwo MyClassTwo = new MyClassTwo("sub2", new Guid());
            myClassOne.CopyTo(MyClassTwo);
        }

        public static void VerifyCatchThrowCaughtByFinally()
        {
            try
            {
                Console.WriteLine("I am in try, attempting to devide by zero...");
                int zero = 0;
                int i = 6 / zero;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"I cought exception : {ex.Message}, now throwing...");
                throw new Exception("MyException");
            }
            finally
            {
                Console.WriteLine("I am in Finally...");
            }
        }

        public static void VerifyObjectTest()
        {
            ObjectTest objectTest = null;
            object resultObject = objectTest?.objects;

            Console.WriteLine($"Result object of objectTest?.objects where objectTest is null{resultObject}");

            objectTest = new ObjectTest();
            resultObject = objectTest?.objects;
            Console.WriteLine($"Result object of objectTest?.objects where objectTest is valid but objects is null {resultObject}");

            objectTest.objects = new List<string>();
            resultObject = objectTest?.objects;
            Console.WriteLine($"Result object of objectTest?.objects where objectTest is valid and objects is also valid {resultObject}");
        }
    }

    public class MyPublicClass
    {
        public static int GetValue()
        {
            return 6;
        }
    }

    class MyClassOne : MyClass
    {
        public MyClassOne(string subscriptionId, Guid id):base(subscriptionId, id) {}
        public int One;

        public override void CopyTo(MyClass destination)
        {
            base.CopyTo(destination);
            MyClassOne destinationOne = destination as MyClassOne;
            destinationOne.One = this.One;
        }
    }

    class MyClassTwo : MyClass
    {
        public MyClassTwo(string subscriptionId, Guid id):base(subscriptionId, id) { }
        public int Two;

        public override void CopyTo(MyClass destination)
        {
            base.CopyTo(destination);
            MyClassTwo destinationTwo = destination as MyClassTwo;
            destinationTwo.Two = this.Two;
        }
    }

    public class DhcpOptions
    {
        public DhcpOptions()
        {
            this.DnsServers = new List<string>();
        }

        public List<string> DnsServers { get; private set; }
    }

    public class ObjectTest
    {
        public ObjectTest()
        {
            this.objects = null;
        }

        public List<string> objects { get; set; }
    }

    public class LowerObject
    {
        public string MyValue = null;
    }
    public class IsNullOperator
    {
        LowerObject lowerObject = null;

        public void SetLowerObject()
        {
            if (lowerObject == null)
            {
                lowerObject = new LowerObject();
                lowerObject.MyValue = String.Empty;
            }
        }

        public static void Validate()
        {
            IsNullOperator topObject = new IsNullOperator();
            bool value = topObject.lowerObject?.MyValue == null;

            topObject.SetLowerObject();
            value = topObject.lowerObject?.MyValue == null;
        }
    }

    public class MyInternalClass
    {
        public int MyInternalIntValue { get; set; }
        public string myInternalStringValue { get; set; }

        public MyInternalClass() { }

        public override string ToString()
        { return $"Internal Int: {MyInternalIntValue}, Internal string: {myInternalStringValue}"; }
    }
    public class MySimpleClass
    {
        
        public int myIntValue;
        public string myStringValue;
        public MyInternalClass MyInternalClass { get; set; }

        public string GetValue()
        {
            return $"Int: {myIntValue}, string: {myStringValue}, InternalClass: {MyInternalClass.ToString()}";
        }

        public MyInternalClass GetInternalClass()
        {
            return MyInternalClass;
        }

        public MyInternalClass SetInternalClass(MyInternalClass myInternalClass)
        {
            return MyInternalClass = myInternalClass;
        }

        public MySimpleClass()
        {
            myIntValue = 0;
            myStringValue = string.Empty;
            SetInternalClass(new MyInternalClass());
        }

        public static void LoadClassByName()
        {
            string className = "GeneralSamples.MySimpleClass";
            Type classType = Type.GetType(className);
            Object myObject = Activator.CreateInstance(classType);
            Type internalClassType = Type.GetType("GeneralSamples.MyInternalClass");
            var internalClass = classType.InvokeMember("GetInternalClass", BindingFlags.Default | BindingFlags.InvokeMethod, null, myObject, null);
            internalClassType.InvokeMember("MyInternalIntValue", BindingFlags.Default | BindingFlags.SetProperty, null, internalClass, new object[] { 100 });
            classType.InvokeMember("SetInternalClass", BindingFlags.Default | BindingFlags.InvokeMethod, null, myObject, new [] { internalClass });
            Object result = classType.InvokeMember("GetValue", BindingFlags.Default | BindingFlags.InvokeMethod, null, myObject, null);
            Console.WriteLine($"result: {result}");
        }
    }
}
