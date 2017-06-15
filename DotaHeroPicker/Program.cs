using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DotaHeroPicker;
using DotaHeroPicker.Types;
using DotaHeroPicker.Collections;
using DotaHeroPicker.ServerLog;
using Microsoft.Win32;

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
            // TODO: не удалять ServerLog


            //var parser = DotaServerLogParser.Instance;
            //var lobby = 
            //    parser.TryParse("06/08/2017 - 22:09:06: =[A:1:2429176835:8657] (Lobby 25112027075713098 DOTA_GAMEMODE_ALL_DRAFT 0:[U:1:179231329] 1:[U:1:212143194] 2:[U:1:379513007] 3:[U:1:296779678] 4:[U:1:165126837] 5:[U:1:235070275] 6:[U:1:117075774] 7:[U:1:114115565] 8:[U:1:350925960] 9:[U:1:98759982]) (Party 25112027075236447 0:[U:1:114115565])");

            //if (lobby != null)
            //{
            //    var dotaStatisticsManager = DotaStatisticsManager.GetInstance();
            //    var stats = dotaStatisticsManager.GetPlayersStatisticsCollection(lobby.Players);
            //}

            IDotaServerLogPathWorker pathWorker = new DotaServerLogPathWorker();
            var pathToServerLog = pathWorker.GetPathToServerLog();
            if (pathToServerLog != null)
            {
                IServerLogWorker worker = new ServerLogWorker(pathToServerLog);
                worker.WaitForNewDotaLobby(TimeSpan.FromMinutes(5));
            }

            //if (Directory.Exists(Path.GetFullPath()))

            //var test = DotaStatisticsManager.GetInstance();
            //var collection = DotaHeroCollection.GetInstance();
            //Manager.GetAllHeroGuideCompleted += (sender, list) =>
            //{

            //};
            //Manager.ChangedOperationProgress += (sender, progress) =>
            //{
            //    Console.Clear();
            //    Console.WriteLine("{0}%", progress);
            //};
            //Manager.GetAllHeroGuide();
            //while (true)
            //{
            //    Thread.Sleep(100);
        //}
            //var fullNameAbility = Manager.GetAllHeroAbilitiy().OrderBy(p => p.Value);
            //using (var sw = new StreamWriter("ForClass.txt", true))
            //{
            //    var i = 1;
            //    foreach (var her in Enum.GetValues(typeof(Hero)).Cast<Hero>())
            //    {
            //        sw.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////");
            //        sw.WriteLine("// {0}", her);
            //        sw.WriteLine("new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>");
            //        sw.WriteLine("{");
            //        string factoryStr = null;
            //        foreach (var ability in fullNameAbility.Where(p => p.Key == her))
            //        {
            //            if (factoryStr != null)
            //                sw.WriteLine(factoryStr);

            //            var t = ability.Value
            //                .Replace("'s", string.Empty)
            //                .Replace(" of", string.Empty)
            //                .Replace(" the", string.Empty)
            //                .Replace("(", string.Empty)
            //                .Replace(")", string.Empty)
            //                .Replace(",", string.Empty)
            //                .Replace("-", string.Empty)
            //                .Replace(":", string.Empty)
            //                .Replace("!", string.Empty)
            //                .Replace(" ", string.Empty);
            //            factoryStr = string.Format("    DotaHeroAbility.Factory.CreateElement(new DotaName<Ability>(Ability.{0}, \"{1}\")),", t, ability.Value);
            //        }

            //        sw.WriteLine(factoryStr.Substring(0, factoryStr.Length - 1));

            //        sw.WriteLine("})");
            //        sw.WriteLine();
            //    }
            //    //*var enumAbilities = */fullNameAbility.ToList()
            //    //    .ForEach(p =>
            //    //    {
            //    //        var t = p.Value
            //    //            .Replace("'s", string.Empty)
            //    //            .Replace(" of", string.Empty)
            //    //            .Replace(" the", string.Empty)
            //    //            .Replace("(", string.Empty)
            //    //            .Replace(")", string.Empty)
            //    //            .Replace(",", string.Empty)
            //    //            .Replace("-", string.Empty)
            //    //            .Replace(":", string.Empty)
            //    //            .Replace("!", string.Empty)
            //    //            .Replace(" ", string.Empty);

            //    //        sw.WriteLine("new ReadOnlyCollection<DotaHeroAbility>(new List<DotaHeroAbility>");
            //    //        sw.WriteLine("{");
            //    //        sw.WriteLine("    new DotaName<Ability>(Ability.{0}, \"{1}\")", t, p);
            //    //        sw.WriteLine("}));");
            //    //        sw.WriteLine();
            //    //        //return string.Format("{0} = {1},", t, i++);
            //    //    });
            //}

            //var items = Manager.GetItems();
            //using (var sw = new StreamWriter("ItemsClass.txt", true))
            //{
            //    var i = 0;
            //    items.OrderBy(p => p).ToList().ForEach(p =>
            //    {
            //        var t = p
            //                .Replace("'s", string.Empty)
            //                .Replace(" of", string.Empty)
            //                .Replace(" the", string.Empty)
            //                .Replace("(", string.Empty)
            //                .Replace(")", string.Empty)
            //                .Replace(",", string.Empty)
            //                .Replace("-", string.Empty)
            //                .Replace(":", string.Empty)
            //                .Replace("!", string.Empty)
            //                .Replace(" ", string.Empty);
            //        sw.WriteLine("Items.Add(DotaItem.Factory.CreateElement(DotaItem.Factory.CreateElement(new DotaName<Item>(Item.{0}, \"{1}\"))));", t, p);
            //    });
            //}

            //using (var sw = new StreamWriter("EnumName.txt", true))
            //{
            //    enumAbilities.ToList().ForEach(p => sw.WriteLine(p));
            //}

            //var tttt = test.GetHeroLanePresenceCollection(collection[Hero.Enigma]);

            //Manager.GetAllHeroAdvantageCompleted += (o, e) =>
            //{
            //    HeroAdvantageCollection = e;
            //    WriteXml("Advantage.xml", e);
            //    Console.WriteLine("GetAllHeroAdvantageCompleted");
            //};

            //var pathToAdvantage = "Advantage.xml";
            //if (File.Exists(pathToAdvantage))
            //    HeroAdvantageCollection = ReadXml(pathToAdvantage);
            //else
            //{
            //    GetAllHeroAdvantage();
            //}

            //var enemyHeroes = new List<DotaHero>
            //{
            //    collection[Hero.EmberSpirit], 
            //    collection[Hero.Invoker], 
            //    collection[Hero.Pudge],
            //    //collection[Hero.Slark],
            //    //collection[Hero.Timbersaw]
            //};

            //var stat = new StatisticsManager(HeroAdvantageCollection);
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
