using System;
using System.Reflection;

namespace TestCode {
    public class TestClass {
        public void TestCase()  {
            // Accessing protected class
            SourceCode.SourceClass mySourceClass = new SourceCode.SourceClass();
            mySourceClass.PublicMethod();

            // Calling Private method of a class with parameters and complex return value.
            MethodInfo privateMethod = typeof(SourceCode.SourceClass).GetMethod
                ("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);                        
            SourceCode.SourceReturnObject obj = (SourceCode.SourceReturnObject)
                privateMethod.Invoke(mySourceClass, new object[] { 100, "Call from TestCase" });

            MethodInfo[] publicMethods = typeof(SourceCode.SourceClass).GetMethods();
            foreach (MethodInfo publicMethod in publicMethods)
            {
                Console.WriteLine("Method Type: {0}", publicMethod.MemberType);
            }

            MethodInfo getValueMethod = typeof(SourceCode.SourceClass).GetMethod
                ("GetValue", BindingFlags.Static | BindingFlags.Public);

            Console.WriteLine("Source Class PublicInt: {0}, Source Return Object int: {1}, string {2}", 
                mySourceClass.publicInt, obj.sourceReturnInt, obj.sourceReturnString);
        }
    }
}
