using DotaHeroPicker;
using DotaHeroPicker.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DotaHeroPicker.Types;

namespace DotaHeroPickerUI.Helpers
{
    public class SerializerHeroGuideCollection : SerializerBase<List<HeroGuide>>
    {
        #region Fields

        private static object _instanceLocker = new object();
        private static SerializerHeroGuideCollection _instance;

        #endregion

        #region Constructors

        private SerializerHeroGuideCollection()
        {
            PathToXml = "Data/HeroGuides.xml";
        }

        #endregion

        #region Public Methods

        public static SerializerHeroGuideCollection GetInstance()
        {
            lock (_instanceLocker)
            {
                return _instance ?? (_instance = new SerializerHeroGuideCollection());
            }
        }

        public override List<HeroGuide> ReadXml()
        {
            var heroGuideCollection = new List<HeroGuide>();
            try
            {
                var xml = XElement.Load(PathToXml);
                var heroCollection = DotaHeroCollection.GetInstance();
                var itemCollection = DotaItemCollection.GetInstance();
                var laneCollection = DotaLaneCollection.GetInstance();
                foreach (var heroGuide in xml.Elements("HeroGuide"))
                {
                    var hero = heroCollection[heroGuide.Attribute("FullName").Value];
                    if (hero == null)
                        throw new Exception(string.Format("Hero {0} not found", heroGuide.Attribute("FullName").Value));

                    var xmlGameGuideCollection = heroGuide.Elements("GameGuide");
                    var gameGuideCollection = new List<GameGuide>();
                    foreach (var xmlGameGuide in xmlGameGuideCollection)
                    {
                        var playerName = xmlGameGuide.Element("PlayerName").Value;
                        var ratingPoints = int.Parse(xmlGameGuide.Element("RatingPoints").Value);
                        var lane = laneCollection[xmlGameGuide.Element("Lane").Value];

                        var dotaHeroAbilityCollection = new List<DotaHeroAbility>();
                        var xmlDotaHeroAbilityCollection = xmlGameGuide
                            .Element("DotaHeroAbilities")
                            .Elements("DotaHeroAbility");
                        foreach (var dotaHeroAbility in xmlDotaHeroAbilityCollection)
                        {
                            dotaHeroAbilityCollection.Add(
                                hero.DotaHeroAbilities.FirstOrDefault(p => p.DotaName.FullName == dotaHeroAbility.Attribute("FullName").Value));
                        }

                        var startDotaItemCollection = new List<DotaItem>();
                        var xmlStartDotaItemCollection = xmlGameGuide
                            .Element("StartDotaItems")
                            .Elements("StartDotaItem");
                        foreach (var startDotaItem in xmlStartDotaItemCollection)
                        {
                            startDotaItemCollection.Add(itemCollection[startDotaItem.Attribute("FullName").Value]);
                        }

                        var boughtDotaItemCollection = new List<BoughtDotaItem>();
                        var xmlBoughtDotaItemCollection = xmlGameGuide
                            .Element("BoughtDotaItems")
                            .Elements("BoughtDotaItem");
                        foreach (var boughtDotaItem in xmlBoughtDotaItemCollection)
                        {
                            var boughtTimeSeconds = int.Parse(boughtDotaItem.Element("BoughtTime").Value);
                            boughtDotaItemCollection.Add(
                                new BoughtDotaItem(
                                    itemCollection[boughtDotaItem.Attribute("FullName").Value],
                                    TimeSpan.FromSeconds(boughtTimeSeconds)));
                        }

                        gameGuideCollection.Add(new GameGuide(playerName, ratingPoints, lane, dotaHeroAbilityCollection, startDotaItemCollection, boughtDotaItemCollection));
                    }

                    heroGuideCollection.Add(new HeroGuide(hero, gameGuideCollection));
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }

            return heroGuideCollection;
        }

        public override bool WriteXml(List<HeroGuide> heroGuideCollection)
        {
            var xml = new XElement("HeroGuides");
            //xml.Add(new XAttribute("Date", DateTime.Now.ToString("dd.MM.yyyy")));
            foreach (var heroGuide in heroGuideCollection)
            {
                var xmlHeroGuide = new XElement("HeroGuide",
                    new XAttribute("FullName", heroGuide.Hero.DotaName.FullName));
                xml.Add(xmlHeroGuide);
                foreach (var enemyHeroGuide in heroGuide.Guides)
                {
                    var dotaHeroAbilities = new XElement("DotaHeroAbilities");
                    var startDotaItemCollection = new XElement("StartDotaItems");
                    var boughtDotaItems = new XElement("BoughtDotaItems");
                    var gameGuide = new XElement("GameGuide",
                        new XElement("PlayerName", enemyHeroGuide.PlayerName),
                        new XElement("RatingPoints", enemyHeroGuide.RatingPoints),
                        new XElement("Lane", enemyHeroGuide.Lane.DotaName.FullName),
                        dotaHeroAbilities,
                        startDotaItemCollection,
                        boughtDotaItems);
                    xmlHeroGuide.Add(gameGuide);
                    foreach (var dotaHeroAbility in enemyHeroGuide.DotaHeroAbilityCollection)
                    {
                        dotaHeroAbilities.Add(new XElement("DotaHeroAbility", 
                            new XAttribute("FullName", dotaHeroAbility.DotaName.FullName)));
                    }

                    foreach (var startDotaItem in enemyHeroGuide.StartDotaItemCollection)
                    {
                        startDotaItemCollection.Add(new XElement("StartDotaItem",
                            new XAttribute("FullName", startDotaItem.DotaName.FullName)));
                    }

                    foreach (var boughtDotaItem in enemyHeroGuide.BoughtDotaItemCollection)
                    {
                        boughtDotaItems.Add(new XElement("BoughtDotaItem",
                            new XAttribute("FullName", boughtDotaItem.DotaItem.DotaName.FullName),
                            new XElement("BoughtTime", boughtDotaItem.BoughtTime.Seconds)));
                    }
                }
            }

            DirectoryHelper.CreateDirectory(PathToXml);
            try
            {
                xml.Save(PathToXml);
            }
            catch (UnauthorizedAccessException ex)
            {
#if DEBUG
                Console.Write(ex.Message);
#endif
                return false;
            }

            return true;
        }

        #endregion
    }
}
