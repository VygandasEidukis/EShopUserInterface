using ApiHelperLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ApiHelperLibrary.Processors;

namespace EShopUI.ViewModels
{
    class ShoppingCartViewModel : Screen
    {
        public int UserId
        {
            get => (Parent as PostLogInViewModel).User.Id;
        }
        private double _OverallPrice;

        public double OverallPrice
        {
            get => _OverallPrice;
            set { _OverallPrice = value; NotifyOfPropertyChange(()=>OverallPrice); }
        }

        private BindableCollection<ProductModel> _Products;

        public BindableCollection<ProductModel> Products
        {
            get { return _Products; }
            set
            {
                _Products = value;
                NotifyOfPropertyChange(()=>Products);
                CalculatePrice();
            }
        }



        public ShoppingCartViewModel()
        { 
            Products = new BindableCollection<ProductModel>();
        }

        public async void Loaded()
        {
            var tempProd = await CartProcessor.GetCartProducts(UserId).ConfigureAwait(true);
            foreach (var product in tempProd)
            {
                Products.Add(product);
            }
            CalculatePrice();
        }

        public void Buy()
        {
            MessageBox.Show("test");
        }

        public void ProductClicked(object obj)
        {
            if (obj == null) return;
            var prod = obj as ProductModel;
            Products.Remove(prod);
            CartProcessor.RemoveProductFromCart(prod,UserId);
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            OverallPrice = Products.Sum(product => product.Price);
        }
    }
}
