using System;

namespace SourceCode {    
    class SourceClass {
        public int publicInt = 1;
        protected int protectedInt = 2;

        public void PublicMethod() { Console.WriteLine("I am public method"); }

        public static T GetValue<T>(string settingName)
        {
            return (T)(object)false;
        }

        protected void ProtectedMethod() { Console.WriteLine("I am protected method"); }

        // Complex private method with parameters and complex return value
        private SourceReturnObject PrivateMethod(int value, string myString) {
            Console.WriteLine("I am private method calling with value: {0} myString: {1}", 
                value, myString);
            return new SourceReturnObject(value, myString);
        }
    }

    // Complex return object
    class SourceReturnObject {
        public SourceReturnObject(int intValue, string stringValue) {
            sourceReturnInt = intValue;
            sourceReturnString = stringValue;
        }
        public int sourceReturnInt;
        public string sourceReturnString;
    }
}
