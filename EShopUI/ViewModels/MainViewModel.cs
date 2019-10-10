using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {
            ActivateItem(new PreLogInViewModel());
        }
    }
}
