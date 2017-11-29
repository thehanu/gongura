using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneralSamples
{
    class MyMock
    {
        public static bool MyExternalFunction()
        {
            Console.WriteLine("In My External Funciton");
            return false;
        }
    }
}

[TestClass]
public class TestMyMock
{
    [TestMethod]
    public void TestMyExternalFunction()
    {
        
    }
}
