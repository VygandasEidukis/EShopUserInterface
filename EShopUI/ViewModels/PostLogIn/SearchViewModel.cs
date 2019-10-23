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
        private string _searchText;
        public string searchText
        {
            get { return _searchText; }
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
                    var a = await SearchProcessor.SearchByUsername(searchText).ConfigureAwait(false);
                }
            }
        }
    }
}
