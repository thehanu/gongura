using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyURI
    {
        public static void ParseURI()
        {
            string uriString = @"net.tcp://10.30.76.124:1292/";
            Uri uri = new Uri(uriString);
            Console.WriteLine($"UriString: {uriString}, Host: {uri.Host}, Port: {uri.Port}");
        }
    }
}
