using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class GenericTestClass<T>
    {
        static GenericTestClass()
        {
            Debug.WriteLine("Bla");
        }
    }
}
