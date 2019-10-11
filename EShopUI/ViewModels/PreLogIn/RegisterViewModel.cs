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
                if (PasswordRepeat != User.Password)
                {
                    if (sendNotifyCall != null)
                        sendNotifyCall.Invoke("Password error", "Passwords don't match, please make sure both passwords are the same");
                }
                else
                {
                    LoadLoadingScreen();
                    if (await UserProcessor.RegisterUser(User).ContinueWith(
                        (task) => 
                        {
                            UnloadLoadingScreen();
                            try {
                                return task.Result;
                            }catch
                            {
                                return false;
                            }
                        }))
                    {
                        //succssesfull registration   await UserProcessor.RegisterUser(User);
                        if (sendNotifyCall != null)
                            sendNotifyCall.Invoke("Registered", "Succssesfully registered");
                    }
                    else
                    {
                        //failed registration
                        if (sendNotifyCall != null)
                            sendNotifyCall.Invoke("Failed", "failed to register");
                    }
                }
            }catch(Exception ex)
            {
                if (sendNotifyCall != null)
                    sendNotifyCall.Invoke("Internal error", ex.Message);
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
            ((this.Parent as PreLogInViewModel).Parent as MainViewModel).loadLoadingScreen.Invoke();
        }

        private void UnloadLoadingScreen()
        {
            ((this.Parent as PreLogInViewModel).Parent as MainViewModel).unloadLoadingScreen.Invoke();
        }
    }
}
