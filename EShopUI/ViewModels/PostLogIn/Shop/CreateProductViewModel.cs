using ApiHelperLibrary.Models;
using ApiHelperLibrary.Processors;
using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ProductType = ApiHelperLibrary.Models.ProductType;

namespace EShopUI.ViewModels
{
    public class CreateProductViewModel : Screen
    {
        #region props
        public delegate void LoadView(object view);
        public LoadView LoadNewView { get; set; }

        private BindableCollection<ProductType> SelectionProductTypes_;

        public BindableCollection<ProductType> SelectionProductTypes
        {
            get { return SelectionProductTypes_; }
            set
            {
                SelectionProductTypes_ = value;
                NotifyOfPropertyChange(()=>SelectionProductTypes);
            }
        }

        private ProductType SelectedProductTypes_;

        public ProductType SelectedProductTypes
        {
            get { return SelectedProductTypes_; }
            set { SelectedProductTypes_ = value; NotifyOfPropertyChange(()=>SelectedProductTypes); }
        }



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

        public async void ViewLoaded()
        {
            Product.UserID = (Parent as PostLogInViewModel).User.Id;
            var productTypes = await ProductProcessor.GetProductTypes();
            SelectionProductTypes = new BindableCollection<ProductType>();
            foreach (ProductType productType in productTypes)
            {
                SelectionProductTypes.Add(productType);
            }

            if (SelectionProductTypes.Count > 0)
                SelectedProductTypes = SelectionProductTypes[0];
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

        public async void SubmitButton()
        {
            if(VerifyFields())
            {
                //save Product info
                Product.CategoryID = SelectedProductTypes.Id;
                int ProductID = await ProductProcessor.CreateProduct(Product).ConfigureAwait(false);
                //save Product Images
                await ImageProcessor.SaveImage(ImageDisplayPath, ProductID).ConfigureAwait(false);
                (Parent as PostLogInViewModel).ActiveItem = new UserViewModel((Parent as PostLogInViewModel).User);
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

        #endregion
    }
}
