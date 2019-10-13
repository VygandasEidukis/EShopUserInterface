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
        private string imageLink { get; set; } 
        public int Id { get; set; }
        private string _ImagePath;

        public string ImagePath
        {
            get { return "http://localhost:8080/Resources/Images/" + _ImagePath; }
            set { 
                _ImagePath = value; 
            }
        }
        public int ProductID { get; set; }
    }
}
