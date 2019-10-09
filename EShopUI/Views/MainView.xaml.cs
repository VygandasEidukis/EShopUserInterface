using System.Windows.Controls;
using ApiHelperLibrary;
using ApiHelperLibrary.Processors;

namespace EShopUI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UserNameBox.Items.Add((await UserProcessor.GetUserByID(1)).FirstName);
        }
    }
}
