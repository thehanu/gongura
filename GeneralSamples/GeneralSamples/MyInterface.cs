using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyInterface<t>
    {

    }

    interface IMyInterface
    {
        Task<string> AddItem(string id, string value);
        Task<string> GetItem(string id);
        Task<string> RemoveItem(string id);
    }
}
