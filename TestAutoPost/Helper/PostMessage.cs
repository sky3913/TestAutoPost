using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TestAutoPost.Helper
{
    public class PostMessage
    {
        public static string Send(string username, string password, string content)
        {
            byte[] _bytes = Encoding.ASCII.GetBytes(content);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://kaskus.co.id");
            string Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));

            httpWebRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            httpWebRequest.AllowAutoRedirect = false;
            httpWebRequest.AllowWriteStreamBuffering = true;
            httpWebRequest.CookieContainer = new CookieContainer(128);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = (long)_bytes.Length;
            httpWebRequest.Headers.Add("Authorization", "Basic " + Credentials);
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 10000;
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; GTB6; SLCC1; .NET CLR 2.0.50727;";

            Stream requestStream = ((WebRequest)httpWebRequest).GetRequestStream();
            requestStream.Write(_bytes, 0, _bytes.Length);
            requestStream.Close();

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string pageContent = string.Empty;

            if (httpWebResponse == null)
                return pageContent;
            else
            {
                using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    //Trace.WriteLine(reader.ReadToEnd());
                    pageContent = reader.ReadToEnd();
                }
            }

            httpWebResponse.Close();

            return pageContent;
        }
    }
}