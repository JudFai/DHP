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

        public DotaLane this[string htmlName]
        {
            get { return this.FirstOrDefault(p => p.HtmlName == htmlName); }
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
            Items.Add(CreateDotaLane(Lane.OffLane, "Off"));
            Items.Add(CreateDotaLane(Lane.MiddleLane, "Middle"));
            Items.Add(CreateDotaLane(Lane.SafeLane, "Safe"));
            Items.Add(CreateDotaLane(Lane.Roam, "Roaming"));
            Items.Add(CreateDotaLane(Lane.Jungle, "Jungle"));
        }

        #endregion

        #region Private Methods

        private DotaLane CreateDotaLane(Lane lane, string fullName)
        {
            if (this.Any(p => p.Lane == lane))
                throw new Exception(string.Format("{0} has been created", lane));

            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dotaLane = (DotaLane)Activator.CreateInstance(typeof(DotaLane), flags, null, new object[] { lane, fullName }, null);

            return dotaLane;
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
