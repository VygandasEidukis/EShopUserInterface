using Caliburn.Micro;
using EShopUI.ViewModels;
using System.Windows;

namespace EShopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
        #endregion
    }
}
