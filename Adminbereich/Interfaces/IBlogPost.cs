using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminbereich.Interfaces
{
    public interface IBlogPost
    {
        Guid Id { get; set; }
        string HeadLine { get; set; }
        DateTime CreationTime { get; set; }
    }
}
