using ApiHelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Processors
{
    public class ImageProcessor : Processor
    {
        public static async Task<List<ImageModel>> GetImagesByProductId(int id = 1)
        {
            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(LinkGetProductImagesByProductID(id)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<ImageModel>>();
                }
                throw new Exception("Unexpected error in ImageProcessor");
            }
        }
    }
}
