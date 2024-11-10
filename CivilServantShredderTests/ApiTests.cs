using Adminbereich;
using Adminbereich.Models;

namespace CivilServantShredderTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TextOnlyTests()
    {
        CancellationTokenSource cts = new(TimeSpan.FromSeconds(30));
        var api = new Api();
        var textOnlyPost = new BP_TextOnly()
        {
            Id = Guid.NewGuid(),
            CreationTime = DateTime.Now,
            HeadLine = "Hello world",
            Text = "Foo Bar",
        };
        api.PostAsync(textOnlyPost, cts.Token).Wait(cts.Token);

        var textOnlyPosts = api.GetAsync<BP_TextOnly>(cts.Token).Result.ToList();
        Assert.That(textOnlyPosts, Is.Not.Null);
        Assert.That(textOnlyPosts, Is.Not.Empty);
        Assert.That(textOnlyPosts.Any(p => p.Equals(textOnlyPost)), Is.True);

        var textOnlyPostCopy = api.GetAsync<BP_TextOnly>(textOnlyPost.Id, cts.Token).Result;
        Assert.That(textOnlyPostCopy, Is.EqualTo(textOnlyPost));

        textOnlyPost.Text = "Baz";
        api.PutAsync(textOnlyPost, cts.Token).Wait(cts.Token);

        textOnlyPostCopy = api.GetAsync<BP_TextOnly>(textOnlyPost.Id, cts.Token).Result;
        Assert.That(textOnlyPostCopy, Is.EqualTo(textOnlyPost));

        api.DeleteAsync<BP_TextOnly>(textOnlyPost.Id, cts.Token).Wait(cts.Token);
        textOnlyPosts = api.GetAsync<BP_TextOnly>(cts.Token).Result.ToList();
        Assert.That(textOnlyPosts.Any(p => p.Equals(textOnlyPost)), Is.False);
    }

    [Test]
    public void TextAndPictureTests()
    {
        CancellationTokenSource cts = new(TimeSpan.FromSeconds(30));
        var api = new Api();
        var textAndPicturePost = new BP_TextAndPicture()
        {
            Id = Guid.NewGuid(),
            CreationTime = DateTime.Now,
            HeadLine = "Hello world",
            Text = "Foo Bar",
            PictureBase64 = "base64code",
        };
        api.PostAsync(textAndPicturePost, cts.Token).Wait(cts.Token);

        var textAndPicturePosts = api.GetAsync<BP_TextAndPicture>(cts.Token).Result.ToList();
        Assert.That(textAndPicturePosts, Is.Not.Null);
        Assert.That(textAndPicturePosts, Is.Not.Empty);
        Assert.That(textAndPicturePosts.Any(p => p.Equals(textAndPicturePost)), Is.True);

        var textOnlyPostCopy = api.GetAsync<BP_TextAndPicture>(textAndPicturePost.Id, cts.Token).Result;
        Assert.That(textOnlyPostCopy, Is.EqualTo(textAndPicturePost));

        textAndPicturePost.Text = "Baz";
        api.PutAsync(textAndPicturePost, cts.Token).Wait(cts.Token);

        textOnlyPostCopy = api.GetAsync<BP_TextAndPicture>(textAndPicturePost.Id, cts.Token).Result;
        Assert.That(textOnlyPostCopy, Is.EqualTo(textAndPicturePost));

        api.DeleteAsync<BP_TextAndPicture>(textAndPicturePost.Id, cts.Token).Wait(cts.Token);
        textAndPicturePosts = api.GetAsync<BP_TextAndPicture>(cts.Token).Result.ToList();
        Assert.That(textAndPicturePosts.Any(p => p.Equals(textAndPicturePost)), Is.False);
    }

    [Test]
    public void PollTests()
    {
        CancellationTokenSource cts = new(TimeSpan.FromSeconds(30));
        var api = new Api();
        var pollPost = new BP_Poll()
        {
            Id = Guid.NewGuid(),
            CreationTime = DateTime.Now,
            HeadLine = "Hello world",
            Text = "Foo Bar",
            PollSelections =
            [
                new("Option 1"),
                new("Option 2"),
                new("Option 3"),
            ]
        };
        api.PostAsync(pollPost, cts.Token).Wait(cts.Token);

        var pollPosts = api.GetAsync<BP_Poll>(cts.Token).Result.ToList();
        Assert.That(pollPosts, Is.Not.Null);
        Assert.That(pollPosts, Is.Not.Empty);
        Assert.That(pollPosts.Any(p => p.Equals(pollPost)), Is.True);

        var textOnlyPostCopy = api.GetAsync<BP_Poll>(pollPost.Id, cts.Token).Result;
        Assert.That(textOnlyPostCopy, Is.EqualTo(pollPost));

        pollPost.HeadLine = "Baz";
        api.PutAsync(pollPost, cts.Token).Wait(cts.Token);

        textOnlyPostCopy = api.GetAsync<BP_Poll>(pollPost.Id, cts.Token).Result;
        Assert.That(textOnlyPostCopy, Is.EqualTo(pollPost));

        api.DeleteAsync<BP_TextAndPicture>(pollPost.Id, cts.Token).Wait(cts.Token);
        pollPosts = api.GetAsync<BP_Poll>(cts.Token).Result.ToList();
        Assert.That(pollPosts.Any(p => p.Equals(pollPost)), Is.False);
    }

    [Test]
    public void GetByCommunityTest()
    {
        CancellationTokenSource cts = new(TimeSpan.FromSeconds(30));
        var api = new Api();
        var a = api.GetByCommunityAsync<BP_TextOnly>(Guid.Parse("761b8d06-b8dc-4ff4-9779-912792531219"), cts.Token)
            .Result.ToArray();
        Assert.That(a, Is.Not.Null);
        Assert.That(a, Is.Not.Empty);
    }
}