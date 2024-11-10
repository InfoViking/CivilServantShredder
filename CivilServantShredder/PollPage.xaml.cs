using CivilServantShredder.ViewModel;

namespace CivilServantShredder;

public partial class PollPage : ContentPage
{
    PollViewModel ViewModel;
    public PollPage(PollViewModel viewModel)
	{
		InitializeComponent();
        this.ViewModel = viewModel;
        BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.GetPollsAsyncCommand.Execute(this);
    }
}