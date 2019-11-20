using ApiHelperLibrary.Models;
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
            ((VisitUserViewModel) Parent).ActiveItem = null;
        }

        public void AddToCartButton()
        {
            ((Parent as VisitUserViewModel)?.Parent as PostLogInViewModel)?.ShoppingCartProducts.Add(Product);
            (((Parent as VisitUserViewModel)?.Parent as PostLogInViewModel)?.Parent as MainViewModel)?.Notify($"{Product.Name} has been added to cart");
        }
        
    }
}
