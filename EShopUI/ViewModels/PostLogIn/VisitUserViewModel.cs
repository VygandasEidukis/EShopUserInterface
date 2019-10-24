using ApiHelperLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopUI.ViewModels.PostLogIn
{
    class VisitUserViewModel : Screen
    {
        private UserModel _User;

        public UserModel User
        {
            get { return _User; }
            set 
            {
                _User = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public VisitUserViewModel(UserModel User)
        {
            this.User = User;
        }
    }
}
