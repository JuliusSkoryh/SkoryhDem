using Dem.Models.Stores;
using Dem.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Dem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationStore _navigationStore = new NavigationStore();

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new Window()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            base.OnStartup(e);
        }
    }

}
