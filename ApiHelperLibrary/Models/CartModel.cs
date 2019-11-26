using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Models
{
    public class CartModel
    {
        public List<ProductModel> Products { get; set; }

        public CartModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
