using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types.Core;

namespace DotaHeroPicker.Types
{
    public class DotaItem : DotaBase<Item>
    {
        #region Constructors

        private DotaItem(DotaName<Item> dotaName)
        {
            DotaName = dotaName;
        }

        #endregion
    }
}
