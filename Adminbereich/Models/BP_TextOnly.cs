﻿using Adminbereich.Interfaces;


namespace Adminbereich.Models;

public record BP_TextOnly : IBlogPost
{
    public BP_TextOnly() { }
    public BP_TextOnly(string headLine, string text, DateTime? creationTime = null)
    {
        Text = text;
        Id = Guid.NewGuid();
        HeadLine = headLine;

        if (creationTime == null)
            CreationTime = DateTime.Now;
        else
            CreationTime = creationTime.Value;
    }

    public Guid Id { get; set; }
    public Guid CommunityId { get; set; }
    public string Text { get; set; } = default!;
    public string HeadLine { get; set; } = default!;
    public DateTime CreationTime { get; set; }
}
