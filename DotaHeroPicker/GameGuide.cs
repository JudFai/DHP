using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types;

namespace DotaHeroPicker
{
    public class GameGuide
    {
        #region Properties

        public string PlayerName { get; private set; }
        public int RatingPoints { get; private set; }
        public DotaLane Lane { get; private set; }

        /// <summary>
        /// Способности героя, которые прокачены по порядку
        /// </summary>
        public ReadOnlyCollection<DotaHeroAbility> DotaHeroAbilityCollection { get; private set; }

        /// <summary>
        /// Вещи купленные на начальном этапе игры
        /// </summary>
        public ReadOnlyCollection<DotaItem> StartDotaItemCollection { get; private set; }

        /// <summary>
        /// Предметы покупаемые на протяжении игры(не включая предметы, которые куплены в начале игры)
        /// </summary>
        public ReadOnlyCollection<BoughtDotaItem> BoughtDotaItemCollection { get; private set; }

        #endregion

        #region Constructors

        public GameGuide(string playerName, int ratingPoints, 
            DotaLane lane,
            IEnumerable<DotaHeroAbility> dotaHeroAbilityCollection,
            IEnumerable<DotaItem> startDotaItemCollection,
            IEnumerable<BoughtDotaItem> boughtDotaItemCollection)
        {
            PlayerName = playerName;
            RatingPoints = ratingPoints;
            Lane = lane;
            DotaHeroAbilityCollection = new ReadOnlyCollection<DotaHeroAbility>(dotaHeroAbilityCollection.ToList());
            StartDotaItemCollection = new ReadOnlyCollection<DotaItem>(startDotaItemCollection.ToList());
            BoughtDotaItemCollection = new ReadOnlyCollection<BoughtDotaItem>(boughtDotaItemCollection.ToList());
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}", PlayerName, RatingPoints, Lane.DotaName.Entity);
        }

        #endregion
    }
}
