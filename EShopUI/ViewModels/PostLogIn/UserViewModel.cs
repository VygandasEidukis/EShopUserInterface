using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopUI.ViewModels
{
    class UserViewModel : Screen
    {
        public delegate void LoadView(object view);
        public LoadView LoadNewView { get; set; }

        private UserModel _User;

        public UserModel User
        {
            get { return _User; }
            set { 
                _User = value;
                NotifyOfPropertyChange(() => User);
            }
        }


        public UserViewModel(UserModel user)
        {
            User = user;
            FetchProducts();
        }

        public void ViewLoaded()
        {
            //set up delegates if view was re-called
            (Parent as PostLogInViewModel).ViewLoaded();
        }

        private async void FetchProducts()
        {
            User.Products = await ProductProcessor.GetProductsByUserID(User.Id).ConfigureAwait(true);
        }
        private async void FetchProductImages()
        {
            for(int i = 0; i < User.Products.Count; i++)
            {
                User.Products[i].ProductImages = await ImageProcessor.GetImagesByProductId(User.Products[i].Id).ConfigureAwait(true);
            }
        }

        public void AddProductButton()
        {
            if (LoadNewView != null)
                LoadNewView.Invoke(new CreateProductViewModel());
        }
    }
}
