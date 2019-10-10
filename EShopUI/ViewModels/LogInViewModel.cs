using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EShopUI.ViewModels
{
    public class LogInViewModel : Screen
    {
        #region props
        public delegate void SendNotifyCall(string title, string text);
        public SendNotifyCall sendNotifyCall;

        private string _TextBoxUsername;
        public string TextBoxUsername
        {
            get { return _TextBoxUsername; }
            set
            {
                _TextBoxUsername = value;
                NotifyOfPropertyChange(() => TextBoxUsername);
            }
        }

        private string _TextBoxPassword;
        public string TextBoxPassword
        {
            get { return _TextBoxPassword; }
            set
            {
                _TextBoxPassword = value;
                NotifyOfPropertyChange(() => TextBoxPassword);
            }
        }

        #endregion
        public LogInViewModel()
        {

        }

        #region events
        public async void ButtonLogIn()
        {
            UserModel user =  await UserProcessor.LogInUser(new UserModel() { Username = TextBoxUsername, Password = TextBoxPassword});
            if(user == null)
            {
                CallNotification("Failed to login", "Invalid username or password");
            }
            else
            {
                CallNotification("Logged in", $"{user.FirstName}  {user.LastName}");
                //TODO: should redirect to front page
            }
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            TextBoxPassword = source.Password;
        }
        #endregion

        public void CallNotification(string title, string text)
        {
            if (sendNotifyCall != null)
                sendNotifyCall.Invoke(title, text);
        }
    }
}
