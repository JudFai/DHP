using DotaHeroPicker;
using DotaHeroPicker.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
//            try
//            {
//                var xml = XElement.Load(PathToXml);
//                var heroCollection = DotaHeroCollection.GetInstance();
//                foreach (var heroAdvantage in xml.Elements("HeroAdvantage"))
//                {
//                    var hero = heroCollection[heroAdvantage.Attribute("FullName").Value];
//                    if (hero == null)
//                        throw new Exception(string.Format("Hero {0} not found", heroAdvantage.Attribute("FullName").Value));

//                    var enemyHeroAdvantageCollection = new List<EnemyHeroAdvantage>();
//                    foreach (var enemyHeroAdvantage in heroAdvantage.Elements("EnemyHeroAdvantage"))
//                    {
//                        var enemyHero = heroCollection[enemyHeroAdvantage.Element("EnemyHero").Value];
//                        if (enemyHero == null)
//                            throw new Exception(string.Format("Hero {0} not found", enemyHeroAdvantage.Element("EnemyHero").Value));

//                        double advantage;
//                        if (double.TryParse(enemyHeroAdvantage.Element("AdvantageValue").Value,
//                            NumberStyles.Number, CultureInfo.InvariantCulture, out advantage))
//                        {
//                            enemyHeroAdvantageCollection.Add(new EnemyHeroAdvantage(enemyHero, advantage));
//                        }
//                        else
//                            throw new Exception(string.Format("Error parse {0}", enemyHeroAdvantage.Element("AdvantageValue").Value));
//                    }

//                    heroAdvantageCollection.Add(new HeroAdvantage(hero, enemyHeroAdvantageCollection));
//                }
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                Console.WriteLine(ex.Message);
//#endif
//                return null;
//            }

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
