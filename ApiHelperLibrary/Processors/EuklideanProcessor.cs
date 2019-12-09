using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;

namespace ApiHelperLibrary.Processors
{
    public  class EuklideanProcessor : Processor
    {
        public static async Task<List<ProductModel>> GetFeaturedProducts()
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkGetFeatured()))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ProductModel>>();
                }
                throw new Exception("Unexpected error in UserProcessor");
            }
        }
    }
}
