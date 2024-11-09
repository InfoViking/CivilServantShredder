using Adminbereich.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminbereich.Models
{
    public class BP_Poll : IBlogPost
    {
        public BP_Poll()
        {
            
        }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string HeadLine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
