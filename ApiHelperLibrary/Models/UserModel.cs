using System.Collections.Generic;
using System.IO;

namespace ApiHelperLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        private string _IconPath;

        public string IconPath
        {
            get 
            {
                if(_IconPath == null)
                {
                    var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string filePath = Path.Combine(projectPath, "Resources")+ "\\Images\\DefaultUser.png";
                    return filePath;
                }
                else
                {
                    return _IconPath;
                }
            }
            set { _IconPath = value; }
        }
        public List<ProductModel> Products { get; set; }
    }
}
