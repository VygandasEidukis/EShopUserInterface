using ApiHelperLibrary.Processors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Models
{
    public class ImageModel
    {
        private string imageLink { get; set; } = "http://localhost:8080/Resources/Images/";
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductID { get; set; }

        public async Task<bool> FetchImage()
        {
            return true;
        }
    }
}
