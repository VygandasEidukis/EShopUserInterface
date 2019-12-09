using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using Caliburn.Micro;

namespace EShopUI.ViewModels
{
    class FeaturedViewModel : Screen
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
            
        }

        public async void Loaded()
        {
            
        }
    }
}
