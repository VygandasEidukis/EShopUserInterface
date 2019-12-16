using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Processors
{
    public class Processor
    {
        public static string ApiPageLink { get; set; } = "http://localhost:8080/api/";
        public static string LinkGetUserById(int id)
        {
            return ApiPageLink + $"User/{id}";
        }

        public static string LinkGetUsers()
        {
            return ApiPageLink + @"User";
        }

        public static string LinkLogInUser()
        {
            return ApiPageLink + @"User/LogIn";
        }

        public static string LinkRegisterUser()
        {
            return ApiPageLink + @"User";
        }

        public static string LinkGetProductsOfUser(int id)
        {
            return ApiPageLink + $"Product/User/{id}";
        }

        public static string LinkGetProductImagesByProductID(int id)
        {
            return ApiPageLink + $"Image/{id}";
        }

        public static string LinkUpdateProduct(int productId)
        {
            return ApiPageLink + $"Product/Update/{productId}";
        }

        public static string LinkCreateNewProduct()
        {
            return ApiPageLink + "Product";
        }

        public static string LinkUploadImage(int productId)
        {
            return ApiPageLink + $"Image/{productId}";
        }

        public static string LinkUpdateImage(int imageId)
        {
            return ApiPageLink + $"Image/Update/{imageId}";
        }
        public static string LinkSearchByUsername(string username)
        {
            return ApiPageLink + $"search/username/{username}";
        }

        public static string LinkCartCreateCartForUser(int userId)
        {
            return ApiPageLink + $"Cart/Create/{userId}";
        }

        public static string LinkCartAddProduct(int userId, int productId)
        {
            return ApiPageLink + $"Cart/Add/{userId}/{productId}";
        }

        public static string LinkCartGetProducts(int userId)
        {
            return ApiPageLink + $"Cart/{userId}";
        }

        public static string LinkCartRemoveProduct(int productId, int userId)
        {
            return ApiPageLink + $"Cart/Remove/{userId}/{productId}";
        }

        public static string LinkCartPurchaseProducts(int userId)
        {
            return ApiPageLink + $"Cart/Purchase/{userId}";
        }

        public static string LinkGetPrductTypes()
        {
            return ApiPageLink + $"Product/Type";
        }

        public static string LinkSearchProductsByEuclidean()
        {
            return ApiPageLink + $"Product/Search/Euclidean/";
        }

        public static string LinkGetFeatured()
        {
            return ApiPageLink + $"Featured/";
        }
    }
}
