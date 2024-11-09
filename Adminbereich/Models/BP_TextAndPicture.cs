using Adminbereich.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Adminbereich.Models
{
    public class BP_TextAndPicture : BP_TextOnly
    {
        public BP_TextAndPicture(string headLine, string text, string pictureBase64,  DateTime? creationTime = null) : base(headLine, text, creationTime)
        {
            _pictureBase64 = pictureBase64;
        }

        private string _pictureBase64;
        public string PictureBase64 { get { return _pictureBase64; } }
    }
}
