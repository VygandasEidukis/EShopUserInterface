using ApiHelperLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private BindableCollection<ProductModel> _Products;

        public BindableCollection<ProductModel> Products
        {
            get => _Products;
            set 
            { 
                _Products = value;
                NotifyOfPropertyChange(()=>Products);
                CalculatePrice();
            }
        }

        public ShoppingCartViewModel(List<ProductModel> Product)
        {
            Products = new BindableCollection<ProductModel>();
            foreach (var productModel in Product)
            {
                Products.Add(productModel);
            }
        }

        public void ProductClicked(object obj)
        {
            if (obj == null) return;
            Products.Remove(obj as ProductModel);
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            OverallPrice = Products.Sum(product => product.Price);
        }
    }
}
