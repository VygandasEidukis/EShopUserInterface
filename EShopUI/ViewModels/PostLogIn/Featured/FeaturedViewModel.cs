using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class FeaturedViewModel : Conductor<object>
    {
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


        public FeaturedViewModel()
        {
            Products = new BindableCollection<ProductModel>();
        }

        public async void Loaded()
        {
            var prods = await EuklideanProcessor.GetFeaturedProducts().ConfigureAwait(true);
            Products.AddRange(prods);
            ActivateItem(new ProductViewModel(Products.ToList()));
        }
    }
}
