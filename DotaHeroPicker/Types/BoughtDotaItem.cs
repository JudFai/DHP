using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Types
{
    public class BoughtDotaItem
    {
        #region Properties

        public DotaItem DotaItem { get; private set; }
        public TimeSpan BoughtTime { get; private set; }

        #endregion

        #region Constructors

        public BoughtDotaItem(DotaItem dotaItem, TimeSpan boughtTime)
        {
            DotaItem = dotaItem;
            BoughtTime = boughtTime;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}: {1}", DotaItem.DotaName.FullName, BoughtTime.ToString());
        }

        #endregion
    }
}
