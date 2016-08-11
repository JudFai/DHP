using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker.Types.Core
{
    public abstract class DotaBase<T> : IDotaBase
        where T : struct 
    {
        #region Properties

        public DotaName<T> DotaName { get; protected set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return DotaName.ToString();
        }

        #endregion
    }
}
