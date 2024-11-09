using System;
using System.Collections.Generic;
using System.Linq;
namespace Adminbereich.Interfaces;

public class BlogPost
{
    public BlogPost()
    {
                
    }
    public BlogPost(string headLine, DateTime? creationTime = null)
    {
        Id = Guid.NewGuid();

        if (creationTime == null)
            CreationTime = DateTime.Now;
        else
            CreationTime = creationTime.Value;

        HeadLine = headLine;
    }

    public Guid Id { get; set; }
    public string HeadLine { get; set; } = default!;
    public DateTime CreationTime { get; set; }
}
