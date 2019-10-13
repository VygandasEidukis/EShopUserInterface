﻿using System;
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
        public string CurrentImage { get; set; }

        private List<ImageModel> _ProductImages;
        public List<ImageModel> ProductImages
        {
            get { return _ProductImages; }
            set { _ProductImages = value;
                CurrentImage = _ProductImages[0].ImagePath;
            }
        }

    }
}
