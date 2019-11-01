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
        private List<ProductModel> _Product;

        public List<ProductModel> Product
        {
            get { return _Product; }
            set 
            { 
                _Product = value;
                NotifyOfPropertyChange(()=>Product);
            }
        }

        public ShoppingCartViewModel(List<ProductModel> Product)
        {
            this.Product = Product;
        }
    }
}
