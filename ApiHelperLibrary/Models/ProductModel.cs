using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UserID { get; set; }
        public string CurrentImage { get; set; } = "http://localhost:8080/Resources/Images/cbaORgcKYwBfFFOLsHALErYbi.png";
        public List<ImageModel> ProductImages { get; set; }
    }
}
