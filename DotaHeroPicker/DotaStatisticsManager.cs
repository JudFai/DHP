using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DotaHeroPicker.Types;
using DotaHeroPicker.Collections;

namespace DotaHeroPicker
{
    public enum Operation
    {
        GetAllHeroAdvantage,
        GetAllHeroGuide
    }

    public class ProgressEventArgs : EventArgs
    {
        #region Properties

        public double Progress { get; private set; }
        public Operation Operation { get; private set; }

        #endregion

        #region Constructors

        public ProgressEventArgs(double progress, Operation operation)
        {
            Progress = progress;
            Operation = operation;
        }

        #endregion
    }

    public class DotaStatisticsManager
    {
        #region Fields

        private readonly static object _lockerInstance = new object();
        private static DotaStatisticsManager _instance;

        private readonly object _lockerRequest = new object();
        private readonly string _pathToMatchups = "http://dotabuff.com/heroes/{0}/matchups";
        private readonly string _pathToGuides = "http://dotabuff.com/heroes/{0}/guides?page={1}";
        private readonly string _pathToAbilities = "http://dotabuff.com/heroes/{0}/abilities";
        private readonly string _pathToOverview = "http://dotabuff.com/heroes/{0}";
        private readonly string _pathToItems = "http://dotabuff.com/items";
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
                }
            }
        }

        #endregion

        #region Events

        public event EventHandler<ProgressEventArgs> ChangedOperationProgress;
        public event EventHandler<List<HeroAdvantage>> GetAllHeroAdvantageCompleted;
        public event EventHandler<List<HeroGuide>> GetAllHeroGuideCompleted;

        #endregion

        #region Constructors

        private DotaStatisticsManager()
        { }

        #endregion

        #region Private Methods

        private void SetOperationProgress(double progress, Operation operation)
        {
            OperationProgress = progress;
            OnChangedOperationProgress(new ProgressEventArgs(OperationProgress, operation));
        }

        private void OnChangedOperationProgress(ProgressEventArgs operationProgress)
        {
            if (ChangedOperationProgress != null)
                ChangedOperationProgress(this, operationProgress);
        }

        private void OnGetAllHeroAdvantageCompleted(List<HeroAdvantage> heroAdvantageCollection)
        {
            if (GetAllHeroAdvantageCompleted != null)
                GetAllHeroAdvantageCompleted(this, heroAdvantageCollection);
        }

        private void OnGetAllHeroGuideCompleted(List<HeroGuide> heroGuideCollection)
        {
            if (GetAllHeroGuideCompleted != null)
                GetAllHeroGuideCompleted(this, heroGuideCollection);
        }

        private XmlElement GetXmlElement(string path)
        {
            lock (_lockerRequest)
            {
                Exception exception = null;
                var countTry = 0;
                while (countTry < 5)
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
                        using (var reader = new StreamReader(res.GetResponseStream(), encoding))
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
                        return xml.DocumentElement;
                    }
                    catch (WebException ex)
                    {
                        // Ловим исключение, которое подразумевает большое кол-во запросов на сайт, поэтому ставим таймаут до тех пор,
                        // пока не будет разрешено продолжить отправлять запросы и получать ответы
                        if ((ex.Status == WebExceptionStatus.ProtocolError) &&
                            (((HttpWebResponse) ex.Response).StatusCode == HttpStatusCode.Forbidden))
                        {
                            Thread.Sleep(30000);

                            // TODO: пока не понятно: имеет ли смысл ставить continue, ведь не будет выхода из цикла
                            //continue;
                        }

                        countTry++;

#if DEBUG
                        Console.WriteLine(ex.Message);
#endif
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
            var root = GetXmlElement(string.Format(_pathToMatchups, hero.DotaName.HtmlName));
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
            Console.WriteLine(hero.DotaName.FullName);
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
                SetOperationProgress(0, Operation.GetAllHeroAdvantage);
                //OperationProgress = 0;
                var percentsInIteration = 100d / _heroCollection.Count;
                foreach (var hero in _heroCollection)
                {
                    collection.Add(GetHeroAdvantage(hero));
                    //OperationProgress += percentsInIteration;
                    SetOperationProgress(OperationProgress + percentsInIteration, Operation.GetAllHeroAdvantage);
                }

                //OperationProgress = 100;
                SetOperationProgress(100, Operation.GetAllHeroAdvantage);
                OnGetAllHeroAdvantageCompleted(collection);
            });
        }

        /// <summary>
        /// Возвращает на каких линиях герой находится больше всего
        /// </summary>
        public List<LanePresence> GetHeroLanePresenceCollection(DotaHero hero)
        {
            var heroLanePresenceCollection = new List<LanePresence>();
            var root = GetXmlElement(string.Format(_pathToOverview, hero.DotaName.HtmlName));
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
            Console.WriteLine(hero.DotaName.FullName);
#endif

            return heroLanePresenceCollection;
        }

        /// <summary>
        /// Возвращает доступные руковода для героя
        /// </summary>
        public HeroGuide GetHeroGuide(DotaHero hero)
        {
            var gameGuideCollection = new List<GameGuide>();
            for (var page = 1; page <= 4; page++)
            {
                var root = GetXmlElement(string.Format(_pathToGuides, hero.DotaName.HtmlName, page));
                var elements = root.SelectNodes(@"
                    body
                    /div[@class='container-outer']
                    /div[@class='container-inner']
                    /div[@class='content-inner']
                    /section
                    /article
                    /div[@class='r-stats-grid']");
                foreach (XmlElement element in elements)
                {
                    // PlayerName
                    var row = element.SelectSingleNode(@"
                        div[@class='group']
                        /div[@class='kv kv-larger kv-small-margin']
                        /a[@class='link-type-player-larger']");
                    var playerName = row.InnerText;

                    // Rating
                    var rows = element.SelectNodes(@"
                        div[@class='group']
                        /div[@class='kv kv-label']");
                    int playerRating = -1;
                    var match = Regex.Match(rows[rows.Count - 1].InnerText, @"~ (?<mmr>\d+) MMR");
                    if (match.Groups.Count >= 1)
                        playerRating = int.Parse(match.Groups["mmr"].Value, NumberStyles.Integer);

                    // Lane
                    row = element.SelectSingleNode(@"
                        div[@class='group']
                        /div[@class='kv kv-label']
                        /span
                        /acronym[@rel='neighbour-tooltip']");
                    var laneCollection = DotaLaneCollection.GetInstance();
                    var lane = laneCollection.FirstOrDefault(p => row.InnerText.ToUpper().Contains(p.DotaName.FullName.ToUpper()));

                    // Starting items
                    rows = element.SelectNodes(@"
                        div[@class='group']
                        /div[@class='kv r-none-mobile' and small='Starting Items']
                        /div[@class='inline inline-margin']
                        /div[@class='image-container image-container-item image-container-medicon image-container-importance-normal']
                        /a
                        /img
                        /@title");
                    var startingItems = new List<DotaItem>();
                    var itemCollection = DotaItemCollection.GetInstance();
                    foreach (XmlAttribute div in rows)
                    {
                        var foundItem = itemCollection.FirstOrDefault(p => p.DotaName.FullName == div.Value);
                        if (foundItem == null)
                            throw new Exception(string.Format("Item {0} not found", string.IsNullOrEmpty(div.Value) ? "EMPTY" : div.Value));

                        startingItems.Add(foundItem);
                    }

                    // Bought items
                    rows = element.SelectNodes(@"
                        div[@class='group']
                        /div[@class='kv r-none-mobile' and not(small='Starting Items')]");
                    var boughtDotaItems = new List<BoughtDotaItem>();
                    foreach (XmlElement div in rows)
                    {
                        var time = DateTime.ParseExact(
                            div.SelectSingleNode("small").InnerXml,
                            new[] {"H:mm:ss", "mm:ss"}, 
                            new DateTimeFormatInfo(), DateTimeStyles.None).TimeOfDay;
                        var sectionBoughtItem = div.SelectNodes(@"
                            div[@class='inline inline-margin']
                            /div
                            /a
                            /img
                            /@title");
                        foreach (XmlAttribute boughtItem in sectionBoughtItem)
                        {
                            var foundItem = itemCollection.FirstOrDefault(p => p.DotaName.FullName == boughtItem.Value);
                            if (foundItem == null)
                                throw new Exception(string.Format("Item {0} not found", string.IsNullOrEmpty(div.Value) ? "EMPTY" : div.Value));

                            boughtDotaItems.Add(new BoughtDotaItem(foundItem, time));
                        }
                    }

                    // Skills
                    rows = element.SelectNodes(@"
                        div
                        /div[@class='kv kv-small-margin']
                        /div[@class='image-container image-container-skill image-container-medicon']
                        /a
                        /img
                        /@title");
                    var skills = new List<DotaHeroAbility>();
                    foreach (XmlAttribute div in rows)
                    {
                        var foundSkill = hero.DotaHeroAbilities.FirstOrDefault(p => p.DotaName.FullName == div.Value);
                        if (foundSkill == null)
                            throw new Exception(string.Format("Skill {0} not found", string.IsNullOrEmpty(div.Value) ? "EMPTY" : div.Value));

                        skills.Add(foundSkill);
                    }

                    var guide = new GameGuide(playerName, playerRating, lane, 
                        new ReadOnlyCollection<DotaHeroAbility>(skills), 
                        new ReadOnlyCollection<DotaItem>(startingItems), 
                        new ReadOnlyCollection<BoughtDotaItem>(boughtDotaItems));
                    gameGuideCollection.Add(guide);
                }
            }

            return new HeroGuide(hero, new ReadOnlyCollection<GameGuide>(gameGuideCollection));
        }

        public async void GetAllHeroGuide()
        {
            await Task.Run(() =>
            {
                var collection = new List<HeroGuide>();
                //OperationProgress = 0;
                SetOperationProgress(0, Operation.GetAllHeroGuide);
                var percentsInIteration = 100d / _heroCollection.Count;
                foreach (var hero in _heroCollection)
                {
                    collection.Add(GetHeroGuide(hero));
                    //OperationProgress += percentsInIteration;
                    SetOperationProgress(OperationProgress + percentsInIteration, Operation.GetAllHeroGuide);
                }

                //OperationProgress = 100;
                SetOperationProgress(100, Operation.GetAllHeroGuide);

                OnGetAllHeroGuideCompleted(collection);
            });
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Возвращает способности героя
        /// </summary>
        internal List<KeyValuePair<Hero, string>> GetHeroAbilities(DotaHero hero)
        {
            //var dic = new Dictionary<string, double>();
            var heroAbilities = new List<KeyValuePair<Hero, string>>();
            var root = GetXmlElement(string.Format(_pathToAbilities, hero.DotaName.HtmlName));
            var elements = root.SelectNodes(@"
                body
                /div[@class='container-outer']
                /div[@class='container-inner']
                /div[@class='content-inner']
                /div[@class='row-12']
                /div[@class='col-8']
                /section
                /header");
            foreach (XmlElement element in elements)
            {
                var abilityValue = element.FirstChild;
                if (abilityValue != null)
                    heroAbilities.Add(new KeyValuePair<Hero, string>(hero.DotaName.Entity, abilityValue.InnerText));
            }

            return heroAbilities;
        }

        internal IEnumerable<KeyValuePair<Hero, string>> GetAllHeroAbilitiy()
        {
            var collection = new List<KeyValuePair<Hero, string>>();
            foreach (var hero in _heroCollection)
            {
                collection.AddRange(GetHeroAbilities(hero));
#if DEBUG
                Console.WriteLine(hero.DotaName.FullName);
#endif
            }

            return collection;
        }

        internal List<string> GetItems()
        {
            var items = new List<string>();
            var root = GetXmlElement(_pathToItems);
//            var elements = root.SelectNodes(@"
//                body
//                /div[@class='container-outer']
//                /div[@class='container-inner']
//                /div[@class='content-inner']
//                /section
//                /article
//                /section
//                /table[@class='sortable']
//                /tbody
//                /tr
//                /td[@class='cell-xlarge']");
            var elements = root.SelectNodes(@"
                body
                /div[@class='container-outer']
                /div[@class='container-inner']
                /div[@class='content-inner']
                /section
                /article
                /table[@class='sortable']
                /tbody
                /tr
                /td[@class='cell-xlarge']");
            foreach (XmlElement element in elements)
            {
                var itemValue = element.FirstChild;
                if (itemValue != null)
                    items.Add(itemValue.InnerText);
            }

            return items;
        }

        #endregion
    }
}
