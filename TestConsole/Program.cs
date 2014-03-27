using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();
            test.DebugFields(ObjectExtension.ALL_MEMBERS);
            Console.ReadKey(true);

            var process = Process.GetCurrentProcess();
            process.InitCpuUsage();
            while (true)
            {
                var usage = process.GetCpuUsage();
                Console.WriteLine(usage * 100);
                Console.ReadKey(true);
            }

            var t = new GenericTestClass<string>();
        }
    }
}
