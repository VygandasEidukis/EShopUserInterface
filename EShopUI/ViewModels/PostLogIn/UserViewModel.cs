using System.Linq;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class UserViewModel : Screen
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

        private BindableCollection<ProductModel> _Products;

        public BindableCollection<ProductModel> Products
        {
            get
            {
                var prodTemp = new BindableCollection<ProductModel>();
                prodTemp.AddRange(User.Products);
                return prodTemp;
            }
            set
            {
                User.Products = value.ToList();
                NotifyOfPropertyChange(()=> Products);
            }
        }


        public UserViewModel(UserModel user)
        {
            User = user;
            
        }

        public async void ViewLoaded()
        {
            //set up delegates if view was re-called
            (Parent as PostLogInViewModel).ViewLoaded();
            await FetchProducts().ConfigureAwait(false);
        }

        private async Task FetchProducts()
        {
            User.Products = await ProductProcessor.GetProductsByUserID(User.Id).ConfigureAwait(true);
        }
        private async void FetchProductImages()
        {
            for(int i = 0; i < User.Products.Count; i++)
            {
                User.Products[i].ProductImages = await ImageProcessor.GetImagesByProductId(User.Products[i].Id).ConfigureAwait(true);
            }
        }

        public void AddProductButton()
        {
            if (LoadNewView != null)
                LoadNewView.Invoke(new CreateProductViewModel());
        }
    }
}
