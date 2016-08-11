using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types.Core;

namespace DotaHeroPicker.Factories
{
    abstract class DotaFactory<T> where T : IDotaBase 
    {
        #region Fields

        private static DotaFactory<T> _instance;
        private static readonly object _locker = new object();
        private static readonly object _lockerCreate = new object();

        private readonly List<T> _collection = new List<T>();

        #endregion

        #region Constructors

        protected DotaFactory()
        { }

        #endregion

        #region Public Methods

        public static DotaFactory<T> GetInstance()
        {
            lock (_locker)
            {
                return _instance ?? (_instance = new DotaFactory<T>());
            }
        }

        public bool IsContainsInCollectionElement(object dotaBase)
        {
            return _collection.Any(p =>
            {
                var t = typeof(DotaBase<>);
                var prop = t.GetProperty("DotaName");
                var dotaName = prop.GetValue(p, null);

                t = typeof(DotaName<>);
                prop = t.GetProperty("FullName");
                var valInCollection = prop.GetValue(dotaName, null) as string;

                t = typeof(DotaBase<>);
                prop = t.GetProperty("DotaName");
                dotaName = prop.GetValue(dotaBase, null);

                t = typeof(DotaName<>);
                prop = t.GetProperty("FullName");
                var valOfDotaBase = prop.GetValue(dotaName, null) as string;
                return valInCollection == valOfDotaBase;
            });
        }

        public T CreateElement(List<object> collectionParam)
        {
            lock (_lockerCreate)
            {
                var dotaBase = collectionParam.FirstOrDefault(p => p.GetType() == typeof(DotaBase<>));
                if (dotaBase == null)
                    throw new ArgumentException("Collection of parameters does not contain DotaBase");

                if (IsContainsInCollectionElement(dotaBase))
                    throw new Exception(string.Format("{0} has been created", name));

                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var element = (T)Activator.CreateInstance(typeof(T), flags, null, collectionParam.ToArray(), null);
                _collection.Add(element);

                return element;
            }
        }

        #endregion
    }
}
