using DotaHeroPicker.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class DotaLaneCollection : ReadOnlyCollection<DotaLane>
    {
        #region Fields

        private static readonly object _locker = new object();
        private static DotaLaneCollection _instance;

        #endregion

        #region Indexers

        public DotaLane this[string fullName]
        {
            get { return this.FirstOrDefault(p => p.DotaName.FullName == fullName); }
        }

        public DotaLane this[Lane lane]
        {
            get { return this.FirstOrDefault(p => p.DotaName.Entity == lane); }
        }

        public new DotaLane this[int index]
        {
            get { return base[index]; }
        }

        #endregion

        #region Constructors

        private DotaLaneCollection()
            : base(new List<DotaLane>())
        {
            Items.Add(DotaLane.Factory.CreateElement(new DotaName<Lane>(Lane.OffLane, "Off")));
            Items.Add(DotaLane.Factory.CreateElement(new DotaName<Lane>(Lane.MiddleLane, "Middle")));
            Items.Add(DotaLane.Factory.CreateElement(new DotaName<Lane>(Lane.SafeLane, "Safe")));
            Items.Add(DotaLane.Factory.CreateElement(new DotaName<Lane>(Lane.Roam, "Roaming")));
            Items.Add(DotaLane.Factory.CreateElement(new DotaName<Lane>(Lane.Jungle, "Jungle")));
        }

        #endregion

        #region Public Methods

        public static DotaLaneCollection GetInstance()
        {
            lock (_locker)
            {
                return _instance ?? (_instance = new DotaLaneCollection());
            }
        }

        #endregion
    }
}
