using ApiHelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public static async Task<List<ProductModel>> SearchByEuclidean(double price, ProductType type)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsJsonAsync<EuklideanModel>(LinkSearchProductsByEuclidean(),new EuklideanModel(){ Price = price, ProductType =  type}))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ProductModel>>(); 
                }
                throw new Exception("Unexpected error in SearchProcessor");
            }
        }
    }
}
