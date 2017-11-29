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
            // MyFile.GetDifferentPaths();
            // MyClass.TestMyClass();
            // MyClass.VerifyStringFormat();
            // MyClass.VerifyNullLoop();
            // MyTestCode.RunTestCode();
            // MyRegistry.WaitForDebuggerAttach();
            // WriteOnTheSameLine();
            // MyFile.GetFiles();
            // TestDataContract.TestDataContractBehavior();
            // TestIPHelper.TestIPAddressConversions();
            // MyException.ConvertWin32ErrorCodes();
            // MyCollection.WriteCollection();
            // MyCollection.VerifyContains();
            // MyCollection.TryCollectionToString();
            // MyFunction.TestNonRef();
            // MyURI.ParseURI();
            // MySendKeys.run();
            MyCursor.TryMoveCursor();

            //GeneralSamplesDLL.MyPublicClass.GetValue("hi");
            // GeneralSamplesDLL.MyPublicClass.CallValidation();
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
