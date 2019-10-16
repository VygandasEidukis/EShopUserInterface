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
        public PostLogInViewModel(UserModel user)
        {
            ActivateItem(new UserViewModel(user));
        }
    
        public void ViewLoaded()
        {
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
