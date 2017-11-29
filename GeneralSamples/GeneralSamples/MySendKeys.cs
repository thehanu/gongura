using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MySendKeys
    {
        public static void run()
        {
            System.Windows.Forms.SendKeys.SendWait("{NumLock}");
            System.Threading.Thread.Sleep(5000);
            System.Windows.Forms.SendKeys.SendWait("{F5}");
        }
    }
}
