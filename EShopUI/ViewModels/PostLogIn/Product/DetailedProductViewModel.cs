using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class DetailedProductViewModel : Screen
    {
        public ProductModel Product { get; set; }

        public DetailedProductViewModel(ProductModel product)
        {
            Product = product;
        }

        public void ButtonBack()
        {
            ((dynamic) Parent).ActiveItem = null;
        }

        public void AddToCartButton()
        {
            var user = GetPostLogin().User;
            CartProcessor.AddProductToCart(Product, user);

            (((Parent as VisitUserViewModel)?.Parent as PostLogInViewModel)?.Parent as MainViewModel)?.Notify($"{Product.Name} has been added to cart");
        }

        private dynamic GetPostLogin()
        {
            dynamic parent = Parent as dynamic;
            while (!(parent is PostLogInViewModel))
            {
                parent = parent.Parent as dynamic;
            }

            return parent;
        }
        
    }
}
