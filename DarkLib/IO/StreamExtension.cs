//-----------------------------------------------------------------------
// <copyright file="StreamExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Contains extension methods for <see cref="System.IO.Stream"/>
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>Containing string</returns>
        public static string GetString(this Stream stream)
        {
            return GetString(stream, Encoding.Default);
        }

        /// <summary>
        /// Gets the string with the given encoding.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>Containing string</returns>
        public static string GetString(this Stream stream, Encoding encoding)
        {
            var reader = new StreamReader(stream, encoding);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Sets the string.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The string.</param>
        public static void SetString(this Stream stream, string value)
        {
            SetString(stream, value, Encoding.Default);
        }

        /// <summary>
        /// Sets the string with the given encoding.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The string.</param>
        /// <param name="encoding">The encoding.</param>
        public static void SetString(this Stream stream, string value, Encoding encoding)
        {
            var bytes = encoding.GetBytes(value);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}