using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using EShopUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EShopUI.ViewModels
{
    class RegisterViewModel : Screen
    {
        #region props
        public delegate void SendNotifyCall(string title, string text);
        public SendNotifyCall sendNotifyCall;

        public string PasswordRepeat { get; set; }

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


        #endregion

        public RegisterViewModel()
        {
            User = new UserModel();
        }

        #region events
        public async void ButtonRegister()
        {
            try
            {
                bool registrationStatus = false;
                if (PasswordRepeat != User.Password)
                {
                    sendNotifyCall?.Invoke("Password error", Resources.ResourceManager.GetString("PasswordsDontMatch"));
                }
                else
                {
                    LoadLoadingScreen();
                    if (await UserProcessor.RegisterUser(User).ConfigureAwait(true))
                    {
                        //successful registration
                        sendNotifyCall?.Invoke("Registered", Resources.ResourceManager.GetString("RegistrationSuccssesful"));
                        registrationStatus = true;
                    }
                    else
                    {
                        //failed registration
                        sendNotifyCall?.Invoke("Failed", Resources.ResourceManager.GetString("RegistrationFailed"));
                    }
                    UnloadLoadingScreen();
                    if(registrationStatus)
                        (Parent as PreLogInViewModel)?.ActivateItem(new LogInViewModel());
                }
            }
            catch (Exception ex)
            {
                sendNotifyCall?.Invoke("Internal error", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            User.Password = source.Password;
        }

        public void OnPasswordRepeatChanged(PasswordBox source)
        {
            PasswordRepeat = source.Password;
        }
        #endregion

        private void LoadLoadingScreen()
        {
            ((this.Parent as PreLogInViewModel)?.Parent as MainViewModel)?.loadLoadingScreen.Invoke();
        }

        private void UnloadLoadingScreen()
        {
            ((this.Parent as PreLogInViewModel)?.Parent as MainViewModel)?.unloadLoadingScreen.Invoke();
        }
    }
}
