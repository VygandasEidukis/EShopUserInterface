using EShopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EShopUI.Views
{
    /// <summary>
    /// Interaction logic for PreLogInView.xaml
    /// </summary>
    public partial class PreLogInView : UserControl
    {
        private PreLogInViewModel dataContext;
        public PreLogInView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext = DataContext as PreLogInViewModel;

            dataContext.notifyOpenPopup += PopUpNotify;
        }

        private void ButtonNotificationOk_Click(object sender, RoutedEventArgs e)
        {
            NotificationWindow.Visibility = Visibility.Collapsed;
        }

        private void PopUpNotify()
        {
            NotificationWindow.Visibility = Visibility.Visible;
        }

        

       
    }
}
