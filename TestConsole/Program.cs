using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new TestClass();
            //test.DebugFields(ObjectExtension.ALL_MEMBERS);
            //Console.ReadKey(true);

            var s = new StreamSplitter(Console.OpenStandardOutput(), File.OpenWrite("test.log"));
            var writer = new StreamWriter(s)
            {
                AutoFlush = true
            };
            Console.SetOut(writer);

            var process = Process.GetCurrentProcess();
            process.InitCpuUsage();
            while (true)
            {
                var usage = process.GetCpuUsage();
                Console.WriteLine(usage * 100);
                //writer.WriteLine("Usage: {0}", usage * 100);
                Console.ReadKey(true);
            }

            //var t = new GenericTestClass<string>();

            //var s = "test";
            //StringExtension.IndexOfAny(s, new[] { "test" });
        }
    }
}
