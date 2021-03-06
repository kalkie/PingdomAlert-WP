/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PhoneApp1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PingdomAlertShared;
using PingdomAlertShared.Logging;

namespace PingdomAlert.WP8.ViewModel
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

            SimpleIoc.Default.Register<BackgroundImageBrush>();
            SimpleIoc.Default.Register<ILogging>(() => new DebugLogger());
            SimpleIoc.Default.Register<PingdomSettingsManager>();
            SimpleIoc.Default.Register<PingdomHttpClient>();
            SimpleIoc.Default.Register<PingdomManager>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.GetInstance<MainViewModel>();
            SimpleIoc.Default.Register<CheckDetailViewModel>();
            SimpleIoc.Default.GetInstance<CheckDetailViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.GetInstance<SettingsViewModel>();
            
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

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CheckDetailViewModel CheckDetail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CheckDetailViewModel>();
            }
        }

        public SettingsViewModel Settings
        {
            get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}