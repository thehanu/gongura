using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralSamples
{
    class MyByte
    {
        public static void VerifyConversion()
        {
            string MacAddress = "00-15-FF-D9-C1-00";
            byte[] arr = MacAddress.Split('-').Select(x => Convert.ToByte(x, 16)).ToArray();
            //nicPb.MacAddress.Bytes = ByteString.CopyFrom(arr);

            Guid guid = new Guid("01020304-0506-0102-0506-123401021234");
            byte[] guidArray = guid.ToByteArray();
        }

        public static void VerifyOutParam()
        {
            string setting = "AZ01 = 52.253.197.60:700,52.253.197.61; AZ01 - 02 = 52.253.197.63,52.253.197.64:2000;";
            string[] endpoints = setting.Trim().Trim(';').Split(';');
            bool value = Guid.TryParse("01020304-0506-0102-0506-123401021234", out _);
        }
    }
}
