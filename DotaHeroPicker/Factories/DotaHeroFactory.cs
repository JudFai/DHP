using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    class DotaHeroFactory
    {
        #region Fields

        private static DotaHeroFactory _instance;
        private static readonly object _locker = new object();
        private static readonly object _lockerCreate = new object();

        private readonly List<DotaHero> _dotaHeroCollection = new List<DotaHero>();

        #endregion

        #region Constructors

        private DotaHeroFactory()
        { }

        #endregion

        #region Public Methods

        public static DotaHeroFactory GetInstance()
        {
            lock (_locker)
            {
                return _instance ?? (_instance = new DotaHeroFactory());
            }
        }

        public DotaHero CreateDotaHero(DotaName<Hero> dotaName, AttackType attackType, HeroCharacteristic mainCharacteristic, IList<HeroRole> roles)
        {
            lock (_lockerCreate)
            {
                if (_dotaHeroCollection.Any(p => p.DotaName.Entity == dotaName.Entity))
                    throw new Exception(string.Format("{0} has been created", dotaName));

                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var dotaHero = (DotaHero)Activator.CreateInstance(typeof(DotaHero), flags, null, new object[] { dotaName, attackType, mainCharacteristic, roles }, null);
                _dotaHeroCollection.Add(dotaHero);

                return dotaHero;
            }
        }

        #endregion
    }
}
