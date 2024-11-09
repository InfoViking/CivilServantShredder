using System;
using System.Collections.Generic;
using System.Linq;


namespace Adminbereich.Models
{
    public class PollSelection
    {
        public PollSelection(string selectionText, bool selected = false)
        {
            SelectionText = selectionText;
            Selected = selected;
        }
        public string SelectionText { get; set; }
        public bool Selected { get; set; }
    }
}
