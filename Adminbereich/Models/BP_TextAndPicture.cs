using Adminbereich.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminbereich.Models
{
    public class BP_TextAndPicture : IBlogPost
    {
        public Guid Id { get; set; }
        public string HeadLine { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
