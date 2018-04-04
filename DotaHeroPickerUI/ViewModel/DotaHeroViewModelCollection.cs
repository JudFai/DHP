using DotaHeroPicker.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel
{
    public class DotaHeroViewModelCollection : ReadOnlyCollection<DotaHeroViewModel>
    {
        #region Fields

        private static readonly object _instanceLocker = new object();
        private static DotaHeroViewModelCollection _instance;

        private readonly string _pathToHeroImage = "/HeroPickerResources;component/Images/Heroes/";
        private readonly string _pathToHeroIcons = "/HeroPickerResources;component/Images/Heroes/Icons/";

        #endregion

        #region Properties

        public DotaHeroCollection Model { get; private set; }

        #endregion

        #region Public Methods

        public static DotaHeroViewModelCollection GetInstance()
        {
            lock (_instanceLocker)
            {
                var model = DotaHeroCollection.GetInstance();
                return new DotaHeroViewModelCollection(model);
            }
        }

        #endregion

        #region Constructors

        private DotaHeroViewModelCollection(DotaHeroCollection model)
            : base(new List<DotaHeroViewModel>())
        {
            Model = model;
            foreach (var hero in model)
            {
                var dotaHeroVM = new DotaHeroViewModel(hero,
                    string.Format("{0}{1}.jpg", _pathToHeroImage, hero.DotaName.Entity),
                    true,
                    string.Format("{0}{1}.png", _pathToHeroIcons, hero.DotaName.Entity));
                Items.Add(dotaHeroVM);
            }
        }

        #endregion
    }
}
