using System;
using System.Diagnostics;
using System.Reflection;

namespace System
{
    public static class ObjectExtension
    {
        public const BindingFlags ALL_MEMBERS = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        [Conditional("DEBUG")]
        public static void DebugFields(this object @object)
        {
            DebugFields(@object, BindingFlags.Instance | BindingFlags.Public);
        }

        [Conditional("DEBUG")]
        public static void DebugFields(this object @object, BindingFlags bindingAttr)
        {
            var fields = @object.GetType().GetFields(bindingAttr);
            foreach (var field in fields)
            {
                Debug.WriteLine("{0}\t{1}\t= {2}", field.FieldType, field.Name, field.GetValue(@object));
            }
        }

        [Conditional("DEBUG")]
        public static void DebugProperties(this object @object)
        {
            DebugProperties(@object, BindingFlags.Instance | BindingFlags.Public);
        }

        [Conditional("DEBUG")]
        public static void DebugProperties(this object @object, BindingFlags bindingAttr)
        {
            var props = @object.GetType().GetProperties(bindingAttr);
            foreach (var prop in props)
            {
                if (prop.CanRead)
                {
                    Debug.WriteLine("{0}\t{1}\t= {2}", prop.PropertyType, prop.Name, prop.GetValue(@object));
                }
                else
                {
                    Debug.WriteLine("{0}\t{1}\t has no getter");
                }
            }
        }
    }
}