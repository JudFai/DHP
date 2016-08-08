using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotaHeroPickerUI.Model
{
    public class HeroPickerSettings
    {
        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Дата последнего обновления преимуществ героя
        /// </summary>
        public DateTime LastDateRefreshHeroAdvantageCollection { get; set; }

        /// <summary>
        /// Количество дней с даты последнего обновления преимуществ героев, когда необходимо обновить данные преимуществ
        /// </summary>
        public int CountDaysForRefreshData { get; set; }

        #endregion

        #region Constructors

        public HeroPickerSettings()
        {
            LastDateRefreshHeroAdvantageCollection = DateTime.MinValue;
            CountDaysForRefreshData = 1;
        }

        #endregion

        #region Public Methods


        // TODO: поменять на write
        //public static void Serialize(string file, HeroPickerSettings c)
        //{
        //    var xs = new XmlSerializer(c.GetType());
        //    var writer = File.CreateText(file);
        //    xs.Serialize(writer, c);
        //    writer.Flush();
        //    writer.Close();
        //}

        //// TODO: поменять на write
        //public static HeroPickerSettings Deserialize(string file)
        //{
        //    HeroPickerSettings obj;
        //    try
        //    {
        //        var xs = new XmlSerializer(typeof (HeroPickerSettings));
        //        var reader = File.OpenText(file);
        //        obj = xs.Deserialize(reader) as HeroPickerSettings;
        //        reader.Close();
        //    }
        //    catch
        //    {
        //        obj = new HeroPickerSettings();
        //    }

        //    return obj;
        //}

        #endregion
    }
}
