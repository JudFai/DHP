using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.Helpers
{
    public abstract class SerializerBase<T> 
        : ISerializeXml<T> where T : class
    {
        #region Properties

        public string PathToXml { get; protected set; }

        #endregion

        #region Public Methods

        public abstract T ReadXml();
        public abstract bool WriteXml(T obj);

        #endregion
    }
}
