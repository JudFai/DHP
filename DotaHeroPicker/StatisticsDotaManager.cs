using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DotaHeroPicker
{
    class StatisticsDotaManager
    {
        #region Fields

        private readonly object _lockerRequest = new object();
        private readonly string _pathToMatchups = "http://dotabuff.com/heroes/{0}/matchups";
        private readonly string _pathToOverview = "http://dotabuff.com/heroes/{0}";
        private readonly string _userAgent = "Mozilla/5.0";

        private readonly DotaHeroCollection _heroCollection = DotaHeroCollection.GetInstance();

        #endregion

        #region Constructors

        public StatisticsDotaManager()
        { }

        #endregion

        #region Private Methods

        private XmlElement GetXmlElement(string path)
        {
            lock (_lockerRequest)
            {
                var req = WebRequest.Create(path) as HttpWebRequest;
                if (req == null)
                    throw new Exception("WebRequest is null");

                req.UserAgent = _userAgent;
                var res = req.GetResponse() as HttpWebResponse;
                if (res == null)
                    throw new Exception("WebResponse is null");

                var encoding = ASCIIEncoding.UTF8;
                string responseText = null;
                using (var reader = new System.IO.StreamReader(res.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }

                var xml = new XmlDocument();
                xml.LoadXml(responseText);
                return xml.DocumentElement;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Возвращает преимущества по отношению к другим героям
        /// </summary>
        public HeroAdvantage GetHeroAdvantage(DotaHero hero)
        {
            //var dic = new Dictionary<string, double>();
            var enemyHeroAdvantageCollection = new List<EnemyHeroAdvantage>();
            var root = GetXmlElement(string.Format(_pathToMatchups, hero.Name.HtmlName));
            var tdElements = root.SelectNodes(@"
                body
                /div[@class='container-outer']
                /div[@class='container-inner']
                /div[@class='content-inner']
                /section
                /article
                /table[@class='sortable']
                /tbody
                /tr");
            foreach (XmlElement td in tdElements)
            {
                var attributeHeroName = td.SelectSingleNode("td[@class='cell-icon']/@data-value");
                if (attributeHeroName != null)
                {
                    var attributeAdvantage = td.SelectSingleNode(@"
                        td
                        /div
                        /div[@class='segment segment-advantage']
                        /..
                        /..
                        /@data-value");
                    if (attributeAdvantage != null)
                    {
                        double advantageValue = 0;
                        if (double.TryParse(attributeAdvantage.InnerText, NumberStyles.Number, CultureInfo.InvariantCulture, out advantageValue))
                        {
                            var enemyHero = _heroCollection[attributeHeroName.InnerText];
                            if (enemyHero != null)
                                enemyHeroAdvantageCollection.Add(new EnemyHeroAdvantage(enemyHero, advantageValue));
                            else
                                throw new Exception("Hero not found");
                        }
                        else
                        {
                            throw new Exception(string.Format("Parse error {0}", attributeAdvantage.InnerText));
                        }
                    }
                }
            }

            return new HeroAdvantage(hero, enemyHeroAdvantageCollection);
        }

        /// <summary>
        /// Возвращает преимущества всех героев по отношению друг к другу
        /// </summary>
        public List<HeroAdvantage> GetAllHeroAdvantage()
        {
            return _heroCollection.Select(GetHeroAdvantage).ToList();
        }

        /// <summary>
        /// Возвращает на каких линиях герой находится больше всего
        /// </summary>
        public List<LanePresence> GetHeroLanePresenceCollection(DotaHero hero)
        {
            var heroLanePresenceCollection = new List<LanePresence>();
            var root = GetXmlElement(string.Format(_pathToOverview, hero.Name.HtmlName));
            var laneCollection = DotaLaneCollection.GetInstance();
            var trElements = root.SelectNodes(@"
                body
                /div[@class='container-outer']
                /div[@class='container-inner']
                /div[@class='content-inner']
                /div[@class='row-12']
                /div[@class='col-8']
                /section[header='Lane Presence']
                /article
                /table
                /tbody
                /tr");
            foreach (XmlElement tr in trElements)
            {
                var elementLane = tr.SelectSingleNode("td");
                if (elementLane != null)
                {
                    var lane = laneCollection[elementLane.InnerText];
                    if (lane != null)
                    {
                        var attributePercentagePresence = tr.SelectSingleNode(@"
                            td
                            /div
                            /div[@class='segment segment-match']
                            /..
                            /..
                            /@data-value");
                        double percentagePresence = 0;
                        if (double.TryParse(attributePercentagePresence.InnerText, NumberStyles.Number,
                            CultureInfo.InvariantCulture, out percentagePresence))
                        {
                            heroLanePresenceCollection.Add(new LanePresence(lane, percentagePresence));
                        }
                        else
                            throw new Exception(string.Format("Parse error {0}", attributePercentagePresence.InnerText));
                    }
                    else
                        throw new Exception("Lane not found");
                }
            }

            return heroLanePresenceCollection;
        }

        #endregion
    }
}
