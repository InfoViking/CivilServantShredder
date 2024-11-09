using Adminbereich.View.Views;

namespace CivilServantShredder;

public partial class Feed : ContentPage
{
	public Feed()
	{
		InitializeComponent();
	}

    private async void Create_Post_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(New_BlogPost_Selection), true);
    }
}