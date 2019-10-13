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
            //Important
            FetchProducts();
        }

        private async void FetchProducts()
        {
            User.Products = await ProductProcessor.GetProductsByUserID(User.Id).ConfigureAwait(true);
            FetchProductImages();
        }
        private async void FetchProductImages()
        {
            for(int i = 0; i < User.Products.Count; i++)
            {
                User.Products[i].ProductImages = await ImageProcessor.GetImagesByProductId(User.Products[i].Id).ConfigureAwait(true);
            }
        }
    }
}
