using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkLib;

namespace TestConsole
{
    class TestClass
    {
        public string field = "OMG!";
        private int field2 = 1337;
        protected bool field3 = false;
        internal float field4 = 3.141f;

        public static string field5 = "STATIC!!";
        private static int field6 = 69;
        internal static bool field7 = true;

        [Testing]
        public void Test()
        {
            field2.DebugFields();
            field6.DebugFields();
        }
    }
}
