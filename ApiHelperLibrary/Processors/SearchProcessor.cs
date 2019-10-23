using ApiHelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Processors
{
    public class SearchProcessor : Processor
    {
        public static async Task<List<UserModel>> SearchByUsername(string username)
        {
                using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkSearchByUsername(username)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var users = await response.Content.ReadAsAsync<List<UserModel>>();
                    
                        for(int i = 0; i < users.Count(); i++)
                        {
                            users[i].Products = await ProductProcessor.GetProductsByUserID(users[i].Id).ConfigureAwait(true);
                        }

                        return users;
                    }
                    throw new Exception("Unexpected error in SearchProcessor");
                }
        }
    }
}
