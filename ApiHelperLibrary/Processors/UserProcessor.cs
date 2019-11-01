using ApiHelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ApiHelperLibrary.Processors
{
    public class UserProcessor : Processor
    {
        
        public static async Task<UserModel> GetUserByID(int id = 1)
        {
            using(HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkGetUserById(id)))
            {
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<UserModel>();
                }
                throw new Exception("User does't exist in current api");
            }
        }

        public static async Task<List<UserModel>> GetUsers()
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkGetUsers()))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<UserModel>>();
                }
                throw new Exception("Unexpected error in UserProcessor");
            }
        }

        public static async Task<UserModel> LogInUser(UserModel user)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsJsonAsync<UserModel>(LinkLogInUser(), user))
            {
                if (response.IsSuccessStatusCode)
                {
                    var userJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserModel>(userJson);
                }
                throw new Exception("Unexpected error in UserProcessor");
            }
        }

        public static async Task<bool> RegisterUser(UserModel user)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsJsonAsync<UserModel>(LinkRegisterUser(), user))
            {
                if (response.IsSuccessStatusCode)
                {
                    var userJson = await response.Content.ReadAsStringAsync();
                    int? valid = JsonConvert.DeserializeObject<int>(userJson);
                    if (valid == null)
                        return false;
                    return  valid == 1;
                }
                throw new Exception("Unexpected error in UserProcessor");
            }
        }
    }
}
