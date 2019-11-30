using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using Newtonsoft.Json;

namespace ApiHelperLibrary.Processors
{
    public class CartProcessor : Processor
    {
        public static async void AddProductToCart(ProductModel product, UserModel user)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkCartAddProduct(user.Id, product.Id)))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to add product to cart");
                }
            }
        }

        public static async Task<List<ProductModel>> GetCartProducts(int userId)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkCartGetProducts(userId)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ProductModel>>();
                }
                throw new Exception("Unexpected error in UserProcessor");
            }
        }

        public static async void RemoveProductFromCart(ProductModel product, int userId)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkCartRemoveProduct(product.Id, userId)))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to remove product from your cart");
                }
            }
        }

        public async void ProcessCartContent(int CartID)
        {

        }
    }
}
