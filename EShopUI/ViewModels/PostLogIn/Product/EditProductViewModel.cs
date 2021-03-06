﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using Microsoft.Win32;
using static ApiHelperLibrary.Processors.ProductProcessor;

namespace EShopUI.ViewModels
{
    public class EditProductViewModel : Screen
    {
        private bool imageChanged = false;
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
        private BindableCollection<ProductType> _ProductTypes;
        public BindableCollection<ProductType> ProductTypes
        {
            get { return _ProductTypes; }
            set
            {
                _ProductTypes = value;
                NotifyOfPropertyChange(()=>ProductTypes);
            }
        }
        private ProductType _SelectedProductType;
        public ProductType SelectedProductType
        {
            get { return _SelectedProductType; }
            set
            {
                _SelectedProductType = value; 
                NotifyOfPropertyChange(()=>SelectedProductType);
                Product.CategoryID = SelectedProductType.Id;
            }
        }
        private ProductModel _Product;
        public ProductModel Product
        {
            get => _Product;
            set
            {
                _Product = value;
                NotifyOfPropertyChange(()=>Product);
            }
        }

        public EditProductViewModel(ProductModel product)
        {
            Product = product;
        }

        public async void ViewLoaded()
        {
            var productTypes = await GetProductTypes().ConfigureAwait(true);
            ProductTypes = new BindableCollection<ProductType>();
            if(productTypes != null)
                ProductTypes.AddRange(productTypes);
            foreach (var productType in ProductTypes)
            {
                if (productType.ToString() == Product.ProductType.ToString())
                    SelectedProductType = productType;
            }
        }

        public async Task UpdateButton()
        {
            if (VerifyFields())
            {
                Product.CategoryID = SelectedProductType.Id;

                if(imageChanged)
                {
                    await ImageProcessor.UpdateImage(Product.CurrentImage, Product.ProductImages[0].Id).ConfigureAwait(true);
                }
                await UpdateProduct(Product).ConfigureAwait(true);
                //(Parent as PostLogInViewModel).ButtonHome();
                this.TryClose();
            }
            
        }

        private bool VerifyFields()
        {
            if (Product.Name.Length < 3)
                return false;
            if (Product.Price == 0)
                return false;
            if (Product.Description.Length < 5)
                return false;
            return true;
        }

        public void BrowseButton()
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png"
            };
            if (op.ShowDialog() == true)
            {
                imageChanged = true;
                ImageDisplayPath = op.FileName;
            }
        }
    }
}
