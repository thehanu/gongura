using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GeneralSamples
{
    class MyFunction
    {
        public static ICollection<RegionalNetworkConfigurationInfo> GetNetworkConfigurationInfoCollection(
            Guid externalNic,
            Dictionary<string, ICollection<RegionalNetworkConfigurationInfo>> customerAddressToRegionalConfigInfo)
        {
            ICollection<RegionalNetworkConfigurationInfo> configurationInfoCollection =
                new Collection<RegionalNetworkConfigurationInfo>();
            ICollection<RegionalNetworkConfigurationInfo> configurationInfoCollectionNicOnly =
                new Collection<RegionalNetworkConfigurationInfo>();

            // Add network resources (ACLs and Routes) associated to NIC
            for (int i = 3; i < 7; i++)
            { 
                configurationInfoCollection.Add(new RegionalNetworkConfigurationInfo { ConfigurationType = 0, Id = Guid.Parse(string.Format("{0}0808-CF60-429B-FEED-0C6452DDDD{1}{1}", "FEED", i)) } );
                configurationInfoCollectionNicOnly.Add(new RegionalNetworkConfigurationInfo { ConfigurationType = 0, Id = Guid.Parse(string.Format("{0}0808-CF60-429B-FEED-0C6452DDDD{1}{1}", "FEED", i)) });
            }


            // For CAs being assigned from different Subnets, we provide CA mapped resource collection to apply network resources per subnet.
            string[] subnets = { "CAFE", "CAFF", "CAFD" };
            foreach (string subnet in subnets)
            {
                ICollection<RegionalNetworkConfigurationInfo> mappedConfigurationInfoCollection = new Collection<RegionalNetworkConfigurationInfo>();

                for (int i = 3; i < 7; i++)
                {
                    configurationInfoCollection.Add(new RegionalNetworkConfigurationInfo { ConfigurationType = 0, Id = Guid.Parse(string.Format("{0}0808-CF60-429B-FEED-0C6452DDDD{1}{1}", subnet, i)) });
                    mappedConfigurationInfoCollection.Add(new RegionalNetworkConfigurationInfo { ConfigurationType = 0, Id = Guid.Parse(string.Format("{0}0808-CF60-429B-FEED-0C6452DDDD{1}{1}", subnet, i)) });
                }
                
                // Add NIC resources to mapped configuration info collection.
                foreach (RegionalNetworkConfigurationInfo configInfo in configurationInfoCollectionNicOnly)
                {
                    mappedConfigurationInfoCollection.Add(new RegionalNetworkConfigurationInfo { ConfigurationType = configInfo.ConfigurationType, Id = configInfo.Id, });
                }

                // Add mapped configuration info collection to CA mapped dictionary customerAddressToRegionalConfigInfo
                customerAddressToRegionalConfigInfo.Add(subnet, mappedConfigurationInfoCollection);
            }

            return configurationInfoCollection;
        }

        /*public static void TestRef()
        {
            Dictionary<string, ICollection<RegionalNetworkConfigurationInfo>> customerAddressToRegionalConfigInfo =
                new Dictionary<string, ICollection<RegionalNetworkConfigurationInfo>>();
            GetNetworkConfigurationInfoCollection(Guid.NewGuid(), ref customerAddressToRegionalConfigInfo);            

            Console.WriteLine("IntCollection: {0}", customerAddressToRegionalConfigInfo);
        }*/

        public static void TestNonRef()
        {
            Dictionary<string, ICollection<RegionalNetworkConfigurationInfo>> customerAddressToRegionalConfigInfo =
                new Dictionary<string, ICollection<RegionalNetworkConfigurationInfo>>();
            GetNetworkConfigurationInfoCollection(Guid.NewGuid(), customerAddressToRegionalConfigInfo);

            Console.WriteLine("IntCollection: {0}", customerAddressToRegionalConfigInfo);
        }
    }

    class FuncArgument
    {
        public delegate string MyFunction(string name, Uri value);

        public static void TestFunctionArgument()
        {
            FuncArgument funcArgument = new FuncArgument();
            string returnValue = funcArgument.ExecuteWithRetry(funcArgument.GetValue, "Hanu");

            returnValue = funcArgument.ExecuteWithRetry(funcArgument.GetNewValue, "Hanu");

            returnValue = PerformWithRetry(funcArgument.GetValue, "Hanu");
            Uri myUri = PerformWithRetry(funcArgument.GetUriValue, "Hanu");
        }

        string ExecuteWithRetry(MyFunction myFunction, string name)
        {
            Uri uri = new Uri("http://thehanu.com");
            try
            {
                return myFunction(name, uri);
            }
            catch
            {
                return myFunction(name, null);
            }
        }

        string GetValue(string name, Uri uri)
        {
            return $"{name}:{uri?.ToString()}";
        }

        string GetNewValue(string name , Uri uri)
        {
            return $"New {name}:{uri?.ToString()}";
        }

        Uri GetUriValue(string name, Uri uri)
        {
            return new Uri($"{uri?.ToString()}/{name})");
        }

        public static TResult PerformWithRetry<TResult>(Func<string, Uri, TResult> func, string name)
        {
            Uri uri = new Uri("http://thehanu.com");
            try
            {
                return func(name, uri);
            }
            catch
            {
                return func(name, null);
            }
        }

    }
}
