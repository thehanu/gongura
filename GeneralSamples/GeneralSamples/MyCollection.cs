using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    public class RegionalNetworkConfigurationInfo : IEquatable<RegionalNetworkConfigurationInfo>
    {
        public RegionalNetworkConfigurationInfo() { }

        public Guid Id { get; set; }

        public int ConfigurationType { get; set; }

        public ulong ConfigurationVersion { get; set; }

        public bool Equals(RegionalNetworkConfigurationInfo regionalNetworkInfo)
        {
            return regionalNetworkInfo.Id.Equals(Id) &&
                regionalNetworkInfo.ConfigurationType == ConfigurationType &&
                regionalNetworkInfo.ConfigurationVersion == ConfigurationVersion;
        }

        public override string ToString() { return string.Format("Id: {0}, Configuration Type: {1}, Version {2}", Id, ConfigurationType, ConfigurationVersion); }
    }

    class MyCollection
    {
        public static void WriteCollection()
        {
            ICollection<string> intCollection = new List<string>();
            intCollection.Add("1"); intCollection.Add("2"); intCollection.Add("3");
            StringBuilder sb = new StringBuilder();

            foreach (string myint in intCollection)
            {
                sb.Append(string.Format("{0},", myint));
            }

            Console.WriteLine("IntCollection: {0}", sb);
        }

        public static void VerifyContains()
        {
            ICollection<RegionalNetworkConfigurationInfo> configurationInfoCollection = new System.Collections.ObjectModel.Collection<RegionalNetworkConfigurationInfo>();

            AddResourceToNetworkConfigInfoCollection("FEE0", 1, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE1", 1, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE2", 1, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE3", 1, configurationInfoCollection);

            AddResourceToNetworkConfigInfoCollection("FEE0", 0, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE1", 0, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE2", 0, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE3", 0, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE4", 0, configurationInfoCollection);

            // Dupes
            AddResourceToNetworkConfigInfoCollection("FEE1", 1, configurationInfoCollection);
            AddResourceToNetworkConfigInfoCollection("FEE2", 0, configurationInfoCollection);
        }

        public static void ProcessCollections(ICollection<string> leftKeys, ICollection<string> rightKeys)
        {
            leftKeys.OrderBy(p => p.ToString());
            rightKeys.OrderBy(p => p, StringComparer.Ordinal);
            List<string> keys = new List<string>();
            int leftKeysIndex = 0;
            int rightKeysIndex = 0;

            while(leftKeysIndex < leftKeys.Count || rightKeysIndex < rightKeys.Count)
            {
                if(leftKeysIndex < leftKeys.Count && rightKeysIndex < rightKeys.Count &&
                    string.Compare(leftKeys.ElementAt(leftKeysIndex), rightKeys.ElementAt(rightKeysIndex)) == 0)
                {
                    keys.Add($"Update {leftKeys.ElementAt(leftKeysIndex)}");
                    leftKeysIndex++;
                    rightKeysIndex++;
                }
                else if(rightKeysIndex >= rightKeys.Count ||
                    (leftKeysIndex < leftKeys.Count && 
                    string.Compare(leftKeys.ElementAt(leftKeysIndex), rightKeys.ElementAt(rightKeysIndex)) < 0))
                {
                    keys.Add($"Add Left {leftKeys.ElementAt(leftKeysIndex)}");
                    leftKeysIndex++;
                }
                else
                {
                    keys.Add($"Add Right {rightKeys.ElementAt(rightKeysIndex)}");
                    rightKeysIndex++;
                }
            }

            Console.WriteLine($"Processed list: {string.Join(",", keys)}");
        }

        public static void ValidateProcessCollections()
        {
            List<string> leftKeys = new List<string> { "yyzz", "ccdd", "ffgg", "aabb", "ffhh", "ffyy", "eeff", "zzaa" };
            List<string> rightKeys = new List<string> { "bbdd", "ffkk", "ccdd", "ffjj", "ffll", "xxyy", "ffii" };
            ProcessCollections(leftKeys, rightKeys);
        }

        private static void AddResourceToNetworkConfigInfoCollection(
           string seed, int type,
           ICollection<RegionalNetworkConfigurationInfo> configurationInfoCollection)
        {
            Console.WriteLine("Adding resource with seed {0}, type: {1}", seed, type);
            Guid resourceId = Guid.Parse(string.Format("{0}0808-CF60-429B-FEED-0C6452DDDD{1}{1}", seed, type));

            RegionalNetworkConfigurationInfo regionalNetworkConfigInfo =
                GetRegionalNetworkConfiguration(resourceId);
            if (regionalNetworkConfigInfo != null)
            {
                if (!configurationInfoCollection.Contains(regionalNetworkConfigInfo))
                {
                    configurationInfoCollection.Add(regionalNetworkConfigInfo);
                }
                else
                {
                    Console.WriteLine("Collection already contains Regional Network Configuration with GUID {0}, Skipping...", resourceId);
                }
            }
            else
            {
                Console.WriteLine(string.Format("Provided resource Id {0} is neither a routeGroup or AclGroup or QosCollection", resourceId));
            }
        }

        private static RegionalNetworkConfigurationInfo GetRegionalNetworkConfiguration(Guid resourceId)
        {
            if (resourceId.ToString().EndsWith("00"))
            {
                return new RegionalNetworkConfigurationInfo
                {
                    ConfigurationType = 0,
                    Id = resourceId
                };
            }

            if (resourceId.ToString().EndsWith("11"))
            {
                return new RegionalNetworkConfigurationInfo
                {
                    ConfigurationType = 1,
                    Id = resourceId
                };
            }

            return null;
        }

        public static void TryCollectionToString()
        {
            List<IPSubnet> subnets = new List<IPSubnet>();
            for (int i = 0; i < 6; i++)
            {
                IPSubnet subnet = new IPSubnet();
                subnet.Name = $"SubnetName{i}";
                subnet.IPAddress = System.Net.IPAddress.Parse($"10.0.0.{i}");
                subnet.Prefix = 2;
                subnets.Add(subnet);
            }

            Console.WriteLine($"Subnets: {collectionToString(subnets)}");

            List<IPSubnet> subnetsEmpty = new List<IPSubnet>();
            Console.WriteLine($"Empty Subnets: {collectionToString(subnetsEmpty)}");

        }
        public static string collectionToString<T>(IEnumerable<T> collection)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T t in collection)
            {
                sb.Append($"{t.ToString()}, ");
            }
            char[] trimmer = { ',', ' ' };
            return sb.ToString().TrimEnd(trimmer);
        }
    }
}
