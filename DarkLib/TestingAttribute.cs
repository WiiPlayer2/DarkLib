using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DarkLib
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestingAttribute : Attribute
    {
        private static BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        private static Dictionary<MethodInfo, TestingAttribute> instances;

        static TestingAttribute()
        {
            instances = new Dictionary<MethodInfo, TestingAttribute>();
        }

        public TestingAttribute()
        {
            Debug.WriteLine("TestingAttribute()");
        }

        public static void Init()
        {
            var assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes();
            var methods = types.Select(
                t => t.GetMethods(flags))
                .Aggregate<MethodInfo[], List<MethodInfo>>(
                new List<MethodInfo>(),
                (ret, current) =>
                {
                    ret.AddRange(current);
                    return ret;
                });
            var useMethods = methods.Where(o => o.GetCustomAttribute<TestingAttribute>() != null).ToList();
            useMethods.ForEach(o => SetMethodInterception(o));
        }

        public void DoSomething()
        {
            Debug.WriteLine("DoSomething()");
        }

        private static void SetMethodInterception(MethodInfo methodInfo)
        {
            if (!instances.ContainsKey(methodInfo))
            {
                var attr = methodInfo.GetCustomAttribute<TestingAttribute>();
            }
        }
    }
}