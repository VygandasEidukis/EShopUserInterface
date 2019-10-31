using ApiHelperLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopUI.ViewModels
{
    class PostLogInViewModel : Conductor<object>
    {
        public UserModel User { get; set; }
        public PostLogInViewModel(UserModel user)
        {
            User = user;
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
            ActivateItem(new PreLogInViewModel());
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
