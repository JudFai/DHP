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

        public static DotaHeroFactory Factory
        {
            get { return DotaHeroFactory.GetInstance(); }
        }

        public ReadOnlyCollection<HeroRole> Roles { get; private set; }
        public AttackType AttackType { get; private set; }
        public HeroCharacteristic MainCharacteristic { get; private set; }
        public HeroName Name { get; private set; }

        #endregion

        #region Constructors

        private DotaHero(HeroName name, AttackType attackType, HeroCharacteristic mainCharacteristic, IList<HeroRole> roles)
        {
            Name = name;
            AttackType = attackType;
            MainCharacteristic = mainCharacteristic;
            Roles = new ReadOnlyCollection<HeroRole>(roles);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Name.ToString();
        }

        #endregion
    }
}
