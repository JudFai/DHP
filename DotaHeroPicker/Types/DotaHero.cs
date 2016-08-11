using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class DotaHero
    {
        #region Properties

        internal static DotaHeroFactory Factory
        {
            get { return DotaHeroFactory.GetInstance(); }
        }

        public ReadOnlyCollection<HeroRole> Roles { get; private set; }
        public AttackType AttackType { get; private set; }
        public HeroCharacteristic MainCharacteristic { get; private set; }
        public DotaName<Hero> DotaName { get; private set; }

        #endregion

        #region Constructors

        private DotaHero(DotaName<Hero> dotaName, AttackType attackType, HeroCharacteristic mainCharacteristic, IList<HeroRole> roles)
        {
            DotaName = dotaName;
            AttackType = attackType;
            MainCharacteristic = mainCharacteristic;
            Roles = new ReadOnlyCollection<HeroRole>(roles);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return DotaName.ToString();
        }

        #endregion
    }
}
