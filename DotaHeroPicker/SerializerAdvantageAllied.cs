using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DotaHeroPicker.Collections;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    //public class AlliedHeroAdvantageDictionaryEventArgs : EventArgs
    //{
    //    public Dictionary<DotaHero, List<AlliedHeroAdvantage>> AlliedHeroAdvantageDictionary { get; private set; }

    //    public AlliedHeroAdvantageDictionaryEventArgs(
    //        Dictionary<DotaHero, List<AlliedHeroAdvantage>> alliedHeroAdvantageDictionary)
    //    {
    //        AlliedHeroAdvantageDictionary = alliedHeroAdvantageDictionary;
    //    }
    //}

    public class SerializerAdvantageAllied : ISerializeXml<Dictionary<DotaHero, List<AlliedHeroAdvantage>>>
    {
        #region Constructors

        public SerializerAdvantageAllied(string path)
        {
            PathToXml = path;
        }

        #endregion

        #region ISerializeXml Members

        public string PathToXml { get; private set; }

        public Dictionary<DotaHero, List<AlliedHeroAdvantage>> ReadXml()
        {
            var alliedHeroAdvantageDic = new Dictionary<DotaHero, List<AlliedHeroAdvantage>>();
            var heroCollection = DotaHeroCollection.GetInstance();
            var xml = XElement.Load(PathToXml);
            foreach (var heroAdvantage in xml.Elements("HeroAdvantage"))
            {
                var heroID = int.Parse(heroAdvantage.Attribute("HeroID").Value);
                var mainHero = heroCollection[(Hero)heroID];
                var alliedHeroAdvantageCollection = new List<AlliedHeroAdvantage>();
                foreach (var alliedHeroAdvantageXml in heroAdvantage.Elements("AlliedHeroAdvantage"))
                {
                    heroID = int.Parse(alliedHeroAdvantageXml.Element("HeroID").Value);
                    var hero = heroCollection[(Hero)heroID];
                    var advantageValue = double.Parse(
                        alliedHeroAdvantageXml.Element("AdvantageValue").Value,
                        NumberStyles.Number, CultureInfo.InvariantCulture);
                    alliedHeroAdvantageCollection.Add(new AlliedHeroAdvantage(hero, advantageValue));
                }

                alliedHeroAdvantageDic[mainHero] = alliedHeroAdvantageCollection;
            }

            return alliedHeroAdvantageDic;
        }

        public bool WriteXml(Dictionary<DotaHero, List<AlliedHeroAdvantage>> collection)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
