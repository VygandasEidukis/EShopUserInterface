using System;
using System.Windows;
using System.Windows.Controls;
using ApiHelperLibrary;
using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using EShopUI.ViewModels;

namespace EShopUI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as MainViewModel).loadLoadingScreen += LoadLoadingScreen;
            (DataContext as MainViewModel).unloadLoadingScreen += UnloadLoadingScreen;
        }

        public void LoadLoadingScreen()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                Spinner.Spin = true;
                LoadingScreen.Visibility = Visibility.Visible;
            }));
            
        }

        public void UnloadLoadingScreen()
        {
            Dispatcher.Invoke(new Action(()=> 
            {
                Spinner.Spin = false;
                LoadingScreen.Visibility = Visibility.Collapsed;
            }));
        }
    }
}
