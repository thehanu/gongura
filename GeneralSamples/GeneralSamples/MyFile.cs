using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace GeneralSamples
{
    class MyFile
    {
        public static void GetDifferentPaths()
        {
            string assemblyLocation = Assembly.GetEntryAssembly().Location;
            string currentExecutablePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string currentPath = System.IO.Directory.GetCurrentDirectory();

            Console.Write("Assembly Location: {0}, Current Exe path: {1}, Current dir: {2}", assemblyLocation, currentExecutablePath, currentPath);
        }

        public static void GetFiles()
        {
            string[] files = System.IO.Directory.GetFiles(@"d:\code");
            foreach(string file in files)
            {
                Console.WriteLine("File: {0}", file);
            }
        }

        public static void GetFileEncodings()
        {
            GetType(@"C:\code\Networking\RNM\src\sources\BlueBirdManager\ServiceManifest.xml");
            GetType(@"C:\code\Networking\RNM\src\sources\InventoryManager\ServiceManifest.xml");
            GetType(@"C:\code\Networking\RNM\src\sources\ThrottlingPolicyManager\ServiceManifest.xml");
            GetType(@"C:\code\Networking\RNM\src\ServiceModel\WinFabric\PartitionManager\ServiceManifest.xml");
            
        }
        public static System.Text.Encoding GetType(string FILE_NAME = @"C:\temp\MyFileType.xml")
        {
            FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
            Encoding r = GetType(fs);
            fs.Close();
            Console.WriteLine($"Provide File: {FILE_NAME} is of type: {r.ToString()}");
            return r;
        }

        public static System.Text.Encoding GetType(FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //with BOM
            Encoding reVal = Encoding.Default;

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
            {
                reVal = Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = Encoding.Unicode;
            }
            r.Close();
            return reVal;

        }
    }
}
