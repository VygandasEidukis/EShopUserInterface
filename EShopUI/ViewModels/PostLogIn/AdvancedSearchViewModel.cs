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
    class AdvancedSearchViewModel : Screen
    {


        private double Price_;

        public double Price
        {
            get { return Price_; }
            set
            {
                Price_ = value;
                NotifyOfPropertyChange(()=> Price);
            }
        }


        private ProductType selectedItemsType_;

        public ProductType selectedItemsType
        {
            get { return selectedItemsType_; }
            set { selectedItemsType_ = value; NotifyOfPropertyChange(()=> selectedItemsType);}
        }

        private BindableCollection<ProductType> itemsType_;

        public BindableCollection<ProductType> itemsType
        {
            get { return itemsType_; }
            set { itemsType_ = value; NotifyOfPropertyChange(()=>itemsType); }
        }

        public AdvancedSearchViewModel()
        {
            itemsType = new BindableCollection<ProductType>();
            
        }

        public async void ViewLoaded()
        {
            var productTypes = await ProductProcessor.GetProductTypes().ConfigureAwait(true);
            itemsType.AddRange(productTypes);
        }

        public async void SearchButton()
        {
            var products = await SearchProcessor.SearchByEuclidean(Price, selectedItemsType).ConfigureAwait(true);
            (Parent as PostLogInViewModel).ActivateItem(new ProductViewModel(products));
        }

    }
}
