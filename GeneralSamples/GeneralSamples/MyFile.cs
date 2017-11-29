using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
    }
}
