using DotaHeroPickerUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DotaHeroPickerUI.Helpers
{
    public class SerializerHeroPickerSettings : SerializerBase<HeroPickerSettings>
    {
        #region Fields

        private static object _instanceLocker = new object();
        private static SerializerHeroPickerSettings _instance;

        #endregion

        #region Constructors

        private SerializerHeroPickerSettings()
        {
            PathToXml = "Data/HeroPickerSettings.xml";
        }

        #endregion

        #region Public Methods

        public static SerializerHeroPickerSettings GetInstance()
        {
            lock (_instanceLocker)
            {
                return _instance ?? (_instance = new SerializerHeroPickerSettings());
            }
        }

        public override HeroPickerSettings ReadXml()
        {
            HeroPickerSettings obj;
            try
            {
                var xml = XElement.Load(PathToXml);
                obj = new HeroPickerSettings();
                obj.LastDateRefreshHeroAdvantageCollection = XmlConvert.ToDateTime(
                    xml.Element("LastDateRefreshHeroAdvantageCollection").Value, 
                    XmlDateTimeSerializationMode.Unspecified);
                obj.CountDaysForRefreshData = XmlConvert.ToInt32(
                    xml.Element("CountDaysForRefreshData").Value);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
                return null;
            }

            return obj;
        }

        public override bool WriteXml(HeroPickerSettings obj)
        {
            var xml = new XElement("SerializerHeroPickerSettings",
                new XElement("LastDateRefreshHeroAdvantageCollection", obj.LastDateRefreshHeroAdvantageCollection),
                new XElement("CountDaysForRefreshData", obj.CountDaysForRefreshData));

            DirectoryHelper.CreateDirectory(PathToXml);
            try
            {
                xml.Save(PathToXml);
            }
            catch (UnauthorizedAccessException ex)
            {
#if DEBUG
                Console.Write(ex.Message);
#endif
                return false;
            }

            return true;
        }

        #endregion
    }
}
