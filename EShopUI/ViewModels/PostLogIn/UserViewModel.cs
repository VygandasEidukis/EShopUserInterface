using System.Linq;
using System.Threading;
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
                if (User.Products != null)
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

        public void ViewLoaded()
        {
            new Thread(() =>
            {
                (Parent as PostLogInViewModel)?.ViewLoaded();
                FetchProducts();
            }).Start();
        }

        private void FetchProducts()
        {
            var t = new Task(async () =>
            {
                User.Products = await ProductProcessor.GetProductsByUserID(User.Id).ConfigureAwait(true);
                NotifyOfPropertyChange(() => Products);
            });

            t.Start();

        }
        private void FetchProductImages()
        {
            var t = new Task(async () =>
            {
                foreach (var product in User.Products)
                {
                    product.ProductImages = await ImageProcessor.GetImagesByProductId(product.Id).ConfigureAwait(true);
                }
            });

            t.Start();
        }

        public void AddProductButton()
        {
            LoadNewView?.Invoke(new CreateProductViewModel());
        }
    }
}
