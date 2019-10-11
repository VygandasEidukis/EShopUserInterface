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
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        private LogInViewModel dataContext;
        public LogInView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext = DataContext as LogInViewModel;
            dataContext.sendNotifyCall += CallNotification;
        }

        public void CallNotification(string title, string text)
        {
            (dataContext.Parent as PreLogInViewModel).CallPopup(title, text);
        }
    }
}
