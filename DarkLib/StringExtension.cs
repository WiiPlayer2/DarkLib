using System;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class StringExtension
    {
        public static int IndexOfAny(this string @string, char[] anyOf, out char? foundChar)
        {
            return IndexOfAny(@string, anyOf, 0, out foundChar);
        }

        public static int IndexOfAny(this string @string, char[] anyOf, int startIndex, out char? foundChar)
        {
            return IndexOfAny(@string, anyOf, startIndex, @string.Length - startIndex, out foundChar);
        }

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

        public static int IndexOfAny(this string @string, string[] anyOf)
        {
            string @null;
            return IndexOfAny(@string, anyOf, out @null);
        }

        public static int IndexOfAny(this string @string, string[] anyOf, out string foundString)
        {
            return IndexOfAny(@string, anyOf, 0, out foundString);
        }

        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex)
        {
            string @null;
            return IndexOfAny(@string, anyOf, startIndex, out @null);
        }

        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex, out string foundString)
        {
            return IndexOfAny(@string, anyOf, startIndex, @string.Length - startIndex, out foundString);
        }

        public static int IndexOfAny(this string @string, string[] anyOf, int startIndex, int count)
        {
            string @null;
            return IndexOfAny(@string, anyOf, startIndex, count, out @null);
        }

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

        public static int LastIndexOfAny(this string @string, char[] anyOf, out char? foundChar)
        {
            return LastIndexOfAny(@string, anyOf, @string.Length - 1, out foundChar);
        }

        public static int LastIndexOfAny(this string @string, char[] anyOf, int startIndex, out char? foundChar)
        {
            return LastIndexOfAny(@string, anyOf, startIndex, startIndex + 1, out foundChar);
        }

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

        public static int LastIndexOfAny(this string @string, string[] anyOf)
        {
            string @null;
            return LastIndexOfAny(@string, anyOf, out @null);
        }

        public static int LastIndexOfAny(this string @string, string[] anyOf, out string foundString)
        {
            return LastIndexOfAny(@string, anyOf, @string.Length - 1, out foundString);
        }

        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex)
        {
            string @null;
            return LastIndexOfAny(@string, anyOf, startIndex, out @null);
        }

        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex, out string foundString)
        {
            return LastIndexOfAny(@string, anyOf, startIndex, startIndex + 1, out foundString);
        }

        public static int LastIndexOfAny(this string @string, string[] anyOf, int startIndex, int count)
        {
            string @null;
            return LastIndexOfAny(@string, anyOf, startIndex, count, out @null);
        }

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