using Adminbereich.Models;

namespace Adminbereich.View.Views;

public partial class New_BlogPost_TextOnly : ContentPage
{
	public New_BlogPost_TextOnly()
	{
		InitializeComponent();
	}



    private void Button_Post_Clicked(object sender, EventArgs e)
    {
        Post();
    }

    private async void Post()
    {
        bool shouldPost = await DisplayAlert("Post?", "Are you sure you want to Post now?", "yes", "no");

        if (shouldPost)
        {
            createAndSendPostToApi();
        }
        else
        {
            await close();
        }
    }

    private async Task close()
    {
        bool shouldDiscard = await DisplayAlert("Discard?", "Do you want to Discard your Post?", "yes", "no");

        if (shouldDiscard) { await Navigation.PopAsync(); }
    }

    private async void createAndSendPostToApi()
    {
        try
        {
            BP_TextOnly textOnlyPost = new BP_TextOnly(HeadLine_Entry.Text, Text_Entry.Text);
            textOnlyPost.CommunityId = Guid.Parse("761b8d06-b8dc-4ff4-9779-912792531219");

            Api api = new Api();

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await api.PostAsync(textOnlyPost, cts.Token);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "ok"); ;
        }
        finally { await Navigation.PopAsync(); }
    }

    private async void Button_Cancel_Clicked(object sender, EventArgs e)
    {
        await close();
    }
}