using DotaApi.Types;
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
    public class ApiWorker
    {
        #region Fields

        private static readonly string _pathToUrlGetMatchHistory =
             @"http://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v1/?format=XML&matches_requested=1&key={0}";
        private static readonly string _pathToUrlGetMatchHistoryBySequenceNum =
            @"http://api.steampowered.com/IDOTA2Match_570/GetMatchHistoryBySequenceNum/v1/?format=XML&start_at_match_seq_num={1}&key={0}";
        private static readonly string _userAgent = 
            "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

        private string _key;

        #endregion

        #region Constructors

        public ApiWorker(string key)
        {
            _key = key;
        }

        #endregion

        #region Private Methods

        private XmlElement GetXmlElement(string pathToXml)
        {
            XmlElement element = null;
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
                    var fullPath = pathToXml;
                    var wq = WebRequest.Create(fullPath) as HttpWebRequest;
                    if (wq == null)
                        throw new Exception("WebRequest is null");

                    wq.UserAgent = _userAgent;
                    var res = wq.GetResponse() as HttpWebResponse;
                    if (res == null)
                        throw new Exception("WebResponse is null");

                    //var xml = new XmlDocument();
                    //xml.LoadXml(responseText);
                    //element = xml.DocumentElement;

                    var encoding = ASCIIEncoding.UTF8;
                    string responseText = null;
                    using (var reader = new System.IO.StreamReader(res.GetResponseStream(), encoding))
                    {
                        responseText = reader.ReadToEnd();
                    }

                    var xml = new XmlDocument();
                    xml.LoadXml(responseText);
                    element = xml.DocumentElement;
                    break;
                }
                catch (WebException)
                {
                    Thread.Sleep(10000);
                }
            }

            return element;
        }

        #endregion

        #region Public Methods

        // TODO: покуда не известно, возвращает ли матчи в порядке убывания или нет
        // Возможно, что придётся делать вместо countDays - countMatches
        /// <summary>
        /// Возвращает матчи
        /// </summary>
        /// <param name="matchSeqNum">Идентификатор матча сгенерированный после окончания матча, если равен 0, то начинает с последнего доступного</param>
        /// <param name="countDays">Период дней, за который необходимо получить матчи</param>
        /// <returns>Матчи с подробностями</returns>
        public IEnumerable<Match> GetMatchHistoryBySequenceNum(ulong matchSeqNum, int countDays)
        {
            XmlElement element = null;
            var dotaMatchCollection = new List<Match>();
            var date = DateTime.Now.Date.AddDays(-countDays);
            var startDate = DateTime.MinValue;
            var matchSeqNumIsZero = matchSeqNum == 0;
            while ((startDate == DateTime.MinValue) || (date <= startDate))
            {
                var fullPath = !matchSeqNumIsZero
                    ? string.Format(_pathToUrlGetMatchHistoryBySequenceNum, _key, matchSeqNum)
                    : string.Format(_pathToUrlGetMatchHistory, _key);
                element = GetXmlElement(fullPath);

                var matches = element.SelectNodes(@"
                    matches
                    /match");
                foreach (XmlElement match in matches)
                {
                    matchSeqNum = ulong.Parse(match.SelectSingleNode("match_seq_num").InnerXml);
                    if (matchSeqNumIsZero)
                    {
                        matchSeqNumIsZero = matchSeqNum == 0;
                        break;
                    }

                    var matchID = ulong.Parse(match.SelectSingleNode("match_id").InnerXml);
                    var startTimeInSeconds = ulong.Parse(match.SelectSingleNode("start_time").InnerXml);
                    var dotaMatch = new Match(matchID, matchSeqNum, startTimeInSeconds, DotaApiXmlHelper.ParseMatchDetail(match));
                    startDate = dotaMatch.StartTime;
                    if (date > startDate)
                        break;

                    dotaMatchCollection.Add(dotaMatch);
                }

                dotaMatchCollection = dotaMatchCollection
                    .OrderBy(p => p.StartTime)
                    .ToList();
            }

            return dotaMatchCollection
                .GroupBy(p => p.MatchID)
                .Select(p => p.FirstOrDefault());
        }

        #endregion
    }
}
