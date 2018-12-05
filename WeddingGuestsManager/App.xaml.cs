using System;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using WeddingGuestsManager.ViewModels;

namespace WeddingGuestsManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel _mainViewModel;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //InitViewModels();
            //CreateAndShowMainWindow();
        }

        private void InitViewModels()
        {
            //_mainViewModel = new MainViewModel();
            //_mainViewModel = SimpleIoc.Default.GetInstance<MainViewModel>();
        }

        //private void CreateAndShowMainWindow()
        //{
        //    MainWindow = new MainWindow { DataContext = _mainViewModel };
        //    Current.MainWindow = MainWindow;
        //    MainWindow.Show();
        //}
    }
}
