using Caliburn.Micro;
using System.Threading;

namespace EShopUI.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public delegate void LoadLoadingScreen();
        public LoadLoadingScreen loadLoadingScreen;
        public delegate void UnloadLoadingScreen();
        public UnloadLoadingScreen unloadLoadingScreen;

        public MainViewModel()
        {
            ActivateItem(new PreLogInViewModel());
        }
    }
}
