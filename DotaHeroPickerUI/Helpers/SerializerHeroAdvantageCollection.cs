using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DotaHeroPicker;
using DotaHeroPicker.Collections;

namespace DotaHeroPickerUI.Helpers
{
    public class SerializerHeroAdvantageCollection : SerializerBase<List<HeroAdvantage>>
    {
        #region Fields

        private static object _instanceLocker = new object();
        private static SerializerHeroAdvantageCollection _instance;

        #endregion

        #region Constructors

        private SerializerHeroAdvantageCollection()
        {
            PathToXml = "Data/HeroAdvantages.xml";
        }

        #endregion

        #region Public Methods

        public static SerializerHeroAdvantageCollection GetInstance()
        {
            lock (_instanceLocker)
            {
                return _instance ?? (_instance = new SerializerHeroAdvantageCollection());
            }
        }

        public override List<HeroAdvantage> ReadXml()
        {
            var heroAdvantageCollection = new List<HeroAdvantage>();
            try
            {
                var xml = XElement.Load(PathToXml);
                var heroCollection = DotaHeroCollection.GetInstance();
                foreach (var heroAdvantage in xml.Elements("HeroAdvantage"))
                {
                    var hero = heroCollection[heroAdvantage.Attribute("FullName").Value];
                    if (hero == null)
                        throw new Exception(string.Format("Hero {0} not found", heroAdvantage.Attribute("FullName").Value));

                    var enemyHeroAdvantageCollection = new List<EnemyHeroAdvantage>();
                    foreach (var enemyHeroAdvantage in heroAdvantage.Elements("EnemyHeroAdvantage"))
                    {
                        var enemyHero = heroCollection[enemyHeroAdvantage.Element("EnemyHero").Value];
                        if (enemyHero == null)
                            throw new Exception(string.Format("Hero {0} not found", enemyHeroAdvantage.Element("EnemyHero").Value));

                        double advantage;
                        if (double.TryParse(enemyHeroAdvantage.Element("AdvantageValue").Value,
                            NumberStyles.Number, CultureInfo.InvariantCulture, out advantage))
                        {
                            enemyHeroAdvantageCollection.Add(new EnemyHeroAdvantage(enemyHero, advantage));
                        }
                        else
                            throw new Exception(string.Format("Error parse {0}", enemyHeroAdvantage.Element("AdvantageValue").Value));
                    }

                    heroAdvantageCollection.Add(new HeroAdvantage(hero, enemyHeroAdvantageCollection));
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }

            return heroAdvantageCollection;
        }

        public override bool WriteXml(List<HeroAdvantage> heroAdvantageCollection)
        {
            var xml = new XElement("HeroAdvantages");
            //xml.Add(new XAttribute("Date", DateTime.Now.ToString("dd.MM.yyyy")));
            foreach (var heroAdvantage in heroAdvantageCollection)
            {
                var xmlHeroAdvantage = new XElement("HeroAdvantage",
                    new XAttribute("FullName", heroAdvantage.Hero.DotaName.FullName));
                xml.Add(xmlHeroAdvantage);
                foreach (var enemyHeroAdvantage in heroAdvantage.EnemyHeroAdvantageCollection)
                {
                    xmlHeroAdvantage.Add(new XElement("EnemyHeroAdvantage",
                        new XElement("EnemyHero", enemyHeroAdvantage.Hero.DotaName.FullName),
                        new XElement("AdvantageValue", enemyHeroAdvantage.AdvantageValue)));
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
