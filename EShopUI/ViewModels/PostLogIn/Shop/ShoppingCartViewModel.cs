using ApiHelperLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EShopUI.ViewModels
{
    class ShoppingCartViewModel : Screen
    {
        private double _OverallPrice;

        public double OverallPrice
        {
            get => _OverallPrice;
            set { _OverallPrice = value; NotifyOfPropertyChange(()=>OverallPrice); }
        }

        private CartModel _Cart;

        public CartModel Cart
        {
            get => _Cart;
            set 
            { 
                _Cart = value;
                NotifyOfPropertyChange(()=>Cart);
                Products = new BindableCollection<ProductModel>();
                foreach (var product in Cart.Products)
                {
                    _Products.Add(product);
                }
                CalculatePrice();
            }
        }

        private BindableCollection<ProductModel> _Products;

        public BindableCollection<ProductModel> Products
        {
            get { return _Products; }
            set
            {
                _Products = value;
                NotifyOfPropertyChange(()=>Products);
            }
        }



        public ShoppingCartViewModel(List<ProductModel> product)
        {
            Cart = new CartModel {Products = product};
        }

        public void Buy()
        {
            MessageBox.Show("test");
        }

        public void ProductClicked(object obj)
        {
            if (obj == null) return;
            Cart.Products.Remove(obj as ProductModel);
            Products.Remove(obj as ProductModel);
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            OverallPrice = Cart.Products.Sum(product => product.Price);
        }
    }
}
