using System;
using Caliburn.Micro;
using System.Threading;
using System.Windows;
using EShopUI.Views;
using Action = System.Action;

namespace EShopUI.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        private string _NotificationText;

        public string NotificationText
        {
            get => _NotificationText;
            set
            {
                _NotificationText = value;
                NotifyOfPropertyChange(()=> NotificationText);
            }
        }

        public delegate void LoadLoadingScreen();
        public LoadLoadingScreen loadLoadingScreen { get; set; }
        public delegate void UnloadLoadingScreen();
        public UnloadLoadingScreen unloadLoadingScreen { get; set; }

        public MainViewModel()
        {
            ActivateItem(new PreLogInViewModel());
        }

        public async void Notify(string text)
        {
            var view = this.GetView() as MainView;
            NotificationText = text;
            view.NotificationPanel.Visibility = Visibility.Visible;
            var t = new Thread(() =>
            {
                Thread.Sleep(500);
                view.Dispatcher?.Invoke(() => { view.NotificationPanel.Visibility = Visibility.Collapsed; });
            });
            t.Start();
            
        }
    }
}
