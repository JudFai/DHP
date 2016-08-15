using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DotaHeroPicker.Types;
using DotaHeroPicker.Collections;

namespace DotaHeroPicker
{
    class Program
    {
        #region Fields

        public static readonly DotaStatisticsManager Manager = DotaStatisticsManager.GetInstance();

        public static List<HeroAdvantage> HeroAdvantageCollection;

        #endregion

        static void Main(string[] args)
        {
            //if (Directory.Exists(Path.GetFullPath()))

            //var test = DotaStatisticsManager.GetInstance();
            var collection = DotaHeroCollection.GetInstance();

            //var tttt = test.GetHeroLanePresenceCollection(collection[Hero.Enigma]);

            Manager.GetAllHeroAdvantageCompleted += (o, e) =>
            {
                HeroAdvantageCollection = e;
                WriteXml("Advantage.xml", e);
                Console.WriteLine("GetAllHeroAdvantageCompleted");
            };

            var pathToAdvantage = "Advantage.xml";
            if (File.Exists(pathToAdvantage))
                HeroAdvantageCollection = ReadXml(pathToAdvantage);
            else
            {
                GetAllHeroAdvantage();
            }

            var enemyHeroes = new List<DotaHero>
            {
                collection[Hero.EmberSpirit], 
                collection[Hero.Invoker], 
                collection[Hero.Pudge],
                //collection[Hero.Slark],
                //collection[Hero.Timbersaw]
            };

            var stat = new StatisticsManager(HeroAdvantageCollection);
            //var adv = stat.GetEnemyTeamAdvantageCollection(enemyHeroes);

            //var col = new List<EnemyTeamAdvantage>();
            //foreach (var hero in collection.Except(enemyHeroes))
            //{
            //    //double advantageTeam = 0;
            //    //foreach (var enemyHero in enemyHeroes)
            //    //{
            //    //    advantageTeam += collectionHeroAdvantage
            //    //        .FirstOrDefault(p => p.Hero == enemyHero)
            //    //        .EnemyHeroAdvantageCollection
            //    //        .FirstOrDefault(p => p.Hero == hero)
            //    //        .AdvantageValue;
            //    //}

            //    //col[hero] = advantageTeam;
            //    col.Add(new EnemyTeamAdvantage(hero,
            //        collectionHeroAdvantage
            //        .FirstOrDefault(p => p.Hero == hero)
            //        .EnemyHeroAdvantageCollection
            //        .Where(a => enemyHeroes.Contains(a.Hero))
            //        .ToList()));
            //}

            //col = col
            //    .OrderByDescending(p => p.AdvantageValue)
            //    .ToList();

            while (true)
            { }

            //Console.ReadKey(true);
        }

        public static async void GetAllHeroAdvantage()
        {
            await Task.Run(() =>
            {
                Manager.GetAllHeroAdvantage();
            });
        }

        public static List<HeroAdvantage> ReadXml(string path)
        {
            var heroAdvantageCollection = new List<HeroAdvantage>();
            var xml = XElement.Load(path);
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

            return heroAdvantageCollection;
        }

        public static void WriteXml(string path, List<HeroAdvantage> heroAdvantageCollection)
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

            xml.Save(path);
        }
    }
}
