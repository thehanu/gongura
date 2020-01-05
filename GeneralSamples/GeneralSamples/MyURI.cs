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

        public static void VerifyUris()
        {
            Uri serviceUri = new Uri("http://rnm.core.windows.net/svimanager01");
            Uri dupeOfServiceUri = new Uri("http://rnm.core.windows.net/svimanager01");
            Uri upperCaseServiceUri = new Uri("http://rnm.core.windows.net/SVImanager01");
            Uri serviceUriFromPM = new Uri("http://rnm.core.windows.net/svimanager03");

            if(serviceUri != serviceUriFromPM)
            {
                Console.WriteLine($"{serviceUri} and {serviceUriFromPM} are not equal");
            }

            if (serviceUri != dupeOfServiceUri)
            {
                Console.WriteLine($"{serviceUri} and {dupeOfServiceUri} are not equal");
            }

            if (serviceUri != upperCaseServiceUri)
            {
                Console.WriteLine($"{serviceUri} and {upperCaseServiceUri} are not equal");
            }

            if (!serviceUri.Equals(upperCaseServiceUri))
            {
                Console.WriteLine($"{serviceUri} and {upperCaseServiceUri} are not equal");
            }

            string uriString = @"net.tcp://10.30.76.124:1292/";
            Uri uri = new Uri(uriString);
            Console.WriteLine($"UriString: {uriString}, Host: {uri.Host}, Port: {uri.Port}");
        }
    }
}
