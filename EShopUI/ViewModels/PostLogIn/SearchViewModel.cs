using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using EShopUI.ViewModels.PostLogIn;
using EShopUI.Views;

namespace EShopUI.ViewModels
{
    class SearchViewModel : Screen
    {
        private BindableCollection<UserModel> _Users;

        public BindableCollection<UserModel> Users
        {
            get 
            {
                return _Users; 
            }
            set 
            { 
                _Users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }


        private string _searchText;
        public string searchText
        {
            get 
            { 
                return _searchText; 
            }
            set 
            { 
                _searchText = value;
                NotifyOfPropertyChange(()=>searchText);
            }
        }

        public SearchViewModel()
        {

        }

        public void LoadUserPage(object selectedPage)
        {
            UserModel selectedUser = (selectedPage as System.Windows.Controls.Border).DataContext as UserModel;
            if(selectedUser != null)
            {
                (Parent as PostLogInViewModel).LoadNewView(new VisitUserViewModel(selectedUser));
            }
        }

        public async void SearchButton()
        {
            if (searchText != null)
            {
                if (searchText.Length > 0)
                {
                    var userList = await SearchProcessor.SearchByUsername(searchText).ConfigureAwait(true);
                    Users = new BindableCollection<UserModel>();
                    for(int i = 0; i < userList.Count; i++)
                    {
                        if (userList[i].Username != (Parent as PostLogInViewModel).User.Username || userList[i].FirstName.Length >0)
                        {
                            Users.Add(userList[i]);
                        }
                    }
                }
            }
        }

        public async void AdvancedSearchButton()
        {
            (Parent as PostLogInViewModel).LoadNewView(new AdvancedSearchViewModel());
        }
    }
}
