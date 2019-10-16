using ApiHelperLibrary.Models;
using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EShopUI.ViewModels
{
    public class CreateProductViewModel : Screen
    {
        #region props
        private ProductModel _Product;

        public ProductModel Product
        {
            get { return _Product; }
            set 
            { 
                _Product = value;
                NotifyOfPropertyChange(()=>Product);
            }
        }



        private string _ImageDisplayPath;

        public string ImageDisplayPath
        {
            get { return _ImageDisplayPath; }
            set 
            { 
                _ImageDisplayPath = value;
                NotifyOfPropertyChange(() => ImageDisplayPath);
            }
        }



        #endregion

        public CreateProductViewModel()
        {
            Product = new ProductModel();
        }

        #region Events
        public void BrowseButton()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImageDisplayPath = op.FileName;
            }
        }

        public void SubmitButton()
        {
            //submits product
        }

        #endregion
    }
}
