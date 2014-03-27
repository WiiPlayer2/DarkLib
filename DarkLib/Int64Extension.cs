//-----------------------------------------------------------------------
// <copyright file="Int64Extension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace System
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Int64"/>
    /// </summary>
    public static class Int64Extension
    {
        /// <summary>
        /// Converts the value to a human readable byte size formation.
        /// </summary>
        /// <param name="long">The long value.</param>
        /// <returns>Human readable byte size string</returns>
        public static string ToReadableByteSize(this long @long)
        {
            return ToReadableByteSize(@long, "0.## ");
        }

        /// <summary>
        /// Converts the value to a human readable byte size formation with a given number format.
        /// </summary>
        /// <param name="long">The long value.</param>
        /// <param name="format">The format.</param>
        /// <returns>Human readable byte size string</returns>
        public static string ToReadableByteSize(this long @long, string format)
        {
            var sign = @long < 0 ? "-" : string.Empty;
            double readable = @long < 0 ? -@long : @long;
            string suffix;

            if (@long >= 0x1000000000000000)
            {
                suffix = "EB";
                readable = (double)(@long >> 50);
            }
            else if (@long >= 0x4000000000000)
            {
                suffix = "PB";
                readable = (double)(@long >> 40);
            }
            else if (@long >= 0x10000000000)
            {
                suffix = "TB";
                readable = (double)(@long >> 30);
            }
            else if (@long >= 0x40000000)
            {
                suffix = "GB";
                readable = (double)(@long >> 20);
            }
            else if (@long >= 0x100000)
            {
                suffix = "MB";
                readable = (double)(@long >> 10);
            }
            else if (@long >= 0x400)
            {
                suffix = "KB";
                readable = (double)@long;
            }
            else
            {
                return @long.ToString(sign + "0 B"); // Byte
            }

            readable = readable / 1024;

            return sign + readable.ToString(format) + suffix;
        }
    }
}