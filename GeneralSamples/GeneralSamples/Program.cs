using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    public class Program
    {
        [XmlRoot("AzurePublicIpAddresses")]
        public class PublicIpAddressPrefixes
        {
            [XmlElement("Region")]
            public List<XmlRegion> Regions { get; set; }
        }

        public class XmlRegion
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }

            [XmlElement("IpRange")]
            public List<int> PublicIpPrefixes { get; set; }
        }

        static void VerifyXMLRegion()
        {
            PublicIpAddressPrefixes ipPrefix = new PublicIpAddressPrefixes();
            ipPrefix.Regions = new List<XmlRegion>();
            for (int i = 0; i < 6; i++)
            {
                XmlRegion region = new XmlRegion();
                region.Name = string.Format("Region {0}", i);
                region.PublicIpPrefixes = new List<int> { 1, 2, 3 };
                ipPrefix.Regions.Add(region);
            }

            XmlSerializer serializer = new XmlSerializer(ipPrefix.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, ipPrefix);
                textWriter.ToString();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("I am running in GeneralSamples");
            // MyDictionary.TestKeyAlreadyAddedException();
            // MyDictionary.ValidateDuplicateAdds();
            // MyDictionary.ValidateNullKeys();
            // MyDictionary.ValidateKeyIndex();
            // MyDictionary.ValidateNoKey();
            MyDictionary.VerifyJsonSerialize();
            // MyFile.GetDifferentPaths();
            // MyClass.TestMyClass();
            // MyClass.VerifyStringFormat();
            // MyClass.VerifyStringFormatCurly();
            // MyClass.VerifyNullLoop();
            // MyClass.VerifyCatchThrowCaughtByFinally();
            // MyClass.VerifyObjectTest();
            // MyClass.VerifyStringSplit();
            // MyClass.VerifyStringFormatSimple();
            // MySimpleClass.CheckTimeSpan();
            // MySimpleClass.LoadClassByName();
            // MySimpleClass.verifySwitch(8);
            // MyTestCode.RunTestCode();
            // MyRegistry.WaitForDebuggerAttach();
            // WriteOnTheSameLine();
            // MyFile.GetFiles();
            // MyFile.GetFileEncodings();
            // TestDataContract.TestDataContractBehavior();
            // TestIPHelper.TestIPAddressConversions();
            // TestIPHelper.ParseIPAddressOut();
            // MyException.ConvertWin32ErrorCodes();
            // MyException.VerifyLogInnerException();
            // MyException.VerifyForceLogInnerException();
            // MyException.VerifyForceLogAggregateException();
            // MyCollection.WriteCollection();
            // MyCollection.VerifyContains();
            // MyCollection.TryCollectionToString();
            // MyCollection.ValidateProcessCollections();
            // MyCollection.TestHashSetUnion();
            // MyCollection.TestReplace();
            // MyFunction.TestNonRef();
            // MyURI.ParseURI();
            // MyURI.VerifyUris();
            // MySendKeys.run();
            // MyCursor.TryMoveCursor();
            // MyList.VerifyDeleteItems();
            // MyList.ConvertToString();
            // MyList.VerifyNullCollection();
            // MyList.VerifyNullValuesInList();
            // MyList.VerifyEquals();
            // MyList.VerifyCopy();
            // MyList.VerifyFirstOrDefault();
            // MyList.VerifyDeleteInLoop();
            // MyRegEx.MatchRegex();
            // MyClass.VerifyOverrides();
            // MyClass.CheckConditions();
            // MyClass.TestMyPublicProperty();
            // MyClass.VerifyRandom();
            // MyClass.NullIterator();
            // MyClass.TestMyClassToString();
            // MyClassOne.TestMyClassOneToString();
            // MyClass.TryDataObjectToString();
            // MyClass.GetStackTrace();
            // MyClass.ValidateGuidFormat();
            // IsNullOperator.Validate();
            // GeneralSamplesDLL.MyPublicClass.GetValue("hi");
            // GeneralSamplesDLL.MyPublicClass.CallValidation();
            // Setting.VerifyDefaultValue();
            // FuncArgument.TestFunctionArgument();
            // MyBenchMark.PerformBenchMarks();
            // MyTimer.TestTimer();
            // MyThreadingTimer.TestTimer();
            // Task task = MyTask.PerformAsnycMethod();
            // task.Wait();
            // MyStopWatch.TestStartStop();
            // MySwitch.TestFallthroughCase();
            // MyYield.TestYield();
            // MyEnum.TestEnumParse();
            // MyClass.VerifyStringAppend();
            // MyClass.VerifyTypes();
            // MyCast.VerifyDynamicCast();
            // MyByte.VerifyConversion();
            // MyByte.VerifyOutParam();
            // MyString.ValidateFormat();
        }


        /// <summary>
        /// Function to write on the same line, ex: to show progress...
        /// </summary>
        public static void WriteOnTheSameLine()
        {
            for (int i = 0; i < 100; ++i)
            {
                Console.Write("\r{0}% ", i);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
