
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDota
{
    public class DatabaseHelper
    {
        #region Constants

        private const int DatabaseCount = 20;

        #endregion

        #region Fields

        private static object _instanceLocker = new object();
        private static DatabaseHelper _instance;

        #endregion

        #region Properties

        public string CurrentDatabaseName { get; private set; }
        public string DatabaseName { get; private set; }

        #endregion

        #region Constructors

        private DatabaseHelper(string database)
        {
            DatabaseName = database;
            CurrentDatabaseName = database;
        }

        #endregion

        #region Public Methods

        public static DatabaseHelper GetInstance(string database)
        {
            lock (_instanceLocker)
            {
                return _instance ?? (_instance = new DatabaseHelper(database));
            }
        }

        public string NextDatabaseName()
        {
            int currentIndex = 0;
            int.TryParse(CurrentDatabaseName.Replace(DatabaseName, string.Empty), out currentIndex);
            // Скидываем счётчик, если достигли максимума
            CurrentDatabaseName = DatabaseCount > currentIndex ?
                string.Format("{0}{1}", DatabaseName, ++currentIndex) 
                : DatabaseName;

            return CurrentDatabaseName;
        }

        #endregion
    }
}
