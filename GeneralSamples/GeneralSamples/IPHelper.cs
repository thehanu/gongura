using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;
using System.Numerics;
using System.Net.Sockets;
using System.Collections;

namespace GeneralSamples
{
    public static class TestIPHelper
    {
        public static void TestIPAddressConversions()
        {
            // Convert IP V4 Address to UInt32
            /*
            UInt32 uInt32Address = IPHelper.ConvertIPAddressToUint32(IPAddress.Parse("0.0.0.0"));

            WorkOnIP("FFFE:FDFC:FBFA:F9F8:F7F6:F5F4:F3F2:F1F0", 20);
            WorkOnIP("0:0:0:0:0:0:0:0", 1);
            WorkOnIP("0:0:0:0:0:0:0:0", 54);
            WorkOnIP("0:0:0:0:0:0:0:1", 1);
            WorkOnIP("0:0:0:0:0:0:0:1", 20);
            WorkOnIP("0:0:0:0:0:0:FFFF:FFFF", 1);
            WorkOnIP("0:0:0:0:0:FF:FFFF:FFFF", 1);
            WorkOnIP("255.255.255.255", 1);
            WorkOnIP("0.0.0.0", 1);
            WorkOnIP("0.0.0.0", 254);
            WorkOnIP("0.0.0.0", 255); // Transition from 0.0.0.255 to 0.0.1.0
            WorkOnIP("0.0.0.0", 256);
            WorkOnIP("0.0.0.0", 32766);
            WorkOnIP("0.0.0.0", 32767); // -ve numbers start for Int
            WorkOnIP("0.0.0.0", 32768);
            WorkOnIP("0.0.0.0", 65530);
            WorkOnIP("0.0.0.0", 65531);
            WorkOnIP("0.0.0.0", 65532);
            WorkOnIP("0.0.0.0", 65533);
            WorkOnIP("0.0.0.0", 65534);
            WorkOnIP("0.0.0.0", 65535);
            WorkOnIP("0.0.0.0", 65536);
            WorkOnIP("0.0.0.0", 65537);
            
            IPHelper.DisplayBitConverter((UInt32)393, string.Format("Straight display UInt32 393 [0001-1000 1001]", 393));
            IPHelper.DisplayBitConverter((BigInteger)393, string.Format("Straight display BigInteger 393 [0001-1000 1001]", 393));
            */
            /*
            WorkOnSubnetMask("0.0.0.0", 0, AddressFamily.InterNetwork);
            WorkOnSubnetMask("0.0.0.0", 1, AddressFamily.InterNetwork);
            WorkOnSubnetMask("0.0.0.0", 4, AddressFamily.InterNetwork);
            WorkOnSubnetMask("0.0.0.0", 8, AddressFamily.InterNetwork);
            WorkOnSubnetMask("0.0.0.0", 30, AddressFamily.InterNetwork);
            WorkOnSubnetMask("0.0.0.0", 31, AddressFamily.InterNetwork);
            WorkOnSubnetMask("0.0.0.0", 32, AddressFamily.InterNetwork);

            WorkOnSubnetMask("0.0.0.0", 0, AddressFamily.InterNetworkV6);
            WorkOnSubnetMask("0.0.0.0", 1, AddressFamily.InterNetworkV6);
            WorkOnSubnetMask("0.0.0.0", 4, AddressFamily.InterNetworkV6);
            WorkOnSubnetMask("0.0.0.0", 8, AddressFamily.InterNetworkV6);

            WorkOnSubnetMask("0.0.0.0", 64, AddressFamily.InterNetworkV6);
            WorkOnSubnetMask("0.0.0.0", 126, AddressFamily.InterNetworkV6);
            WorkOnSubnetMask("0.0.0.0", 128, AddressFamily.InterNetworkV6);
           

            WorkOnParseSubnet("13.1.2.0/23"); // subnet unchanged
            WorkOnParseSubnet("13.1.3.0/23"); // subnet change to 2.0
            WorkOnParseSubnet("13.1.3.1/23"); // subnet change to 2.0
            WorkOnParseSubnet("13.1.3.2/23"); // subnet change to 2.0
            WorkOnParseSubnet("13.1.3.255/23"); // subnet change to 2.0
            WorkOnParseSubnet("13.1.4.0/23"); // subnet unchanged

            WorkOnParseSubnet("10.1.1.0/24"); // subnet unchanged
            WorkOnParseSubnet("10.1.1.4/24"); // subnet change to .0 because 4 belongs to 0-255 (prefix 24)
            WorkOnParseSubnet("10.1.2.8/24");
            WorkOnParseSubnet("10.1.2.127/29"); // subnet change to 120 because 127 belongs to 120-127 (prefix 29)
            WorkOnParseSubnet("10.1.2.127/28"); // subnet change to 112 because 127 belongs to 112-127 (prefix 28)
            WorkOnParseSubnet("10.1.2.127/27"); // subnet change to 96 because 127 belongs to 96-127 (prefix 27)
            WorkOnParseSubnet("10.1.2.127/26"); // subnet change to 64 because 127 belongs to 64-127 (prefix 26)
            WorkOnParseSubnet("10.1.2.127/25"); // subnet change to 0 because 127 belongs to 0-127 (prefix 25)
            WorkOnParseSubnet("10.1.2.128/25"); // subnet unchanged.
            WorkOnParseSubnet("10.1.2.129/25"); // subnet change to 128 to accommodate /25 (128 address spaces)
            WorkOnParseSubnet("2001:db8:0:0:0:0:0:0/126");
            WorkOnParseSubnet("2001:db8:0:0:0:0:0:FFFC/126"); // Subnet unchanged to 2001:db8::FFFC because enough space available for prefix 126
            WorkOnParseSubnet("2001:db8:0:0:0:0:0:FFFF/126"); // Subnet supposed to change to 2001:db8::FFFC

            WorkOnParseSubnet("2001:db8:0:0:0:0:FFFF:0/112"); // Subnet unchanged
            WorkOnParseSubnet("2001:db8:0:0:0:0:FFFF:1/112"); // Subnet change to 2001:db8::FFFF:0 because 112 need full last four.
            WorkOnParseSubnet("2001:db8:0:0:0:0:FFFF:FF/112"); // Subnet change to 2001:db8::FFFF:0 because 112 need full last four.
            WorkOnParseSubnet("2001:db8:0:0:0:0:FFFE:0/112"); // Subnet unchanged

            WorkOnParseSubnet("CAFE:43::/104"); // Subnet unchanged            

            WorkOnParseSubnet("CAFE:43::FF01:0000/104"); // Subnet change to FF00:0 to accommodate /104.
            WorkOnParseSubnet("CAFE:43::FFFF:0100/120"); // subnet unchanged.
            WorkOnParseSubnet("CAFE:43::FFFF:0101/120"); // Subnet change to :0100 to accommodate 120

            WorkOnParseSubnet("CAFE:43::FFFF:0200/120"); // subnet unchanged.
            WorkOnParseSubnet("CAFE:43::FFFF:0201/120"); // Subnet change to :0200 to accommodate 120

            WorkOnParseSubnet("CAFE:43::FFFF:0200/120"); // subnet unchanged.
            WorkOnParseSubnet("CAFE:43::FFFF:0201/120"); // Subnet change to :0200 to accommodate 120
            */


            string[] hexStrings = { "80", "E293", "F9A2FF", "FFFFFFFF",
                              "080", "0E293", "0F9A2FF", "0FFFFFFFF",
                              "0080", "00E293", "00F9A2FF", "00FFFFFFFF" };
            foreach (string hexString in hexStrings)
            {
                BigInteger number = BigInteger.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
                Console.WriteLine("Converted 0x{0} to {1}.", hexString, number);
            }

            DisplayV4ToV6IP("0.0.0.0");
            DisplayV4ToV6IP("10.1.1.0");
            DisplayV4ToV6IP("255.255.255.255");


            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 0);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 1);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 2);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 3);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 4);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 5);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 6);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 7);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 8);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 9);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 10);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 11);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 12);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 13);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 14);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 2);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 32);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 0);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 1);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetwork, 16);



            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 0);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 1);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 2);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 3);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 4);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 5);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 6);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 7);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 8);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 9);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 10);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 11);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 12);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 13);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 14);

            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 124);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 125);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 126);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 127);
            DisplayNRPGetSubnetMask(AddressFamily.InterNetworkV6, 128);

        }

        public static void DisplayNRPGetSubnetMask(AddressFamily addressFamily, uint prefix)
        {
            Console.WriteLine("");
            Console.WriteLine("=============== Displaying NRP GetSubnetMask Address Family: {0}, Prefix: {1} ====================", addressFamily, prefix);
            try
            {
                IPAddress ip = IPHelpers.NRPGetSubnetMask(addressFamily, prefix);
                Console.WriteLine("Address Family: {0}, prefix: {1}, Subnet mask: {2}", addressFamily, prefix, ip);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Details: {0}", e);
            }
        }
        public static void DisplayV4ToV6IP(string ip)
        {
            Console.WriteLine("");
            Console.WriteLine("=============== Displaying V4 ip: {0} ====================", ip);
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                BigInteger bigIntegerAddress = IPHelper.ConvertIPAddressToBigInteger(ipAddress);

                IPAddress convertedIP = IPHelper.ConvertBigIntegerToIPAddress(bigIntegerAddress, AddressFamily.InterNetworkV6);
                Console.WriteLine("Converted Big Integer: {0}, corresponding IPV6 Address: {1}, its family: {2}", bigIntegerAddress,
                    convertedIP, convertedIP.AddressFamily);

                bigIntegerAddress++;
                convertedIP = IPHelper.ConvertBigIntegerToIPAddress(bigIntegerAddress, AddressFamily.InterNetworkV6);
                Console.WriteLine("Converted Big Integer: {0}, corresponding IPV6 Address: {1}, its family: {2}", bigIntegerAddress,
                    convertedIP, convertedIP.AddressFamily);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Details: {0}", e);
            }
        }

        public static void WorkOnIP(string ip, int increment)
        {
            Console.WriteLine("");
            Console.WriteLine("=============== Working on ip: {0} ====================", ip);
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                BigInteger bigIntegerAddress = IPHelper.ConvertIPAddressToBigInteger(ipAddress);
                Console.WriteLine("Converted Big Integer: {0}", bigIntegerAddress);
                Console.WriteLine("Same IPAddress back to IPAddressObject: {0}", ip);
                Console.WriteLine("Converted IP Address: {0}", IPHelper.ConvertBigIntegerToIPAddress(bigIntegerAddress, ipAddress.AddressFamily));

                Console.WriteLine("Incrementing IPAddress: {0}, to {1}", ip, increment);
                bigIntegerAddress += increment;
                Console.WriteLine("Converted IP Address: {0}", IPHelper.ConvertBigIntegerToIPAddress(bigIntegerAddress, ipAddress.AddressFamily));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Details: {0}", e);
            }
        }

        public static void WorkOnSubnetMask(string ip, byte prefix, AddressFamily addressFamily)
        {
            Console.WriteLine("");
            Console.WriteLine("################ Working on SubnetMask: {0} with prefix: {1} ################", ip, prefix);
            try
            {
                UInt64 mask = IPHelper.GetHostMask(prefix);
                IPHelper.DisplayBitConverter((UInt32)mask, string.Format("Mask For Prefix: {0}", prefix));

                UInt64 subnetMask = IPHelper.GetSubnetMask(prefix);
                IPHelper.DisplayBitConverter((UInt32)subnetMask, string.Format("Subnet Mask For Prefix: {0}", prefix));

                BigInteger bigMask = IPHelper.GetHostMaskGeneric(prefix, addressFamily);
                IPHelper.DisplayBitConverter(bigMask, string.Format("Big Host Mask For Prefix: {0}", prefix));

                BigInteger bigSubnetMask = IPHelper.GetSubnetMaskGeneric(prefix, addressFamily);
                IPHelper.DisplayBitConverter(bigSubnetMask, string.Format("Big SubNet Mask For Prefix: {0}", prefix));

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Details: {0}", e);
            }
        }

        public static void WorkOnParseSubnet(string subnet)
        {
            Console.WriteLine("");
            Console.WriteLine("################ Working on Subnet: {0} ################", subnet);

            IPHelpers.ParseSubnet(subnet);
        }
    }


    /// <summary>
    /// Helper class exposing functions to handle IP addresses.
    /// </summary>
    internal class IPHelpers
    {
        internal const char PrefixDelimiter = '/';

        /// <summary>
        /// Byte count of IPv4 address.
        /// </summary>
        internal const byte IPAddressByteCount = 4;

        /// <summary>
        /// Byte count of IPv4 address.
        /// </summary>
        internal const byte IPAddressV6ByteCount = 16;

        /// <summary>
        /// This helper function parses an input string array into an array of subnets. 
        /// Each string in the array has the following format        
        ///   "10.0.0.0/8"
        /// Note, the full IP address must be specified instead "10/8".
        /// </summary>
        /// <param name="addressSpace">Supply the address space string array.</param>
        /// <returns>
        /// If the string array are parsed successfully, an array of IPSubnet is returned. 
        /// Otherwise, exception can be thrown due to parsing error.
        /// </returns>
        internal static IPSubnet[] ParseAddressSpace(string[] addressSpace)
        {
            IPSubnet[] subnets = new IPSubnet[addressSpace.Length];

            // Parse each string into a subnet.
            for (int index = 0; index < addressSpace.Length; index++)
            {
                subnets[index] = IPHelpers.ParseSubnet(addressSpace[index]);
            }

            return subnets;
        }
        /*
        /// <summary>
        /// This helper function parses an input array of subnet types (subnet name, subnet string)
        /// into an collection of subnets keyed by the subnet name.
        /// Each element in the the collection has the following format
        ///     Key: Subnet Name  Value = IPAddress/Prefix        
        /// Note, the full IP address must be specified instead "10/8".
        /// </summary>
        /// <param name="predefinedSubnets">Supply the predefined subnet array.</param>
        /// <returns>
        /// If the string array are parsed successfully, a dictionary of IPSubnet is returned. 
        /// Otherwise, exception can be thrown due to parsing error.
        /// </returns>
        internal static Dictionary<string, IPSubnet> ParsePredefinedSubnets(
            SubnetType[] predefinedSubnets)
        {
            // Parse the predefined subnet array.
            Dictionary<string, IPSubnet> predefinedSubnetCollection =
                new Dictionary<string, IPSubnet>();

            int predefinedSubnetCount = predefinedSubnets.Length;

            for (int index = 0; index < predefinedSubnetCount; index++)
            {
                // Parse the subnet string.
                SubnetType subnet = predefinedSubnets[index];

                predefinedSubnetCollection.Add(
                    subnet.name.ToLower(),
                    IPHelpers.ParseSubnet(subnet.AddressPrefix));
            }

            return predefinedSubnetCollection;
        }

        internal static RnmIPSubnet ToRnmIPSubnet(SubnetBase subnetBase)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(subnetBase.IPAddress);
                return new RnmIPSubnet(ipAddress, subnetBase.Prefix);
            }

            catch (Exception exception)
            {
                throw new VnetManagementException(
                    exception,
                    string.Format("ParseSubnet: Failed to parse as subnet string is invalid IPAddress:{0}, Prefix:{1}",
                        subnetBase.IPAddress,
                        subnetBase.Prefix),
                    VnetErrorCode.InvalidSubnetString);
            }
        }

        internal static IPSubnet ToIPSubnet(SubnetBase subnetBase)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(subnetBase.IPAddress);
                return new IPSubnet
                {
                    IPAddress = ipAddress,
                    Prefix = subnetBase.Prefix
                };
            }
            catch (Exception exception)
            {
                throw new VnetManagementException(
                    exception,
                    string.Format("ParseSubnet: Failed to parse as subnet string is invalid IPAddress:{0}, Prefix:{1}",
                        subnetBase.IPAddress,
                        subnetBase.Prefix),
                    VnetErrorCode.InvalidSubnetString);
            }
        }
        */

        /// <summary>
        /// This helper function parse an input string into an IP subnet. The format of the string
        /// is the following: IPAddress/Prefix. Note, the IPAddress must be the complete IP 
        /// address, instead of just the valid bits of the subnet. For example, 10/8 must be
        /// written as "10.0.0.0/8".
        /// </summary>
        /// <param name="subnetString">Supply the input string to parse.</param>
        /// <returns>
        /// If the string is parsed successfully, an IP subnet object is returned. 
        /// Otherwise, exception can be thrown due to parsing error.
        /// </returns>
        internal static IPSubnet ParseSubnet(string subnetString)
        {
            try
            {
                string[] tokens = subnetString.Split(IPHelpers.PrefixDelimiter);
                if (tokens.Length != 2)
                {
                    throw new FormatException("Subnet string is invalid.");
                }

                IPSubnet subnet = new IPSubnet
                {
                    Prefix = byte.Parse(tokens[1])
                };

                // Mask off any non-zero bit in host bits.
                IPAddress ipAddress = IPAddress.Parse(tokens[0]);

                BigInteger ipAddressInUInt32 = IPHelpers.ConvertIPAddressToBigInteger(ipAddress);
                BigInteger subnetMask = IPHelpers.GetSubnetMask(subnet.Prefix, ipAddress.AddressFamily);
                subnet.IPAddress = IPHelpers.ConvertBigIntegerToIPAddress(
                    ipAddressInUInt32 & subnetMask, ipAddress.AddressFamily);
                Console.WriteLine("ipAddress {0} parsed to BigInteger: {1}, Subnet Mask: {2}, Address Family: {3}, Converted subnet IPAddress: {4}",
                    tokens[0], ipAddressInUInt32, subnetMask, ipAddress.AddressFamily, subnet.IPAddress);
                IPHelper.DisplayBitConverter(subnetMask, "Subnetmask from previous implementation");

                ipAddressInUInt32 = IPHelpers.ConvertIPAddressToBigInteger(ipAddress);
                subnetMask = IPHelpers.GetSubnetMaskGeneric(subnet.Prefix, ipAddress.AddressFamily);
                subnet.IPAddress = IPHelpers.ConvertBigIntegerToIPAddress(
                    ipAddressInUInt32 & subnetMask, ipAddress.AddressFamily);
                Console.WriteLine("[GENERIC] ipAddress {0} parsed to BigInteger: {1}, Subnet Mask: {2}, Address Family: {3}, Converted subnet IPAddress: {4}",
                    tokens[0], ipAddressInUInt32, subnetMask, ipAddress.AddressFamily, subnet.IPAddress);
                IPHelper.DisplayBitConverter(subnetMask, "Subnetmask from Generic implementation");


                return subnet;
            }
            catch (Exception exception)
            {
                throw new Exception(
                    string.Format("ParseSubnet: Failed to parse as subnet string is invalid:{0}, Exception: {1}", subnetString, exception));
            }
        }
        /*
        /// <summary>
        /// Build a string represenation of an IP subnet with the following format: "10.0.0.0/8".
        /// </summary>
        /// <param name="subnet"></param>
        /// <returns></returns>
        internal static string BuildSubnetString(SubnetBase subnet)
        {
            return string.Format(
                "{0}{1}{2}", subnet.IPAddress, IPHelpers.PrefixDelimiter, subnet.Prefix);
        }

        /// <summary>
        /// Build a string representation of a list of subnets separated with predefined
        /// separator.
        /// </summary>
        /// <param name="subnetCollection">Supply the subnets of an address space.</param>
        /// <returns>String representation of the address space.</returns>
        internal static string[] BuildAddressSpaceString(SubnetBase[] subnetCollection)
        {
            string[] addressSpace = new string[subnetCollection.Length];
            for (int index = 0; index < addressSpace.Length; index++)
            {
                addressSpace[index] = IPHelpers.BuildSubnetString(subnetCollection[index]);
            }

            return addressSpace;
        }
        */

        internal static IPAddress NRPGetSubnetMask(AddressFamily addressFamily, uint prefixLength)
        {

            byte[] mask = new byte[addressFamily == AddressFamily.InterNetwork ? 4 : 16];

            for (int i = 0; i < prefixLength; i++)
            {
                mask[i / 8] |= (byte)(1U << (7 - (i % 8)));
            }

            return new IPAddress(mask);
        }

        /// <summary>
        /// Helper function to convert an IPv4 address string to a host order UInt32.
        /// </summary>
        /// <param name="ipAddressString">Supply the IPv4 address string.</param>
        /// <returns>IPv4 address as UInt32 in host order.</returns>
        internal static UInt32 ConvertIPAddressToUint32(string ipAddressString)
        {
            return IPHelpers.ConvertIPAddressToUint32(IPAddress.Parse(ipAddressString));
        }

        /// <summary>
        /// Helper function to convert an IPv4 address to a host order UInt32.
        /// </summary>
        /// <param name="ipAddress">Supply the IPv4 address.</param>
        /// <returns>IPv4 address as UInt32 in host order.</returns>
        internal static UInt32 ConvertIPAddressToUint32(IPAddress ipAddress)
        {
            Int32 addressInInt32 = BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0);
            return (UInt32)(IPAddress.NetworkToHostOrder(addressInInt32));
        }

        /// <summary>
        /// Helper function to convert an IPv4 or IPv6 address to a host order BigInteger.
        /// </summary>
        /// <param name="ipAddress">Supply the IPv4 or IPv6 address.</param>
        /// <returns>IPv4 address as BigInteger in host order.</returns>       
        internal static BigInteger ConvertIPAddressToBigInteger(IPAddress ipAddress)
        {
            byte[] addressBytes = ipAddress.GetAddressBytes();

            byte[] paddedAddressBytes = GetUnsignedBigEndianBytes(addressBytes);

            return new BigInteger(paddedAddressBytes);
        }

        /// <summary>
        /// Helper function to convert BigInteger (host order) to IPAddress.
        /// </summary>
        /// <param name="ipAddressInBigInteger">Supply the IP address in BigInteger.</param>
        /// <param name="addressFamily">Address family of the IP address to parse.</param>
        /// <returns>Converted IPAddress.</returns>
        internal static IPAddress ConvertBigIntegerToIPAddress(BigInteger ipAddressInBigInteger, AddressFamily addressFamily)
        {
            byte[] addressBytes = ipAddressInBigInteger.ToByteArray();
            byte[] unPaddedAddressBytes;

            // Remove padding and get the right size array based on addressfamily
            int arrayLength = (addressFamily == AddressFamily.InterNetworkV6) ? IPAddressV6ByteCount : IPAddressByteCount;
            unPaddedAddressBytes = new byte[arrayLength];
            Array.Copy(addressBytes, unPaddedAddressBytes, addressBytes.Length <= arrayLength ? addressBytes.Length : arrayLength);

            if (BitConverter.IsLittleEndian)
            {
                //little-endian machines store multi-byte integers with the 
                //least significant byte first. this is a problem, as integer 
                //values are sent over the network in big-endian mode. reversing 
                //the order of the bytes is a quick way to get the BitConverter 
                //methods to convert the byte arrays in big-endian mode.
                Array.Reverse(unPaddedAddressBytes);
            }

            return new IPAddress(unPaddedAddressBytes);
        }

        private static byte[] GetUnsignedBigEndianBytes(byte[] addressBytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                //little-endian machines store multi-byte integers with the 
                //least significant byte first. this is a problem, as integer 
                //values are sent over the network in big-endian mode. reversing 
                //the order of the bytes is a quick way to get the BitConverter 
                //methods to convert the byte arrays in big-endian mode.
                Array.Reverse(addressBytes);
            }

            // Pad with zero to prevent negative numbers
            byte[] paddedAddressBytes = new byte[addressBytes.Length + 1];
            Array.Copy(addressBytes, paddedAddressBytes, addressBytes.Length);
            return paddedAddressBytes;
        }

        /// <summary>
        /// Helper function to convert an UInt32 (host order) to IPAddress.
        /// </summary>
        /// <param name="ipAddressInUInt32">Supply the IP address in UInt32.</param>
        /// <returns>Converted IPAddress.</returns>
        internal static IPAddress ConvertUInt32ToIPAddress(UInt32 ipAddressInUInt32)
        {
            return new IPAddress(
                BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int32)ipAddressInUInt32)));
        }

        /// <summary>
        /// Helper function that get the string representation of an IP address in UInt32 
        /// (host order).
        /// </summary>
        /// <param name="ipAddress">Supply the IPv4 address in UInt32.</param>
        /// <returns>String representation of the IPv4 address.</returns>
        internal static string GetIPAddressString(UInt32 ipAddress)
        {
            return IPHelpers.ConvertUInt32ToIPAddress(ipAddress).ToString();
        }

        /// <summary>
        /// Helper function that get the string representation of an IP address
        /// in UInt32 (host order).
        /// </summary>
        /// <param name="addressArray">Supply the IPv4 address in byte array.</param>
        /// <returns>String representation of the IPv4 address.</returns>
        internal static string GetIPAddressString(byte[] addressArray)
        {
            IPAddress ipAddress = new IPAddress(addressArray);

            return ipAddress.ToString();
        }

        /// <summary>
        /// Helper function that get the string representation of the MAC address.
        /// </summary>
        /// <param name="addressArray">Supply the MAC in byte array.</param>
        /// <returns>String representation of the MAC address.</returns>
        internal static string GetMacAddressString(byte[] addressArray)
        {
            return string.Join("", addressArray.Select(x => x.ToString("x2")).ToArray());
        }

        /// <summary>
        /// Helper function to return the host mask for the given IP address prefix.
        /// </summary>
        /// <param name="prefix">Supply the prefix to use.</param>
        /// <param name="addressFamily">Address family of subnet. By default it is V4</param>
        /// <returns>Host mask.</returns>
        internal static UInt32 GetHostMask(byte prefix, AddressFamily addressFamily)
        {
            return ((1U << (IPHelpers.IPAddressByteCount * 8 - prefix)) - 1);
        }

        internal static UInt64 GetHostMask64(byte prefix, AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            UInt64 U1 = 1;
            return (addressFamily == AddressFamily.InterNetworkV6) ?
                ((prefix == 0) ? UInt64.MaxValue : ((U1 << (64 - prefix)) - 1)) :
                ((U1 << (IPHelpers.IPAddressByteCount * 8 - prefix)) - 1);
        }

        internal static BigInteger GetHostMaskGeneric(byte prefix, AddressFamily addressFamily)
        {
            return ~GetSubnetMaskGeneric(prefix, addressFamily);
        }

        /// <summary>
        /// Helper function to return the subnet mask for the given prefix.
        /// </summary>
        /// <param name="prefix">Supply the prefix to use.</param>
        /// <returns>Subnet mask.</returns>
        internal static BigInteger GetSubnetMask(byte prefix, AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            return ~IPHelpers.GetHostMask(prefix, addressFamily);
        }
        internal static BigInteger GetSubnetMaskGeneric(byte prefix, AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            BigInteger mask = 1;
            mask = (mask << prefix) - 1;
            mask <<= (addressFamily == AddressFamily.InterNetworkV6 ? 128 : 32) - prefix;
            return mask;
        }

        /// <summary>
        /// Helper function to calculate the prefix of the smallest subnet that can provide the
        /// the specified number of IP address.
        /// </summary>
        /// <param name="addressCount"></param>
        /// <returns></returns>
        internal static byte CalculateSubnetPrefix(UInt32 addressCount)
        {
            // Find the position of the most significant non-zero bit of addressCount.
            byte msbPosition = 0;
            UInt32 subnetAddressCount = addressCount;
            while (true)
            {
                subnetAddressCount >>= 1;
                if (subnetAddressCount == 0)
                {
                    break;
                }

                msbPosition++;
            }

            // If the addressCount is not a perfect power of two, need to add one more bit.
            subnetAddressCount = 1U << msbPosition;
            if (subnetAddressCount < addressCount)
            {
                msbPosition++;
            }

            return (byte)(IPHelpers.IPAddressByteCount * 8 - msbPosition);
        }

        /*
        /// <summary>
        /// Helper function to determine if the address space is changed.
        /// </summary>
        /// <param name="existingAddressSpace">Supply the existing address space.</param>
        /// <param name="newAddressSpace">Supply the new address space.</param>
        /// <returns>True if the two are differnet. False, otherwise.</returns>
        internal static bool IsAddressSpaceChanged(
            SubnetBase[] existingAddressSpace,
            IPSubnet[] newAddressSpace
            )
        {
            // If the number of subnets are different, the address space has changed.
            //
            // N.B. The assumption is that there is no overlap of the subnets in the address
            //      space.
            if (existingAddressSpace.Length != newAddressSpace.Length)
            {
                return true;
            }

            // Declare a hash table that maps UInt32 representation of the subnet IP address
            // to prefix.
            Dictionary<UInt32, byte> subnetMapping =
                new Dictionary<uint, byte>(existingAddressSpace.Length);

            // Populate the hash table based on the existing address space.
            foreach (SubnetBase subnet in existingAddressSpace)
            {
                subnetMapping.Add(
                    IPHelpers.ConvertIPAddressToUint32(subnet.IPAddress),
                    subnet.Prefix);
            }

            // Check if the subnets from the new address space are contained in the existing
            // address space.
            foreach (IPSubnet subnet in newAddressSpace)
            {
                UInt32 ipAddress = IPHelpers.ConvertIPAddressToUint32(subnet.IPAddress);
                byte prefix;
                if ((subnetMapping.TryGetValue(ipAddress, out prefix) == false) ||
                    (prefix != subnet.Prefix))
                {
                    return true;
                }
            }

            return false;
        }
        

        /// <summary>
        /// Helper function to determine if two IP subnets are the same.
        /// </summary>
        /// <param name="existingSubnet">Supply the existing subnet.</param>
        /// <param name="newSubnet">Supply the new subnet.</param>
        /// <returns>True if the two subnets are different. False, otherwise.</returns>
        internal static bool IsSubnetChanged(
            SubnetBase existingSubnet,
            IPSubnet newSubnet
            )
        {
            IPSubnet existingIPSubnet = new IPSubnet();
            existingIPSubnet.IPAddress = IPAddress.Parse(existingSubnet.IPAddress);
            existingIPSubnet.Prefix = existingSubnet.Prefix;

            return IsSubnetChanged(existingIPSubnet, newSubnet);
        }
        */

        /// <summary>
        /// Helper function to determine if two IP subnets are the same.
        /// </summary>
        /// <param name="existingSubnet">Supply the existing subnet.</param>
        /// <param name="newSubnet">Supply the new subnet.</param>
        /// <returns>True if the two subnets are different. False, otherwise.</returns>
        internal static bool IsSubnetChanged(
            IPSubnet existingSubnet,
            IPSubnet newSubnet
            )
        {
            if (newSubnet.IPAddress.Equals(existingSubnet.IPAddress) &&
                (newSubnet.Prefix == existingSubnet.Prefix))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Helper function to determine if two IP subnets overlap.
        /// </summary>
        /// <param name="firstSubnet">Supply the first subnet.</param>
        /// <param name="secondSubnet">Supply the second subnet.</param>
        /// <returns>True if the two subnets overlap. False, otherwise.</returns>
        internal static bool AreOverlappingSubnets(
            IPSubnet firstSubnet,
            IPSubnet secondSubnet
            )
        {
            Byte prefixLength;

            // Pick the smallest prefix of the two subnet prefixes to compute the network address.
            if (firstSubnet.Prefix < secondSubnet.Prefix)
            {
                prefixLength = firstSubnet.Prefix;
            }
            else
            {
                prefixLength = secondSubnet.Prefix;
            }

            BigInteger firstSubnetNetworkAddress =
                (IPHelpers.ConvertIPAddressToBigInteger(firstSubnet.IPAddress) &
                 IPHelpers.GetSubnetMask(prefixLength, firstSubnet.IPAddress.AddressFamily));

            BigInteger secondSubnetNetworkAddress =
                (IPHelpers.ConvertIPAddressToBigInteger(secondSubnet.IPAddress) &
                 IPHelpers.GetSubnetMask(prefixLength, secondSubnet.IPAddress.AddressFamily));

            if (firstSubnetNetworkAddress == secondSubnetNetworkAddress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Helper function to check if the subnets in a list are exclusive (i.e.) non overlapping.
        /// </summary>
        /// <param name="subnets">Supply the list of subnets.</param>
        /// <returns>True if there are no overlapping subnets, False otherwise.</returns>
        internal static bool AreSubnetsSelfContained(IPSubnet[] subnets)
        {
            int overlappedIndex1 = 0;
            int overlappedIndex2 = 0;

            return AreSubnetsSelfContained(subnets, out overlappedIndex1, out overlappedIndex2);
        }

        /// <summary>
        /// Helper function to check if the subnets in a list are exclusive (i.e.) non overlapping.
        /// If overlapping returns the indices of the overlapping subnets in the subnet array.
        /// </summary>
        /// <param name="subnets">Supply the list of subnets.</param>
        /// <param name="overlappedIndex1">
        /// If overlapping, contains the first index of the overlapping subnet in the subnet array.
        /// </param>
        /// <param name="overlappedIndex2">
        /// If overlapping, contains the second index of the overlapping subnet in the subnet array.
        /// subnet.        /// </param>
        /// <returns>True if there are no overlapping subnets, False otherwise.</returns>
        internal static bool AreSubnetsSelfContained(
            IPSubnet[] subnets,
            out int overlappedIndex1,
            out int overlappedIndex2)
        {
            overlappedIndex2 = 0;
            for (overlappedIndex1 = 0; overlappedIndex1 < subnets.Length; overlappedIndex1++)
            {
                for (overlappedIndex2 = overlappedIndex1 + 1;
                    overlappedIndex2 < subnets.Length;
                    overlappedIndex2++)
                {
                    if (IPHelpers.AreOverlappingSubnets(
                        subnets[overlappedIndex1],
                        subnets[overlappedIndex2]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Helper function to check if a given subnet is contained within a subnet that is 
        /// part of a subnet collection.
        /// </summary>
        /// <param name="subnet">Supply the subnet.</param>
        /// <param name="subnetCollection">Supply the subnet collection.</param>
        /// <param name="location">The index where the item was found.</param>
        /// <returns>
        /// True if there is a subnet in the collection that contains the given subnet range, 
        /// False otherwise.
        /// </returns>
        internal static bool IsSubnetContainedInCollection(
            IPSubnet[] subnetCollection,
            IPSubnet subnet,
            out int location)
        {
            location = -1;
            for (int index = 0; index < subnetCollection.Length; index++)
            {
                if (subnetCollection[index].Prefix <= subnet.Prefix)
                {
                    if (IPHelpers.AreOverlappingSubnets(subnetCollection[index], subnet))
                    {
                        location = index;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Helper function to check if a given subnet is contained within a subnet that is 
        /// part of a subnet collection.
        /// </summary>
        /// <param name="subnet">Supply the subnet.</param>
        /// <param name="subnetCollection">Supply the subnet collection.</param>
        /// <returns>
        /// True if there is a subnet in the collection that contains the given subnet range, 
        /// False otherwise.
        /// </returns>
        internal static bool IsSubnetContainedInCollection(
            IPSubnet[] subnetCollection,
            IPSubnet subnet)
        {
            int location;
            return IsSubnetContainedInCollection(subnetCollection, subnet, out location);
        }

        /// <summary>
        /// Helper function to determine if an IPAddress list has changed.
        /// </summary>
        /// <param name="existingIPAddresses">Supply the existing list of IP addresses.</param>
        /// <param name="newIPAddresses">Supply the new list of IP addresses.</param>
        /// <returns>True if the two are different. False, otherwise.</returns>
        internal static bool HasIPAddressListChanged(
            List<IPAddress> existingIPAddresses,
            List<IPAddress> newIPAddresses
            )
        {
            if (existingIPAddresses.Count != newIPAddresses.Count)
            {
                return true;
            }

            // Declare a hash table that maps UInt32 representation of the IP address.
            HashSet<UInt32> addressSet = new HashSet<UInt32>();

            // Populate the hash table based on the existing address space.
            foreach (IPAddress ipAddress in existingIPAddresses)
            {
                addressSet.Add(
                    IPHelpers.ConvertIPAddressToUint32(ipAddress));
            }

            // Check if the addresses from the new address list are contained in the existing
            // address list.
            foreach (IPAddress ipAddress in newIPAddresses)
            {
                if (addressSet.Contains(IPHelpers.ConvertIPAddressToUint32(ipAddress)) == false)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Helper function to determine if an IPAddress is part of the given subnet.
        /// </summary>
        /// <param name="ipString">Supply the IP addresses string.</param>
        /// <param name="subnetString">Supply the subnet string.</param>
        /// <returns>True if the given IP address is part of the given subnet.</returns>
        internal static bool IsIPv4InSubnet(
            string ipString,
            string subnetString)
        {
            IPSubnet subnet = IPHelpers.ParseSubnet(subnetString);
            IPAddress ip = IPAddress.Parse(ipString);

            return IsIPv4InSubnet(ip, subnet);
        }
        /// <summary>
        /// Helper function to determine if an IPAddress is part of the given subnet.
        /// </summary>
        /// <param name="ip">Supply the IP addresses.</param>
        /// <param name="subnet">Supply the subnet.</param>
        /// <returns>True if the given IP address is part of the given subnet.</returns>
        internal static bool IsIPv4InSubnet(
            IPAddress ip,
            IPSubnet subnet)
        {
            UInt32 ipInt32 = ConvertIPAddressToUint32(ip);
            UInt32 mask = (UInt32)GetSubnetMask(subnet.Prefix); // TODO:Hanu Check this casting.
            UInt32 subnetIpInt32 = ConvertIPAddressToUint32(subnet.IPAddress);

            return ((ipInt32 & mask) == (subnetIpInt32 & mask));
        }
    }


    /// <summary>
    /// Helper class exposing functions to handle IP addresses.
    /// </summary>
    internal class IPHelper
    {
        internal const char PrefixDelimiter = '/';
        internal const byte IPAddressByteCount = 4;
        internal const byte IPAddressV6ByteCount = 16;

        internal static UInt32 ConvertIPAddressToUint32(IPAddress ipAddress)
        {
            Int32 addressInInt32 = BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0);
            DisplayBitConverter((UInt32) addressInInt32, string.Format("{0}", ipAddress.ToString()));

            UInt32 hostOrderUInt32 = (UInt32)(IPAddress.NetworkToHostOrder(addressInInt32));
            DisplayBitConverter((UInt32)hostOrderUInt32, string.Format("NetworkToHostOrder of {0}", ipAddress.ToString()));

            Console.WriteLine(">> Converted IP Address {0} to UInt32: {1}", ipAddress.ToString(), hostOrderUInt32);
            Console.WriteLine("");
            return hostOrderUInt32;
        }
        
        internal static IPAddress ConvertUInt32ToIPAddress(UInt32 ipAddressInUInt32)
        {
            DisplayBitConverter(ipAddressInUInt32, "Convert UInt32 to IPAddress");
            int ipAddressNetworkOrder = IPAddress.HostToNetworkOrder((Int32)ipAddressInUInt32);
            DisplayBitConverter((UInt32)ipAddressNetworkOrder, "Host to Network Order");
            IPAddress ipAddress = new IPAddress(BitConverter.GetBytes(ipAddressNetworkOrder));
            Console.WriteLine(">> Converted UInt32 {0} to IPAddress: {1}", ipAddressNetworkOrder, ipAddress.ToString());
            Console.WriteLine("");
            return ipAddress;
        }

        /// <summary>
        /// Helper function to convert an IPv4 or IPv6 address to a host order BigInteger.
        /// </summary>
        /// <param name="ipAddress">Supply the IPv4 or IPv6 address.</param>
        /// <returns>IPv4 address as BigInteger in host order.</returns>       
        internal static BigInteger ConvertIPAddressToBigInteger(IPAddress ipAddress)
        {
            byte[] addressBytes = ipAddress.GetAddressBytes();

            byte[] paddedAddressBytes = GetUnsignedBigEndianBytes(addressBytes);

            return new BigInteger(paddedAddressBytes);
        }

        /// <summary>
        /// Helper function to convert BigInteger (host order) to IPAddress.
        /// </summary>
        /// <param name="ipAddressInBigInteger">Supply the IP address in BigInteger.</param>
        /// <returns>Converted IPAddress. NOTE: Caller have to handle ipAddressInBigInteger with value 0 for IPV6, it returns as IPV4</returns> // TODO:Hanu Resolve this.
        internal static IPAddress ConvertBigIntegerToIPAddress(BigInteger ipAddressInBigInteger, System.Net.Sockets.AddressFamily addressFamily)
        {
            byte[] addressBytes = ipAddressInBigInteger.ToByteArray();
            byte[] unPaddedAddressBytes;

            // Remove padding and get the right size array based on addressfamily
            int arrayLength = (addressFamily == AddressFamily.InterNetworkV6) ? 16 : 4;            
            unPaddedAddressBytes = new byte[arrayLength];
            Array.Copy(addressBytes, unPaddedAddressBytes, addressBytes.Length <= arrayLength ? addressBytes.Length : arrayLength);

            if (BitConverter.IsLittleEndian)
            {
                //little-endian machines store multi-byte integers with the 
                //least significant byte first. this is a problem, as integer 
                //values are sent over the network in big-endian mode. reversing 
                //the order of the bytes is a quick way to get the BitConverter 
                //methods to convert the byte arrays in big-endian mode.
                Array.Reverse(unPaddedAddressBytes);
            }

            return new IPAddress(unPaddedAddressBytes);
        }

        private static byte[] GetUnsignedBigEndianBytes(byte[] addressBytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                //little-endian machines store multi-byte integers with the 
                //least significant byte first. this is a problem, as integer 
                //values are sent over the network in big-endian mode. reversing 
                //the order of the bytes is a quick way to get the BitConverter 
                //methods to convert the byte arrays in big-endian mode.
                Array.Reverse(addressBytes);
            }

            // Pad with zero to prevent negative numbers
            byte[] paddedAddressBytes = new byte[addressBytes.Length + 1];
            Array.Copy(addressBytes, paddedAddressBytes, addressBytes.Length);
            return paddedAddressBytes;
        }

        internal static void DisplayBitConverter(UInt32 value, string context)
        {
            Console.WriteLine("From {0}, UInt32 Value: {1}", context, value);
            string bin = Convert.ToString(value, 2).PadLeft(32, '0');

            for (int i = 0; i < bin.Length; i++)
            {
                if (i % 5 == 0)
                { bin = bin.Insert(i, " "); }
            }
            string[] binList = bin.Trim().Split(' ');

            Console.WriteLine(" Formatted: [{0}-{1} {2}-{3} {4}-{5} {6}-{7}]", binList[0], binList[1], binList[2], binList[3], binList[4], binList[5], binList[6], binList[7]);

        }

        public static void DisplayBitConverter(BigInteger value, string context)
        {
            Console.WriteLine("From {0}, BigInteger Value: {1}", context, value);
            byte[] valueBytes = value.ToByteArray();
            Array.Reverse(valueBytes);
            StringBuilder sb = new StringBuilder(valueBytes.Length * (8 + 2));
            foreach (byte valueByte in valueBytes)
            {
                string valueByteBin = Convert.ToString(valueByte, 2).PadLeft(8, '0');
                sb.Append(valueByteBin);
            }
            Console.WriteLine("Formatted: ");
            Console.WriteLine("{0}", FormatBin(sb.ToString()));
        }

        internal static string FormatBin(string binValue)
        {
            for (int i = 0; i < binValue.Length; i++)
            {
                if (i % 5 == 0)
                {
                    string delim = " ";
                    if (i % 10 != 0) delim = "-";
                    binValue = binValue.Insert(i, delim);
                }
            }
            binValue = binValue.Trim();
            int count = 0;
            StringBuilder sb = new StringBuilder();
            foreach (string val in binValue.Split(' '))
            {
                sb.Append(val + " ");
                if (++count % 4 == 0) { sb.Append(System.Environment.NewLine); }
            }
            return sb.ToString();
        }

        public static void DisplayBytes(byte[] bytes, string context)
        {
            Console.WriteLine(context);
            int count = 0;
            foreach (byte b in bytes)
            {
                Console.Write("{0:X}", b);
                if (count % 2 == 1) { Console.Write("-"); }
                count++;
            }
            Console.WriteLine("Context end ---- ---- ");
        }

       

        /// <summary>
        /// Helper function that get the string representation of an IP address in UInt32 
        /// (host order).
        /// </summary>
        /// <param name="ipAddress">Supply the IPv4 address in UInt32.</param>
        /// <returns>String representation of the IPv4 address.</returns>
        internal static string GetIPAddressString(UInt32 ipAddress)
        {
            return IPHelper.ConvertUInt32ToIPAddress(ipAddress).ToString();
        }

        /// <summary>
        /// Helper function that get the string representation of an IP address
        /// in UInt32 (host order).
        /// </summary>
        /// <param name="addressArray">Supply the IPv4 address in byte array.</param>
        /// <returns>String representation of the IPv4 address.</returns>
        internal static string GetIPAddressString(byte[] addressArray)
        {
            IPAddress ipAddress = new IPAddress(addressArray);

            return ipAddress.ToString();
        }

        /// <summary>
        /// Helper function that get the string representation of the MAC address.
        /// </summary>
        /// <param name="addressArray">Supply the MAC in byte array.</param>
        /// <returns>String representation of the MAC address.</returns>
        internal static string GetMacAddressString(byte[] addressArray)
        {
            return string.Join("", addressArray.Select(x => x.ToString("x2")).ToArray());
        }

        /// <summary>
        /// Helper function to return the host mask for the given IP address prefix.
        /// </summary>
        /// <param name="prefix">Supply the prefix to use.</param>
        /// <returns>Host mask.</returns>
        internal static UInt64 GetHostMask(byte prefix, AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            UInt64 U1 = 1;
            if (addressFamily == AddressFamily.InterNetworkV6)
            {
                return (prefix == 0) ? UInt64.MaxValue : ((U1 << (64 - prefix)) - 1);                
            }
            return ((U1 << (IPHelper.IPAddressByteCount * 8 - prefix)) - 1);
        }

        /// <summary>
        /// Helper function to return the subnet mask for the given prefix.
        /// </summary>
        /// <param name="prefix">Supply the prefix to use.</param>
        /// <returns>Subnet mask.</returns>
        internal static UInt64 GetSubnetMask(byte prefix)
        {
            return ~IPHelper.GetHostMask(prefix);
        }

        internal static BigInteger GetHostMaskGeneric(byte prefix, AddressFamily addressFamily)
        {
            byte[] hostMaskByteArray = new byte[] { 0xff, 0xff, 0xff, 0xff, /* padding for sign */ 0x00 };

            if (prefix > 0)
            { 
                byte[] subnetMaskByteArray = (~GetSubnetMaskGeneric(prefix, addressFamily)).ToByteArray();
                hostMaskByteArray = new byte[subnetMaskByteArray.Length -1];
                Array.Copy(subnetMaskByteArray, hostMaskByteArray, hostMaskByteArray.Length);
            }
            else if(addressFamily == AddressFamily.InterNetworkV6)
            {
                hostMaskByteArray = new byte[] {
                    0xff, 0xff, 0xff, 0xff  ,  0xff, 0xff, 0xff, 0xff,
                    0xff, 0xff, 0xff, 0xff  ,  0xff, 0xff, 0xff, 0xff, /* padding for sign */ 0x00 };
            }
            return new BigInteger(hostMaskByteArray);
        }

        /// <summary>
        /// Helper function to return the subnet mask for the given prefix.
        /// </summary>
        /// <param name="prefix">Supply the prefix to use.</param>
        /// <returns>Subnet mask.</returns>        
        internal static BigInteger GetSubnetMaskGeneric(byte prefix, AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            BigInteger mask = 1;
            mask = (mask << prefix) - 1;
            mask <<= (addressFamily == AddressFamily.InterNetworkV6 ? 128 : 32) - prefix;
            return mask;
        }

        /// <summary>
        /// Helper function to calculate the prefix of the smallest subnet that can provide the
        /// the specified number of IP address.
        /// </summary>
        /// <param name="addressCount"></param>
        /// <returns></returns>
        internal static byte CalculateSubnetPrefix(UInt32 addressCount)
        {
            // Find the position of the most significant non-zero bit of addressCount.
            byte msbPosition = 0;
            UInt32 subnetAddressCount = addressCount;
            while (true)
            {
                subnetAddressCount >>= 1;
                if (subnetAddressCount == 0)
                {
                    break;
                }

                msbPosition++;
            }

            // If the addressCount is not a perfect power of two, need to add one more bit.
            subnetAddressCount = 1U << msbPosition;
            if (subnetAddressCount < addressCount)
            {
                msbPosition++;
            }

            return (byte)(IPHelper.IPAddressByteCount * 8 - msbPosition);
        }

        

        /// <summary>
        /// Helper function to determine if two IP subnets overlap.
        /// </summary>
        /// <param name="firstSubnet">Supply the first subnet.</param>
        /// <param name="secondSubnet">Supply the second subnet.</param>
        /// <returns>True if the two subnets overlap. False, otherwise.</returns>
        internal static bool AreOverlappingSubnets(
            IPSubnet firstSubnet,
            IPSubnet secondSubnet
            )
        {
            Byte prefixLength;

            // Pick the smallest prefix of the two subnet prefixes to compute the network address.
            if (firstSubnet.Prefix < secondSubnet.Prefix)
            {
                prefixLength = firstSubnet.Prefix;
            }
            else
            {
                prefixLength = secondSubnet.Prefix;
            }

            UInt64 firstSubnetNetworkAddress =
                (IPHelper.ConvertIPAddressToUint32(firstSubnet.IPAddress) &
                 IPHelper.GetSubnetMask(prefixLength));

            UInt64 secondSubnetNetworkAddress =
                (IPHelper.ConvertIPAddressToUint32(secondSubnet.IPAddress) &
                 IPHelper.GetSubnetMask(prefixLength));

            if (firstSubnetNetworkAddress == secondSubnetNetworkAddress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Helper function to check if the subnets in a list are exclusive (i.e.) non overlapping.
        /// </summary>
        /// <param name="subnets">Supply the list of subnets.</param>
        /// <returns>True if there are no overlapping subnets, False otherwise.</returns>
        internal static bool AreSubnetsSelfContained(IPSubnet[] subnets)
        {
            int overlappedIndex1 = 0;
            int overlappedIndex2 = 0;

            return AreSubnetsSelfContained(subnets, out overlappedIndex1, out overlappedIndex2);
        }

        /// <summary>
        /// Helper function to check if the subnets in a list are exclusive (i.e.) non overlapping.
        /// If overlapping returns the indices of the overlapping subnets in the subnet array.
        /// </summary>
        /// <param name="subnets">Supply the list of subnets.</param>
        /// <param name="overlappedIndex1">
        /// If overlapping, contains the first index of the overlapping subnet in the subnet array.
        /// </param>
        /// <param name="overlappedIndex2">
        /// If overlapping, contains the second index of the overlapping subnet in the subnet array.
        /// subnet.        /// </param>
        /// <returns>True if there are no overlapping subnets, False otherwise.</returns>
        internal static bool AreSubnetsSelfContained(
            IPSubnet[] subnets,
            out int overlappedIndex1,
            out int overlappedIndex2)
        {
            overlappedIndex2 = 0;
            for (overlappedIndex1 = 0; overlappedIndex1 < subnets.Length; overlappedIndex1++)
            {
                for (overlappedIndex2 = overlappedIndex1 + 1;
                    overlappedIndex2 < subnets.Length;
                    overlappedIndex2++)
                {
                    if (IPHelper.AreOverlappingSubnets(
                        subnets[overlappedIndex1],
                        subnets[overlappedIndex2]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Helper function to check if a given subnet is contained within a subnet that is 
        /// part of a subnet collection.
        /// </summary>
        /// <param name="subnet">Supply the subnet.</param>
        /// <param name="subnetCollection">Supply the subnet collection.</param>
        /// <param name="location">The index where the item was found.</param>
        /// <returns>
        /// True if there is a subnet in the collection that contains the given subnet range, 
        /// False otherwise.
        /// </returns>
        internal static bool IsSubnetContainedInCollection(
            IPSubnet[] subnetCollection,
            IPSubnet subnet,
            out int location)
        {
            location = -1;
            for (int index = 0; index < subnetCollection.Length; index++)
            {
                if (subnetCollection[index].Prefix <= subnet.Prefix)
                {
                    if (IPHelper.AreOverlappingSubnets(subnetCollection[index], subnet))
                    {
                        location = index;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Helper function to check if a given subnet is contained within a subnet that is 
        /// part of a subnet collection.
        /// </summary>
        /// <param name="subnet">Supply the subnet.</param>
        /// <param name="subnetCollection">Supply the subnet collection.</param>
        /// <returns>
        /// True if there is a subnet in the collection that contains the given subnet range, 
        /// False otherwise.
        /// </returns>
        internal static bool IsSubnetContainedInCollection(
            IPSubnet[] subnetCollection,
            IPSubnet subnet)
        {
            int location;
            return IsSubnetContainedInCollection(subnetCollection, subnet, out location);
        }

        /// <summary>
        /// Helper function to determine if an IPAddress list has changed.
        /// </summary>
        /// <param name="existingIPAddresses">Supply the existing list of IP addresses.</param>
        /// <param name="newIPAddresses">Supply the new list of IP addresses.</param>
        /// <returns>True if the two are different. False, otherwise.</returns>
        internal static bool HasIPAddressListChanged(
            List<IPAddress> existingIPAddresses,
            List<IPAddress> newIPAddresses
            )
        {
            if (existingIPAddresses.Count != newIPAddresses.Count)
            {
                return true;
            }

            // Declare a hash table that maps UInt32 representation of the IP address.
            HashSet<UInt32> addressSet = new HashSet<UInt32>();

            // Populate the hash table based on the existing address space.
            foreach (IPAddress ipAddress in existingIPAddresses)
            {
                addressSet.Add(
                    IPHelper.ConvertIPAddressToUint32(ipAddress));
            }

            // Check if the addresses from the new address list are contained in the existing
            // address list.
            foreach (IPAddress ipAddress in newIPAddresses)
            {
                if (addressSet.Contains(IPHelper.ConvertIPAddressToUint32(ipAddress)) == false)
                {
                    return true;
                }
            }

            return false;
        }

        
        /// <summary>
        /// Helper function to determine if an IPAddress is part of the given subnet.
        /// </summary>
        /// <param name="ip">Supply the IP addresses.</param>
        /// <param name="subnet">Supply the subnet.</param>
        /// <returns>True if the given IP address is part of the given subnet.</returns>
        internal static bool IsIPv4InSubnet(
            IPAddress ip,
            IPSubnet subnet)
        {
            UInt32 ipInt32 = ConvertIPAddressToUint32(ip);
            UInt64 mask = GetSubnetMask(subnet.Prefix);
            UInt32 subnetIpInt32 = ConvertIPAddressToUint32(subnet.IPAddress);

            return ((ipInt32 & mask) == (subnetIpInt32 & mask));
        }
    }







    [DataContract]
    public class IPSubnet : IEquatable<IPSubnet>
    {
        public const char PrefixDelimiter = '/';

        public IPSubnet() { }

        [DataMember]
        public IPAddress IPAddress { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public byte Prefix { get; set; }

        public bool Equals(IPSubnet other) { return false; }
        public IPAddress GetFirstIPv4Address() { return new IPAddress(0); }
        public override int GetHashCode() { return 0; }
        public IPAddress GetLastIPv4Address() { return new IPAddress(9999); }
        public override string ToString() { return "127.0.0.1/24"; }
        public string ToString(int indentSpaceCount) { return "127.0.0.1/24"; }
    }
}
