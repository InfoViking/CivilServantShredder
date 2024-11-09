using Adminbereich.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminbereich.Models
{
    public class BP_Poll : BlogPost
    {
        public BP_Poll(string headLine, Poll poll, DateTime? creationTime = null) : base(headLine, creationTime)
        { _poll = poll; }

        private Poll _poll;
        private Poll Poll { get { return _poll; } }
    }
}
