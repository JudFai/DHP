using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotaHeroPicker.Types.Core;

namespace DotaHeroPicker.Factories
{
    abstract class DotaFactory<T, TSingleTone> 
        where T : IDotaBase
        where TSingleTone : DotaFactory<T, TSingleTone>
    {
        #region Fields

        private static TSingleTone _instance;
        private static readonly object _locker = new object();
        private static readonly object _lockerCreate = new object();

        private readonly List<T> _collection = new List<T>();

        #endregion

        #region Constructors

        protected DotaFactory()
        { }

        #endregion

        #region Private Methods

        /// <summary>
        /// Получить полное имя DotaName
        /// </summary>
        /// <param name="dotaName">Эзкемпляр класса DotaName</param>
        /// <returns>Полное имя</returns>
        private string GetFullNameByDotaName(object dotaName)
        {
            //var t = typeof(DotaBase<>);
            //var prop = t.GetProperty("DotaName");
            //var dotaName = prop.GetValue(dotaBase, null);

            var t = typeof(T);
            var prop = t.GetProperty("DotaName");
            t = prop.PropertyType;
            prop = t.GetProperty("FullName");
            var val = prop.GetValue(dotaName, null) as string;

            return val;
        }

        private string GetFullNameByDotaBase(object dotaBase)
        {
            var t = dotaBase.GetType();
            var prop = t.GetProperty("DotaName");
            var val = prop.GetValue(dotaBase);
            return GetFullNameByDotaName(val);
        }

        private bool IsContainsInCollectionElement(object dotaBase)
        {
            var val = GetFullNameByDotaName(dotaBase);
            return _collection.Any(p => GetFullNameByDotaBase(p) == val);
        }

        private bool IsContainsInCollectionElement(string fullname)
        {
            return _collection.Any(p => GetFullNameByDotaBase(p) == fullname);
        }

        #endregion

        #region Public Methods

        public static TSingleTone GetInstance()
        {
            lock (_locker)
            {
                if (_instance == null)
                {
                    var constructor = typeof (TSingleTone).GetConstructor(
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, 
                        null, 
                        Type.EmptyTypes,
                        null);
                    _instance = (TSingleTone)constructor.Invoke(null);
                }
            }

            return _instance;
        }

        public T CreateElement(List<object> collectionParam)
        {
            lock (_lockerCreate)
            {
                var dotaName = collectionParam.FirstOrDefault(p => p.GetType().GetGenericTypeDefinition() == typeof(DotaName<>));
                if (dotaName == null)
                    throw new ArgumentException("Collection of parameters does not contain DotaName");

                var fullName = GetFullNameByDotaName(dotaName);
                if (IsContainsInCollectionElement(fullName))
                    throw new Exception(string.Format("{0} has been created", fullName));

                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var element = (T)Activator.CreateInstance(typeof(T), flags, null, collectionParam.ToArray(), null);
                _collection.Add(element);

                return element;
            }
        }

        #endregion
    }
}
