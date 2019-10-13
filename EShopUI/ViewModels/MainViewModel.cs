using Caliburn.Micro;
using System.Threading;

namespace EShopUI.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public delegate void LoadLoadingScreen();
        public LoadLoadingScreen loadLoadingScreen { get; set; }
        public delegate void UnloadLoadingScreen();
        public UnloadLoadingScreen unloadLoadingScreen { get; set; }

        public MainViewModel()
        {
            ActivateItem(new PreLogInViewModel());
        }
    }
}
