using System;
using System.Text;

namespace System.IO
{
    public static class StreamExtension
    {
        public static string GetString(this Stream @Stream)
        {
            return GetString(@Stream, Encoding.Default);
        }

        public static string GetString(this Stream @Stream, Encoding encoding)
        {
            var reader = new StreamReader(@Stream, encoding);
            return reader.ReadToEnd();
        }

        public static void SetString(this Stream @Stream, string value)
        {
            SetString(@Stream, value, Encoding.Default);
        }

        public static void SetString(this Stream @Stream, string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);
            @Stream.Write(bytes, 0, bytes.Length);
        }
    }
}