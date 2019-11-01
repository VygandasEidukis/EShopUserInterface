using ApiHelperLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;

namespace EShopUI.ViewModels
{
    class PostLogInViewModel : Conductor<object>
    {
        public UserModel User { get; set; }

        public List<ProductModel> ShoppingCartProducts { get; set; }
        public PostLogInViewModel(UserModel user)
        {
            User = user;
            ShoppingCartProducts = new List<ProductModel>();
            ActivateItem(new UserViewModel(user));
        }

        public void ButtonHome()
        {
            ActivateItem(new UserViewModel(User));
        }

        public void ButtonSearch()
        {
            ActivateItem(new SearchViewModel());
        }

        public void ButtonLogOut()
        {
            (Parent as MainViewModel).ActivateItem(new PreLogInViewModel());
        }

        public void ButtonCart()
        {
            ActivateItem(new ShoppingCartViewModel(ShoppingCartProducts));
        }

        public void ViewLoaded()
        {
            if ((ActiveItem as UserViewModel) != null)
                (ActiveItem as UserViewModel).LoadNewView += LoadNewView;
        }

        public void LoadNewView(object view)
        {
            try
            {
                ActivateItem(view);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
