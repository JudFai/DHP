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
        /// 
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

        /// <summary>
        /// Предметы оставшиеся в инвентаре в конце игры
        /// </summary>
        public ReadOnlyCollection<BoughtDotaItem> InventoryDotaItemCollection { get; private set; }

        #endregion

        #region Constructors

        public GameGuide(string playerName, int ratingPoints, 
            DotaLane lane,
            ReadOnlyCollection<DotaHeroAbility> dotaHeroAbilityCollection, 
            ReadOnlyCollection<DotaItem> startDotaItemCollection,
            ReadOnlyCollection<BoughtDotaItem> boughtDotaItemCollection,
            ReadOnlyCollection<BoughtDotaItem> inventoryDotaItemCollection)
        {
            PlayerName = playerName;
            RatingPoints = ratingPoints;
            Lane = lane;
            DotaHeroAbilityCollection = dotaHeroAbilityCollection;
            StartDotaItemCollection = startDotaItemCollection;
            BoughtDotaItemCollection = boughtDotaItemCollection;
            InventoryDotaItemCollection = inventoryDotaItemCollection;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}", PlayerName, RatingPoints, Lane.Lane);
        }

        #endregion
    }
}
