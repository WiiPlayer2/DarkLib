//-----------------------------------------------------------------------
// <copyright file="ObjectExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Reflection;

namespace System
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Object"/>.
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// The constant value for all members.
        /// </summary>
        public const BindingFlags AllMembers = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        /// <summary>
        /// Debugs the fields.
        /// </summary>
        /// <param name="object">The object.</param>
        [Conditional("DEBUG")]
        public static void DebugFields(this object @object)
        {
            DebugFields(@object, BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// Debugs the fields.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <param name="bindingAttr">The binding attribute.</param>
        [Conditional("DEBUG")]
        public static void DebugFields(this object @object, BindingFlags bindingAttr)
        {
            var fields = @object.GetType().GetFields(bindingAttr);
            foreach (var field in fields)
            {
                Debug.WriteLine("{0}\t{1}\t= {2}", field.FieldType, field.Name, field.GetValue(@object));
            }
        }

        /// <summary>
        /// Debugs the properties.
        /// </summary>
        /// <param name="object">The object.</param>
        [Conditional("DEBUG")]
        public static void DebugProperties(this object @object)
        {
            DebugProperties(@object, BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// Debugs the properties.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <param name="bindingAttr">The binding attribute.</param>
        [Conditional("DEBUG")]
        public static void DebugProperties(this object @object, BindingFlags bindingAttr)
        {
            var props = @object.GetType().GetProperties(bindingAttr);
            foreach (var prop in props)
            {
                if (prop.CanRead)
                {
                    Debug.WriteLine("{0}\t{1}\t= {2}", prop.PropertyType, prop.Name, prop.GetValue(@object, null));
                }
                else
                {
                    Debug.WriteLine("{0}\t{1}\t has no getter");
                }
            }
        }
    }
}