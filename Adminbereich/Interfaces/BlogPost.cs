using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Adminbereich.Interfaces
{
    public class BlogPost
    {
        public BlogPost(string headLine, DateTime? creationTime = null)
        {
            Id = Guid.NewGuid();

            if (creationTime == null)
                CreationTime = DateTime.Now;
            else
                CreationTime = creationTime.Value;

            HeadLine = headLine;
        }

        Guid Id { get; }
        string HeadLine { get; set; }
        DateTime CreationTime { get; set; }
    }
}
