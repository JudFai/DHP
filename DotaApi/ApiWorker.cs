using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using EFDota.Types;
using EFDota.Secondary;
using System.IO;
using System.Xml.Linq;

namespace DotaApi
{
    public class XmlMatchDetailsEventArgs : EventArgs
    {
        public long MatchSeqNum { get; private set; }
        public string Path { get; private set; }
        public XDocument Xml { get; private set; }
        public XmlMatchDetailsEventArgs(long matchSeqNum, string path)
        {
            MatchSeqNum = matchSeqNum;
            Path = path;
        }
        public XmlMatchDetailsEventArgs(long matchSeqNum, XDocument xml)
        {
            MatchSeqNum = matchSeqNum;
            Xml = xml;
        }
    }

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

        #region Events

        public event EventHandler<IEnumerable<MatchDetail>> ReceivedMatchHistory;
        public event EventHandler<XmlMatchDetailsEventArgs> SavedMatchHistory;
        public event EventHandler<XmlMatchDetailsEventArgs> ReceivedXmlMatchHistory;

        #endregion

        #region Constructors

        public ApiWorker(string key)
        {
            _key = key;
        }

        #endregion

        #region Private Methods

        private void OnSavedMatchHistory(XmlMatchDetailsEventArgs e)
        {
            if (SavedMatchHistory != null)
                SavedMatchHistory(this, e);
        }

        private void OnReceivedXmlMatchHistory(XmlMatchDetailsEventArgs e)
        {
            if (ReceivedXmlMatchHistory != null)
                ReceivedXmlMatchHistory(this, e);
        }

        private void OnReceivedMatchHistory(IEnumerable<MatchDetail> e)
        {
            if (ReceivedMatchHistory != null)
                ReceivedMatchHistory(this, e);
        }

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
                catch (XmlException)
                {
                    Thread.Sleep(10000);
                }
            }

            return element;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Возвращает матчи
        /// </summary>
        /// <param name="matchSeqNum">Идентификатор матча сгенерированный после окончания матча, если равен 0, то начинает с последнего доступного</param>
        /// <returns>Матчи с подробностями</returns>
        public async void GetMatchHistoryBySequenceNum(long matchSeqNum, int matchesCount)
        {
            await Task.Run(() =>
            {
                XmlElement element = null;
                var dotaMatchCollection = new List<MatchDetail>();
                var matchSeqNumIsZero = matchSeqNum == 0;
                while (dotaMatchCollection.Count < matchesCount)
                {
                    var fullPath = !matchSeqNumIsZero
                        ? string.Format(_pathToUrlGetMatchHistoryBySequenceNum, _key, matchSeqNum)
                        : string.Format(_pathToUrlGetMatchHistory, _key);
                    element = GetXmlElement(fullPath);
                    //if (!matchSeqNumIsZero)
                    //{
                    //    var pathToFile = string.Format(@"Xml/{0}.xml", DateTime.Now.Ticks);
                    //    if (!Directory.Exists(Path.GetDirectoryName(pathToFile)))
                    //        Directory.CreateDirectory(Path.GetDirectoryName(pathToFile));

                    //    element.OwnerDocument.Save(pathToFile);
                    //    var logger = Logger.GetInstance();
                    //    logger.WriteLine(string.Format("Path to url: {0}", fullPath));
                    //    logger.WriteLine(string.Format("Xml saved to {0}", pathToFile));
                    //    logger.WriteLine(string.Empty, false);
                    //}

                    var matches = element.SelectNodes(@"
                    matches
                    /match");
                    foreach (XmlElement match in matches)
                    {
                        matchSeqNum = long.Parse(match.SelectSingleNode("match_seq_num").InnerXml);
                        if (matchSeqNumIsZero)
                        {
                            matchSeqNumIsZero = matchSeqNum == 0;
                            break;
                        }

                        var m = DotaApiXmlHelper.ParseMatchDetail(match);
                        dotaMatchCollection.Add(m);
                        if (dotaMatchCollection.Count >= matchesCount)
                        {
                            dotaMatchCollection = dotaMatchCollection
                                .GroupBy(p => p.ID)
                                .Select(p => p.FirstOrDefault())
                                .ToList();
                            if (dotaMatchCollection.Count >= matchesCount)
                                break;
                        }
                    }
                }

                OnReceivedMatchHistory(dotaMatchCollection);
            });
        }

        public void SaveMatchHistory(long matchSeqNum, string pathToFolder)
        {
            XmlElement element = null;
            if (matchSeqNum == 0)
            {
                element = GetXmlElement(string.Format(_pathToUrlGetMatchHistory, _key));
                matchSeqNum = long.Parse(element.SelectSingleNode(@"matches/match/match_seq_num").InnerXml);
            }

            element = GetXmlElement(string.Format(_pathToUrlGetMatchHistoryBySequenceNum, _key, matchSeqNum));
            var pathToFile = Path.Combine(pathToFolder, string.Format("{0}_{1}.xml", DateTime.Now.Ticks, matchSeqNum));
            if (!Directory.Exists(pathToFolder))
                Directory.CreateDirectory(pathToFolder);

            element.OwnerDocument.Save(pathToFile);
            var lasmatchSeqNum = long.Parse(element.SelectSingleNode(@"matches/match[last()]/match_seq_num").InnerXml);
            OnSavedMatchHistory(new XmlMatchDetailsEventArgs(lasmatchSeqNum, pathToFile));
        }

        public void GetXmlMatchHistory(long matchSeqNum)
        {
            XmlElement element = null;
            if (matchSeqNum == 0)
            {
                element = GetXmlElement(string.Format(_pathToUrlGetMatchHistory, _key));
                matchSeqNum = long.Parse(element.SelectSingleNode(@"matches/match/match_seq_num").InnerXml);
            }

            element = GetXmlElement(string.Format(_pathToUrlGetMatchHistoryBySequenceNum, _key, matchSeqNum));
            //var pathToFile = Path.Combine(pathToFolder, string.Format("{0}_{1}.xml", DateTime.Now.Ticks, matchSeqNum));
            //if (!Directory.Exists(pathToFolder))
            //    Directory.CreateDirectory(pathToFolder);

            //element.OwnerDocument.Save(pathToFile);
            var lasmatchSeqNum = long.Parse(element.SelectSingleNode(@"matches/match[last()]/match_seq_num").InnerXml);
            OnReceivedXmlMatchHistory(new XmlMatchDetailsEventArgs(lasmatchSeqNum, XDocument.Parse(element.OuterXml)));
        }

        public void StartGettingXmlMatchHistory(long matchSeqNum)
        {
            XmlElement element = null;
            if (matchSeqNum == 0)
            {
                element = GetXmlElement(string.Format(_pathToUrlGetMatchHistory, _key));
                matchSeqNum = long.Parse(element.SelectSingleNode(@"matches/match/match_seq_num").InnerXml);
            }

            while (true)
            {
                element = GetXmlElement(string.Format(_pathToUrlGetMatchHistoryBySequenceNum, _key, matchSeqNum));
                //var pathToFile = Path.Combine(pathToFolder, string.Format("{0}_{1}.xml", DateTime.Now.Ticks, matchSeqNum));
                //if (!Directory.Exists(pathToFolder))
                //    Directory.CreateDirectory(pathToFolder);

                //element.OwnerDocument.Save(pathToFile);
                matchSeqNum = long.Parse(element.SelectSingleNode(@"matches/match[last()]/match_seq_num").InnerXml);
                OnReceivedXmlMatchHistory(new XmlMatchDetailsEventArgs(matchSeqNum, XDocument.Parse(element.OuterXml)));
            }
        }

        #endregion
    }
}
