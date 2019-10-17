using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHelperLibrary.Models
{
    public class SingleImageModel
    {
        public byte[] Image { get; set; }
        public string FileExtension { get; set; }
    }
}
