using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DotaApi.Types;

namespace DotaApi
{
    class Program
    {
        public static readonly string _pathToUrlGetMatchHistory =
            @"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v1/?format=XML&min_players=10&key={0}";

        public static readonly string _pathToUrlGetMatchHistoryLastMatch =
            @"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v1/?format=XML&min_players=10&start_at_match_id={1}&key={0}";

        public static readonly string _pathToUrlGetMatchDetails = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v1/?format=XML&match_id={1}&key={0}";
        public static readonly string _key = "9E08B26E9B8BEB385FF5A94AAFE9466C";
        public static readonly string _userAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

        static void Main(string[] args)
        {
            var test = GetMatchHistory(0, 1);
            //XmlElement element = null;
            //while (true)
            //{
            //    try
            //    {
            //        // http://steamwebapi.azurewebsites.net/#interfaces
            //        // http://dev.dota2.com/showthread.php?t=47115
            //        // http://steamcommunity.com/dev/apikey
            //        // Хороший сайт, который описывает интерфейсы для апишки
            //        var fullPath = string.Format(_pathToUrl, 1, _key);
            //        var wq = WebRequest.Create(fullPath) as HttpWebRequest;
            //        if (wq == null)
            //            throw new Exception("WebRequest is null");

            //        wq.UserAgent = _userAgent;
            //        var res = wq.GetResponse() as HttpWebResponse;
            //        if (res == null)
            //            throw new Exception("WebResponse is null");

            //        var encoding = ASCIIEncoding.UTF8;
            //        string responseText = null;
            //        using (var reader = new System.IO.StreamReader(res.GetResponseStream(), encoding))
            //        {
            //            responseText = reader.ReadToEnd()
            //                .Replace("\\", string.Empty)
            //                .Replace("&rsaquo;", string.Empty)
            //                .Replace("&raquo;", string.Empty)
            //                .Replace("&lsaquo;", string.Empty)
            //                .Replace("&laquo;", string.Empty);
            //        }

            //        var xml = new XmlDocument();
            //        xml.LoadXml(responseText);
            //        element = xml.DocumentElement;
            //    }
            //    catch (WebException ex)
            //    {
            //        Thread.Sleep(15000);
            //    }
            //}

            //var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            //var time = posixTime.AddSeconds(1468441112);
        }


        /// <summary>
        /// Возвращает последние матчи
        /// </summary>
        /// <param name="lastMatchID">Идентификатор матча с которого начнётся порядок матчей. Если 0, то берёт с последнего матча</param>
        /// <param name="countDays">Матчи за количество дней с момента запроса</param>
        /// <returns>Последние матчи за кол-во дней</returns>
        public static IEnumerable<Match> GetMatchHistory(ulong lastMatchID, int countDays)
        {
            XmlElement element = null;
            var dotaMatchCollection = new List<Match>();
            var date = DateTime.Now.Date.AddDays(-countDays);
            var startDate = DateTime.MinValue;
            while ((startDate == DateTime.MinValue) || (date <= startDate))
            {

                while (true)
                {
                    try
                    {
                        // Хороший сайт, который описывает интерфейсы для апишки
                        // http://steamwebapi.azurewebsites.net/#interfaces
                        // http://dev.dota2.com/showthread.php?t=47115
                        // http://steamcommunity.com/dev/apikey
                        // API с описанием многих вещей
                        // http://dota2api.readthedocs.io/en/latest/responses.html#game-mode
                        var fullPath = lastMatchID > 0
                            ? string.Format(_pathToUrlGetMatchHistoryLastMatch, _key, lastMatchID)
                            : string.Format(_pathToUrlGetMatchHistory, _key);
                        var wq = WebRequest.Create(fullPath) as HttpWebRequest;
                        if (wq == null)
                            throw new Exception("WebRequest is null");

                        wq.UserAgent = _userAgent;
                        var res = wq.GetResponse() as HttpWebResponse;
                        if (res == null)
                            throw new Exception("WebResponse is null");

<<<<<<< HEAD
                    var xml = new XmlDocument();
                    xml.LoadXml(responseText);
                    element = xml.DocumentElement;

=======
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
                        break;
                    }
                    catch (WebException ex)
                    {
                        Thread.Sleep(15000);
                    }
>>>>>>> origin/master
                }

                var matches = element.SelectNodes(@"
                    matches
                    /match");
                foreach (XmlElement match in matches)
                {
                    lastMatchID = ulong.Parse(match.SelectSingleNode("match_id").InnerXml);
                    var startTimeInSeconds = ulong.Parse(match.SelectSingleNode("start_time").InnerXml);
                    var dotaMatch = new Match(lastMatchID, startTimeInSeconds);
                    startDate = dotaMatch.StartTime;
                    if (date > startDate)
                        break;

                    dotaMatchCollection.Add(dotaMatch);
                }
            }

            return dotaMatchCollection
                .GroupBy(p => p.MatchID)
                .Select(p => p.FirstOrDefault());
        }

        public static Match GetMatchDetails(ulong matchID)
        {
            
        }
    }
}
