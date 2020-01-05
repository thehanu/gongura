using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace GeneralSamples
{
    class MyClass
    {
        public Dictionary<string, List<string>> TagMap { get; set; }
        public string subscriptionId;
        public Guid id;
        public string value;
        public List<string> myList = null;
        private DhcpOptions dhcpOptions = null;

        public DhcpOptions DhcpOptions
        { get
            {
                if (dhcpOptions == null)
                {
                    dhcpOptions = new DhcpOptions();
                }
                return dhcpOptions;
            }
            set
            {
                dhcpOptions = value;
            }
        }

        public static void checkBool()
        {

        }

        public static void VerifyRandom()
        {
            Random persistedRand = new Random();
            for (int i = 0; i < 100; i++)
            {
                Random rand = new Random();
                int assignedPartition = rand.Next() % 10;
                int persistedRandAssignedPartition = persistedRand.Next() %10;
                Console.WriteLine($"Persisted Rand next: {persistedRandAssignedPartition}, dynamic rand next: {assignedPartition}");
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

        public static void TestMyClassToString()
        {
            MyClass myClass = new MyClass("MySubscriptionID", Guid.Empty);
            Console.WriteLine($"Tostring: {myClass.ToString()}");
        }

        public static void TryDataObjectToString()
        {
            AllocatedIPPrefixDataObject dataObject = new AllocatedIPPrefixDataObject();
            dataObject.CreatedTime = DateTime.Now;
            dataObject.OwnerType = "NIC";
            dataObject.OwnerId = "NIC1";
            dataObject.Prefix = new AddressPrefix();
            dataObject.Prefix.IPAddress = "192.168.0.5";
            Console.WriteLine($"ToStringof DataObject: {dataObject}");

        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            //return new JavaScriptSerializer().Serialize(this);
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

        public static void VerifyStringFormatSimple()
        {
            string e = "Exception contains { these braces }";
            Console.WriteLine(GenerateMessage($"sample string {e.ToString().Replace("{", "{{").Replace("}", "}}")}"));
        }
        public static string GenerateMessage(string msg, params object[] args)
        {
            return string.Format(msg, args);
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


        public static void GetStackTraceOuter()
        {
            GetStackTrace();            
        }

        public static void GetStackTrace()
        {
            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame();
            Console.WriteLine($"Stack Frame declaring type full name: {sf.GetMethod().DeclaringType.FullName}, reflected type full name: { sf.GetMethod().ReflectedType.FullName}, Method name: {sf.GetMethod().Name}");

            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            Console.WriteLine($"Stack Frame: {st.GetFrame(0).GetMethod().ReflectedType.FullName}");
            Console.WriteLine($"Caller Stack Frame: {st.GetFrame(1).GetMethod().ReflectedType.FullName}");
        }

        public static void NullIterator()
        {
            // Iterate through null enumerable
            IEnumerable<Tuple<string, Guid>> toBeDeletedPublishingInfoTaskIds = null;
            foreach (var subTaskIdPair in toBeDeletedPublishingInfoTaskIds ?? Enumerable.Empty<Tuple<string, Guid>>())
            {
                Console.WriteLine($"Iterating value: {subTaskIdPair}");
            }
        }

        public static void ValidateGuidFormat()
        {
            Guid id = Guid.NewGuid();
            string guidString = id.ToString("N");

            Console.WriteLine($"Guid formatted: {guidString}");
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

        public static void CheckConditions()
        {
            if (FirstCondition() && SecondCondition() && ThirdCondition() || FourthCondition())
            {
                Console.WriteLine($"I am in condition");
            }
            else
            {
                Console.WriteLine($"I am out of condition");
            }
        }

        private static bool FirstCondition()
        {
            bool retValue = true;
            return retValue;
        }
        private static bool SecondCondition()
        {
            bool retValue = true;
            return retValue;
        }

        private static bool ThirdCondition()
        {
            bool retValue = true;
            return retValue;
        }
        private static bool FourthCondition()
        {
            bool retValue = false;
            return retValue;
        }
    }

    public class Setting
    {
        public Int16 value { get; set; }

        Setting()
        { value = 32; }

        public static readonly Setting Default = new Setting();

        public static void VerifyDefaultValue()
        {
            Setting set = default(Setting);
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

        public static void TestMyClassOneToString()
        {
            MyClassOne myclassOne = new MyClassOne("MySubID", Guid.Empty);
            Console.WriteLine($"ToString: {myclassOne.ToString()}");
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

        public static void verifySwitch(int value)
        {
            switch(value)
            {
                case 3:
                    Console.WriteLine("It is #3");
                    break;
                case 5:
                    Console.WriteLine("It is #5");
                    break;
            }
        }

        public static void CheckTimeSpan()
        {
            TimeSpan throttlingLoadTime = TimeSpan.FromTicks(0);
            int throttlingLoadTickCount = 0;

            
            while (true)
            {
                int currentTickCount = Environment.TickCount & Int32.MaxValue;
                TimeSpan currentTimeSpan = TimeSpan.FromTicks(currentTickCount);
                TimeSpan diff = currentTimeSpan.Subtract(throttlingLoadTime);
                if (diff < new TimeSpan(0, 1, 0))
                {
                    Console.WriteLine("diff is lesss");
                }

                int intdiff = currentTickCount - throttlingLoadTickCount;
                int minsFromMS = (int) TimeSpan.FromMilliseconds(intdiff).TotalMinutes;
                int minsFromTicks = (int) TimeSpan.FromTicks(intdiff).TotalMinutes;
                if (intdiff < 500)
                {
                    Console.WriteLine("intdiff is less than 500");
                }
                throttlingLoadTime = currentTimeSpan;
                throttlingLoadTickCount = currentTickCount;
            }
        }
    }

    public class SerializeObject
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }

    [DataContract]
    public abstract class DataObject : SerializeObject
    {
        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public DateTime UpdatedTime { get; set; }
    }

    [DataContract]
    public class AddressPrefix : SerializeObject
    {
        [DataMember]
        public string IPAddress { get; set; }

        [DataMember]
        public ushort Length { get; set; }
    }

    [DataContract]
    public class AllocatedIPPrefixDataObject : DataObject
    {
        [DataMember]
        public AddressPrefix Prefix { get; set; }

        [DataMember]
        public string OwnerId { get; set; }

        [DataMember]
        public string OwnerType { get; set; }
    }
}
