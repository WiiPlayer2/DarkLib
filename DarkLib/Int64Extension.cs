using System;

namespace System
{
    public static class Int64Extension
    {
        public static string ToReadableByteSize(this long @long)
        {
            return ToReadableByteSize(@long, "0.## ");
        }

        public static string ToReadableByteSize(this long @long, string format)
        {
            var sign = (@long < 0 ? "-" : "");
            double readable = (@long < 0 ? -@long : @long);
            string suffix;
            if (@long >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (double)(@long >> 50);
            }
            else if (@long >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (double)(@long >> 40);
            }
            else if (@long >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (double)(@long >> 30);
            }
            else if (@long >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (double)(@long >> 20);
            }
            else if (@long >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (double)(@long >> 10);
            }
            else if (@long >= 0x400) // Kilobyte
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