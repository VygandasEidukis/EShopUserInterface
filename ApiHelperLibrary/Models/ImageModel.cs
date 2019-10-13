using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductID { get; set; }
    }
}
