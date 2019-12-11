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
        public bool IsUser { get; set; } = false;

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
            if (products != null)
                Products.AddRange(products);
        }

        public ProductViewModel(List<ProductModel> products, bool isUser)
        {
            IsUser = isUser;
            Products = new BindableCollection<ProductModel>();
            if (products != null)
                Products.AddRange(products);
        }

        public void ProductClicked(object obj)
        {
            if(!(obj is ProductModel)) return;
            ProductModel product = (ProductModel) obj;
            if (!IsUser)
            {
                LoadDetailedView(product);
            }
            else
            {
                LoadEditProduct(product);
            }
           
        }

        private void LoadDetailedView(ProductModel product)
        {
            ActivateItem(new DetailedProductViewModel(product));
        }

        private void LoadEditProduct(ProductModel product)
        {
            //TODO: change to load to edit view
        }
    }
}
