using ApiHelperLibrary.Models;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class VisitUserViewModel : Conductor<object>
    {
        private UserModel _User;

        public UserModel User
        {
            get { return _User; }
            set 
            {
                _User = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public VisitUserViewModel(UserModel User)
        {
            this.User = User;
        }

        public void ProductClicked(object obj)
        {
            ProductModel product = obj as ProductModel;
            if(obj != null)
            {
                ActivateItem(new DetailedProductViewModel(product));
            }
        }
    }
}
