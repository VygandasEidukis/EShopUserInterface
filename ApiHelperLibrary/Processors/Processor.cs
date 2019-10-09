using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Processors
{
    public class Processor
    {
        public static string ApiPageLink { get; set; } = "https://localhost:44313/api/";
        public static string LinkGetUserById(int id)
        {
            return ApiPageLink + $"User/{id}";
        }

        public static string LinkGetUsers()
        {
            return ApiPageLink + $"User";
        }
    }
}
