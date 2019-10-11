using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EShopUI.ViewModels
{
    class PreLogInViewModel : Conductor<object>
    {
        #region Props
        public delegate void NotifyPopUP();
        public NotifyPopUP notifyOpenPopup;

        private string _NotificationMessage;

        public string NotificationMessage
        {
            get { return _NotificationMessage; }
            set
            {
                _NotificationMessage = value;
                NotifyOfPropertyChange(() => NotificationMessage);
            }
        }

        private string _NotificationTitle;

        public string NotificationTitle
        {
            get { return _NotificationTitle; }
            set
            {
                _NotificationTitle = value;
                NotifyOfPropertyChange(() => NotificationTitle);
            }
        }

        #endregion


        public PreLogInViewModel()
        {
            ActivateItem(new LogInViewModel());
        }

        #region events

        public void ButtonRegister()
        {
            ActivateItem(new RegisterViewModel());
        }

        public void ButtonLogin()
        {
            ActivateItem(new LogInViewModel());
        }

        public void ButtonNotificationOk()
        {

        }

        #endregion

        #region Functions
        
        public void CallPopup(string title, string text)
        {
            NotificationMessage = text;
            NotificationTitle = title;

            if (notifyOpenPopup != null)
                notifyOpenPopup.Invoke();
        }
        #endregion
    }
}
