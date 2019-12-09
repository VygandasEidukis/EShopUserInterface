using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    public class ProductViewModel : Conductor<object>
    {
        private BindableCollection<ProductModel> Products_;

        public BindableCollection<ProductModel> Products
        {
            get => Products_;
            set
            {
                Products_ = value;
                NotifyOfPropertyChange(()=> Products);
            }
        }

        public ProductViewModel(List<ProductModel> products)
        {
            Products = new BindableCollection<ProductModel>();
            if(products != null)
                Products.AddRange(products);
        }

        public void ProductClicked(object obj)
        {
            ProductModel product = obj as ProductModel;
            if (obj != null)
            {
                ActivateItem(new DetailedProductViewModel(product));
            }
        }
    }
}
