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

        public static string LinkCreateNewProduct()
        {
            return ApiPageLink + "Product";
        }

        public static string LinkUploadImage(int ProductID)
        {
            return ApiPageLink + $"Image/{ProductID}";
        }
    }
}
