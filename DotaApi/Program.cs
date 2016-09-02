using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace DotaApi
{
    class Program
    {
        public static readonly string _pathToUrl = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v1/?format=XML&hero_id={0}&key={1}";
        public static readonly string _key = "9E08B26E9B8BEB385FF5A94AAFE9466C";
        public static readonly string _userAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

        static void Main(string[] args)
        {
            XmlElement element = null;
            while (true)
            {
                try
                {
                    // http://steamwebapi.azurewebsites.net/#interfaces
                    // http://dev.dota2.com/showthread.php?t=47115
                    // http://steamcommunity.com/dev/apikey
                    // Хороший сайт, который описывает интерфейсы для апишки
                    var fullPath = string.Format(_pathToUrl, 1, _key);
                    var wq = WebRequest.Create(fullPath) as HttpWebRequest;
                    if (wq == null)
                        throw new Exception("WebRequest is null");

                    wq.UserAgent = _userAgent;
                    var res = wq.GetResponse() as HttpWebResponse;
                    if (res == null)
                        throw new Exception("WebResponse is null");

                    var encoding = ASCIIEncoding.UTF8;
                    string responseText = null;
                    using (var reader = new System.IO.StreamReader(res.GetResponseStream(), encoding))
                    {
                        responseText = reader.ReadToEnd()
                            .Replace("\\", string.Empty)
                            .Replace("&rsaquo;", string.Empty)
                            .Replace("&raquo;", string.Empty)
                            .Replace("&lsaquo;", string.Empty)
                            .Replace("&laquo;", string.Empty);
                    }

                    var xml = new XmlDocument();
                    xml.LoadXml(responseText);
                    element = xml.DocumentElement;
                }
                catch (WebException ex)
                {
                    Thread.Sleep(15000);
                }
            }

            //var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            //var time = posixTime.AddSeconds(1468441112);
        }
    }
}
