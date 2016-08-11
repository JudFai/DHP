using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Factories;

namespace DotaHeroPicker.Types
{
    class DotaItemFactory : DotaFactory<DotaItem>
    {
        #region Fields

        private static DotaItemFactory _instance;
        private static readonly object _locker = new object();
        private static readonly object _lockerCreate = new object();

        private readonly List<DotaItem> _dotaItemCollection = new List<DotaItem>();

        #endregion

        #region Constructors

        private DotaItemFactory()
        { }

        #endregion

        #region Public Methods

        public static DotaItemFactory GetInstance()
        {
            lock (_locker)
            {
                return _instance ?? (_instance = new DotaItemFactory());
            }
        }

        public DotaItem CreateDotaItem(DotaName<Item> dotaName)
        {
            lock (_lockerCreate)
            {
                if (_dotaItemCollection.Any(p => p.DotaName.Entity == dotaName.Entity))
                    throw new Exception(string.Format("{0} has been created", dotaName));

                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var dotaItem = (DotaItem)Activator.CreateInstance(typeof(DotaItem), flags, null, new object[] { dotaName }, null);
                _dotaItemCollection.Add(dotaItem);

                return dotaItem;
            }
        }

        #endregion
    }
}
