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
        /// Получить enum-сущность класса DotaName
        /// </summary>
        /// <param name="dotaName">Эзкемпляр класса DotaName</param>
        /// <returns>Enum-сущность</returns>
        private string GetEntityByDotaName(object dotaName)
        {
            //var t = typeof(DotaBase<>);
            //var prop = t.GetProperty("DotaName");
            //var dotaName = prop.GetValue(dotaBase, null);

            var t = typeof(T);
            var prop = t.GetProperty("DotaName");
            t = prop.PropertyType;
            prop = t.GetProperty("Entity");
            var val = prop.GetValue(dotaName, null).ToString();

            return val;
        }

        private string GetEntityByDotaBase(object dotaBase)
        {
            var t = dotaBase.GetType();
            var prop = t.GetProperty("DotaName");
            var val = prop.GetValue(dotaBase);
            return GetEntityByDotaName(val);
        }

        private bool IsContainsInCollectionElement(string entity)
        {
            return _collection.Any(p => GetEntityByDotaBase(p) == entity);
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

        /// <summary>
        /// Первым элементом в коллекции обязательно должен быть DotaName
        /// </summary>
        public T CreateElement(List<object> collectionParam)
        {
            lock (_lockerCreate)
            {
                var dotaName = collectionParam.FirstOrDefault(p => p.GetType().GetGenericTypeDefinition() == typeof(DotaName<>));
                if (dotaName == null)
                    throw new ArgumentException("Collection of parameters does not contain DotaName");

                var entity = GetEntityByDotaName(dotaName);
                if (IsContainsInCollectionElement(entity))
                    throw new Exception(string.Format("{0} has been created", entity));

                var flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var element = (T)Activator.CreateInstance(typeof(T), flags, null, collectionParam.ToArray(), null);
                _collection.Add(element);

                return element;
            }
        }

        public T CreateElement(object dotaName)
        {
            return CreateElement(new List<object> { dotaName });
        }

        #endregion
    }
}
