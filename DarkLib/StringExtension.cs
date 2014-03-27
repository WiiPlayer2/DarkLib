//-----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// Contains extension methods for <see cref="System.String"/>.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Searches for any of the characters and returns the index and the found character.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="foundChar">The found character.</param>
        /// <returns>The index</returns>
        public static int IndexOfAny(this string @string, char[] anyOf, out char? foundChar)
        {
            return IndexOfAny(@string, anyOf, 0, out foundChar);
        }

        /// <summary>
        /// Searches for any of the characters and returns the index and the found character.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="foundChar">The found character.</param>
        /// <returns>The index</returns>
        public static int IndexOfAny(this string @string, char[] anyOf, int startIndex, out char? foundChar)
        {
            return IndexOfAny(@string, anyOf, startIndex, @string.Length - startIndex, out foundChar);
        }

        /// <summary>
        /// Searches for any of the characters and returns the index and the found character.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="foundChar">The found character.</param>
        /// <returns>The index.</returns>
        public static int IndexOfAny(this string @string, char[] anyOf, int startIndex, int count, out char? foundChar)
        {
            foundChar = null;
            var i = @string.IndexOfAny(anyOf, startIndex, count);
            if (i > -1)
            {
                var found = false;
                for (var j = 0; j < anyOf.Length && !found; j++)
                {
                    found = (foundChar = anyOf[j]) == @string[i];
                }
            }

            return i;
        }

        /// <summary>
        /// Searches for any of the strings and returns the index.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <returns>The index.</returns>
        public static int IndexOfAny(this string @string, string[] anyOf)
        {
            string @null;
            return IndexOfAny(@string, anyOf, out @null);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index and the found string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="foundString">The found string.</param>
        /// <returns>The index.</returns>
        public static int IndexOfAny(this string @string, string[] anyOf, out string foundString)
        {
            return IndexOfAny(@string, anyOf, 0, out foundString);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>The index</returns>
        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex)
        {
            string @null;
            return IndexOfAny(@string, anyOf, startIndex, out @null);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index and the found string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="foundString">The found string.</param>
        /// <returns>The index.</returns>
        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex, out string foundString)
        {
            return IndexOfAny(@string, anyOf, startIndex, @string.Length - startIndex, out foundString);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>The index.</returns>
        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex, int count)
        {
            string @null;
            return IndexOfAny(@string, anyOf, startIndex, count, out @null);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index and the found string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="foundString">The found string.</param>
        /// <returns>The index.</returns>
        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex, int count, out string foundString)
        {
            var finds = new Dictionary<string, int>();
            foreach (var s in anyOf)
            {
                var i = @string.IndexOf(s, startIndex, count);
                if (i > -1)
                {
                    finds[s] = i;
                }
            }

            var sortedfinds = finds.OrderBy(o => o.Value);
            if (finds.Any())
            {
                var ret = finds.ElementAt(0);
                foundString = ret.Key;
                return ret.Value;
            }
            else
            {
                foundString = null;
                return -1;
            }
        }

        /// <summary>
        /// Searches for any of the characters and returns the index and the found character.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="foundChar">The found character.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, char[] anyOf, out char? foundChar)
        {
            return LastIndexOfAny(@string, anyOf, @string.Length - 1, out foundChar);
        }

        /// <summary>
        /// Searches for any of the characters and returns the index and the found character.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="foundChar">The found character.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, char[] anyOf, int startIndex, out char? foundChar)
        {
            return LastIndexOfAny(@string, anyOf, startIndex, startIndex + 1, out foundChar);
        }

        /// <summary>
        /// Searches for any of the characters and returns the index and the found character.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="foundChar">The found character.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, char[] anyOf, int startIndex, int count, out char? foundChar)
        {
            foundChar = null;
            var i = @string.LastIndexOfAny(anyOf, startIndex, count);
            if (i > -1)
            {
                var found = false;
                for (var j = 0; j < anyOf.Length && !found; j++)
                {
                    found = (foundChar = anyOf[j]) == @string[i];
                }
            }

            return i;
        }

        /// <summary>
        /// Searches for any of the strings and returns the index.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, string[] anyOf)
        {
            string @null;
            return LastIndexOfAny(@string, anyOf, out @null);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index and the found string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="foundString">The found string.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, string[] anyOf, out string foundString)
        {
            return LastIndexOfAny(@string, anyOf, @string.Length - 1, out foundString);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex)
        {
            string @null;
            return LastIndexOfAny(@string, anyOf, startIndex, out @null);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index and the found string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="foundString">The found string.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex, out string foundString)
        {
            return LastIndexOfAny(@string, anyOf, startIndex, startIndex + 1, out foundString);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex, int count)
        {
            string @null;
            return LastIndexOfAny(@string, anyOf, startIndex, count, out @null);
        }

        /// <summary>
        /// Searches for any of the strings and returns the index and the found string.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="anyOf">Any of.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <param name="foundString">The found string.</param>
        /// <returns>The index.</returns>
        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex, int count, out string foundString)
        {
            var finds = new Dictionary<string, int>();
            foreach (var s in anyOf)
            {
                var i = @string.LastIndexOf(s, startIndex, count);
                if (i > -1)
                {
                    finds[s] = i;
                }
            }

            var sortedfinds = finds.OrderBy(o => o.Value);
            if (finds.Any())
            {
                var ret = finds.ElementAt(0);
                foundString = ret.Key;
                return ret.Value;
            }
            else
            {
                foundString = null;
                return -1;
            }
        }
    }
}