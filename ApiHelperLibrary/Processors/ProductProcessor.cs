using ApiHelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Processors
{
    public class ProductProcessor : Processor
    {
        public static async Task<List<ProductModel>> GetProductsByUserID(int id = 1)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkGetProductsOfUser(id)))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ProductModel> products = await response.Content.ReadAsAsync<List<ProductModel>>();
                    return products;
                }
                throw new Exception("Unexpected error in ProductProcessor");
            }
        }

        public static async Task<int> CreateProduct(ProductModel product)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsJsonAsync<ProductModel>(LinkCreateNewProduct(), product))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<int>();
                }
                throw new Exception($"Unexpected error in ProductProcessor \nError code: \n {response.StatusCode}");
            }
        }
    }
}
