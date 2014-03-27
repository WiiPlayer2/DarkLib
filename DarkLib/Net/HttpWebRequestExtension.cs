using System;

namespace System.Net
{
    public static class HttpWebRequestExtension
    {
        public static HttpWebResponse GetResponseNoException(this HttpWebRequest @HttpWebRequest)
        {
            try
            {
                return (HttpWebResponse)@HttpWebRequest.GetResponse();
            }
            catch (WebException we)
            {
                var resp = we.Response as HttpWebResponse;
                if (resp == null)
                    throw;
                return resp;
            }
        }
    }
}