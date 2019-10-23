using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        if (userList[i].Username != (Parent as PostLogInViewModel).User.Username)
                        {
                            Users.Add(userList[i]);
                        }
                    }
                }
            }
        }
    }
}
