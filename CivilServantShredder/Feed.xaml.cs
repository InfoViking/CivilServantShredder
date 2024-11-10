using Adminbereich.View.Views;
using CivilServantShredder.ViewModel;

namespace CivilServantShredder;

public partial class Feed : ContentPage
{
    FeedViewModel ViewModel;
    public Feed(FeedViewModel viewModel)
	{
		InitializeComponent();
        this.ViewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.GetBP_TextOnlyAsyncCommand.Execute(this);
    }

    private async void Create_Post_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(New_BlogPost_Selection), true);
    }
}