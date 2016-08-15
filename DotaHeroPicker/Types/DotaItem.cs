using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types.Core;
using DotaHeroPicker.Factories;

namespace DotaHeroPicker.Types
{
    public class DotaItem : DotaBase<Item>
    {
        #region Properties

        internal static DotaItemFactory Factory
        {
            get { return DotaItemFactory.GetInstance(); }
        }

        #endregion

        #region Constructors

        private DotaItem(DotaName<Item> dotaName)
            : base(dotaName) { }

        #endregion
    }
}
