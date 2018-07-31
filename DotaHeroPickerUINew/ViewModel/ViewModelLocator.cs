/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DotaHeroPickerUINew"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace DotaHeroPickerUINew.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<HostViewModel>();
            SimpleIoc.Default.Register<HeroPickerViewModel>();
            SimpleIoc.Default.Register<CounterHeroesViewModel>();
        }

        public HostViewModel Host
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HostViewModel>();
            }
        }

        public HeroPickerViewModel HeroPicker
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HeroPickerViewModel>();
            }
        }

        public CounterHeroesViewModel CounterHeroes
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CounterHeroesViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}