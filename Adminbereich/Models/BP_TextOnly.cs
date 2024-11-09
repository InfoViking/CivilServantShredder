using Adminbereich.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminbereich.Models
{
    public class BP_TextOnly : BlogPost
    {
        public BP_TextOnly(string headLine, string text, DateTime? creationTime = null) : base(headLine, creationTime)
        {
            _text = text;
        }
        private string _text;
        public string Text { get { return _text; } }
    }
}
