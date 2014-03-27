//-----------------------------------------------------------------------
// <copyright file="HttpWebRequestExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace System.Net
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Net.HttpWebRequest"/>
    /// </summary>
    public static class HttpWebRequestExtension
    {
        /// <summary>
        /// Gets the response without an exception.
        /// </summary>
        /// <param name="httpWebRequest">The HTTP web request.</param>
        /// <returns>The Http web response.</returns>
        public static HttpWebResponse GetResponseNoException(this HttpWebRequest httpWebRequest)
        {
            try
            {
                return (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException we)
            {
                var resp = we.Response as HttpWebResponse;
                if (resp == null)
                {
                    throw;
                }

                return resp;
            }
        }
    }
}