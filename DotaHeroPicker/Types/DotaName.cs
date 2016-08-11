using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPicker
{
    public class DotaName<T> where T : struct 
    {
        #region Properties

        public T Entity { get; private set; }
        public string FullName { get; private set; }
        public string HtmlName { get; private set; }

        #endregion

        #region Constrcutors

        private DotaName()
        { 
        }

        public DotaName(T entity, string fullName)
        {
            Entity = entity;
            FullName = fullName;
            HtmlName = fullName.ToLower()
                .Replace(" ", "-")
                .Replace("'", string.Empty);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return FullName;
        }

        #endregion
    }
}
