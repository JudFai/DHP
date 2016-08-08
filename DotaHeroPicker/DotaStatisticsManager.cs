using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DotaHeroPicker
{
    public class DotaStatisticsManager
    {
        #region Fields

        private readonly static object _lockerInstance = new object();
        private static DotaStatisticsManager _instance;

        private readonly object _lockerRequest = new object();
        private readonly string _pathToMatchups = "http://dotabuff.com/heroes/{0}/matchups";
        private readonly string _pathToOverview = "http://dotabuff.com/heroes/{0}";
        private readonly string _userAgent = "Mozilla/5.0";

        private readonly DotaHeroCollection _heroCollection = DotaHeroCollection.GetInstance();

        private double _operationProgress;

        #endregion

        #region Properties

        public double OperationProgress
        {
            get { return _operationProgress; }
            private set
            {
                if (_operationProgress != value)
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("OperationProgress");
                    else if (value > 100)
                        _operationProgress = 100;
                    else
                        _operationProgress = value;

                    OnChangedOperationProgress(_operationProgress);
                }
            }
        }

        #endregion

        #region Events

        public event EventHandler<double> ChangedOperationProgress;
        public event EventHandler<List<HeroAdvantage>> GetAllHeroAdvantageCompleted;

        #endregion

        #region Constructors

        private DotaStatisticsManager()
        { }

        #endregion

        #region Private Methods

        private void OnChangedOperationProgress(double operationProgress)
        {
            if (ChangedOperationProgress != null)
                ChangedOperationProgress(this, operationProgress);
        }

        private void OnGetAllHeroAdvantageCompleted(List<HeroAdvantage> heroAdvantageCollection)
        {
            if (GetAllHeroAdvantageCompleted != null)
                GetAllHeroAdvantageCompleted(this, heroAdvantageCollection);
        }

        private XmlElement GetXmlElement(string path)
        {
            lock (_lockerRequest)
            {
                Exception exception = null;
                int countTry = 0;
                while (countTry < 3)
                {
                    try
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
                    catch (Exception ex)
                    {
                        exception = ex;
                        countTry++;
                        Thread.Sleep(1000);
#if DEBUG
                        Console.WriteLine(ex.Message);
#endif
                    }
                }

                throw exception;
            }
        }

        #endregion

        #region Public Methods

        public static DotaStatisticsManager GetInstance()
        {
            lock (_lockerInstance)
            {
                return _instance ?? (_instance = new DotaStatisticsManager());
            }
        }

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

#if DEBUG
            Console.WriteLine(hero.Name.FullName);
#endif

            return new HeroAdvantage(hero, enemyHeroAdvantageCollection);
        }

        /// <summary>
        /// Возвращает преимущества всех героев по отношению друг к другу
        /// </summary>
        public async void GetAllHeroAdvantage()
        {
            await Task.Run(() =>
            {
                var collection = new List<HeroAdvantage>();
                OperationProgress = 0;
                var percentsInIteration = 100d / _heroCollection.Count;
                foreach (var hero in _heroCollection)
                {
                    collection.Add(GetHeroAdvantage(hero));
                    OperationProgress += percentsInIteration;
                }

                OperationProgress = 100;
                OnGetAllHeroAdvantageCompleted(collection);
            });
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

#if DEBUG
            Console.WriteLine(hero.Name.FullName);
#endif

            return heroLanePresenceCollection;
        }

        #endregion
    }
}
