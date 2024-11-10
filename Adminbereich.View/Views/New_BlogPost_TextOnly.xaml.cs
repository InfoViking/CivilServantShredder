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
        await DisplayAlert("Chill mo!", "Do gehts noch net weida", "ok");
        await close();
    }

    private async void Button_Cancle_Clicked(object sender, EventArgs e)
    {
        await close();
    }
}