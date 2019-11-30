using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using EShopUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EShopUI.ViewModels
{
    public class LogInViewModel : Screen
    {
        #region props
        public delegate void SendNotifyCall(string title, string text);
        public SendNotifyCall sendNotifyCall { get; set; }

        private string _TextBoxUsername;
        public string TextBoxUsername
        {
            get => _TextBoxUsername;
            set
            {
                _TextBoxUsername = value;
                NotifyOfPropertyChange(() => TextBoxUsername);
            }
        }

        private string _TextBoxPassword;
        public string TextBoxPassword
        {
            get => _TextBoxPassword;
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
            LoadLoadingScreen();
            UserModel user = await LogInUser(TextBoxUsername, TextBoxPassword).ConfigureAwait(true);
            if (user == null)
            {
                CallNotification("Failed to login", Resources.ResourceManager.GetString("BadLogin"));
            }
            else
            {
                CallNotification("Logged in as", $"{user.FirstName}  {user.LastName}");
                ((Parent as PreLogInViewModel)?.Parent as MainViewModel).ActiveItem = new PostLogInViewModel(user);
            }
        }

        private async Task<UserModel> LogInUser(string username, string password)
        {
            try
            {
                var loginDetails = new UserModel {Username = username, Password = password};
                var user = await UserProcessor.LogInUser(loginDetails).ConfigureAwait(true);
                UnloadLoadingScreen();
                return user;
            }
            catch
            {
                UnloadLoadingScreen();
                //TODO: remove this return null on release
                return null;
                throw new Exception(Resources.ResourceManager.GetString("NetworkError"));
            }
            
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            if(source != null)
                TextBoxPassword = source.Password;
        }
        #endregion

        public void CallNotification(string title, string text)
        {
            if (sendNotifyCall != null)
                sendNotifyCall.Invoke(title, text);
        }

        private void LoadLoadingScreen()
        {
            ((this.Parent as PreLogInViewModel).Parent as MainViewModel).loadLoadingScreen.Invoke();
        }

        private void UnloadLoadingScreen()
        {
            ((this.Parent as PreLogInViewModel).Parent as MainViewModel).unloadLoadingScreen.Invoke();
        }
    }
}
