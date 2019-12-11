using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class UserViewModel : Conductor<object>
    {
        public delegate void LoadView(object view);
        public LoadView LoadNewView { get; set; }
        private UserModel _User;
        public UserModel User
        {
            get { return _User; }
            set { 
                _User = value;
                NotifyOfPropertyChange(() => User);
                NotifyOfPropertyChange(() => User.Products);
            }
        }


        public UserViewModel(UserModel user)
        {
            User = user;
            
        }

        public async void ViewLoaded()
        {
            (Parent as PostLogInViewModel)?.ViewLoaded();
            await FetchProducts().ConfigureAwait(true);

            ActivateItem(new ProductViewModel(User.Products, true));
        }

        private async Task FetchProducts()
        {
            User.Products = await ProductProcessor.GetProductsByUserID(User.Id).ConfigureAwait(true);
        }

        public void AddProductButton()
        {
            LoadNewView?.Invoke(new CreateProductViewModel());
        }
    }
}
