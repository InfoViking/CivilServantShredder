namespace Adminbereich.View.Views;

public partial class New_BlogPost_Selection : ContentPage
{
	public New_BlogPost_Selection()
	{
		InitializeComponent();
	}

    private async void Button_Clicked_TextOnly(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(New_BlogPost_TextOnly), true);
    }

    private async void Button_Clicked_TextAndPicture(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync(nameof(New_BlogPost_TextAndPicture), true);
    }

    private async void Button_Clicked_Poll(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(New_BlogPost_Poll), true);
    }

    private async void Button_Cancle_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}