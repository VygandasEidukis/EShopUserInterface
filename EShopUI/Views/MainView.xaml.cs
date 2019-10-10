using System;
using System.Windows;
using System.Windows.Controls;
using ApiHelperLibrary;
using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;

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
            /*(await UserProcessor.GetUsers()).ForEach(delegate (UserModel user) 
            {
                ///UserNameBox.Items.Add(user.FirstName);
            });*/
        }
    }
}
