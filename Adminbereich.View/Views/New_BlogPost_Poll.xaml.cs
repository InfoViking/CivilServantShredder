using System.Collections.ObjectModel;
using Adminbereich.Models;

namespace Adminbereich.View.Views;

public partial class New_BlogPost_Poll : ContentPage
{
	public New_BlogPost_Poll()
	{
		InitializeComponent();
        Selections_ListView.ItemsSource = PollSelections;
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

    private async Task clearSelections()
    {
        bool shouldClear = await DisplayAlert("Clear?", "Do you want to clear all Selections?", "yes", "no");

        if (shouldClear) { PollSelections.Clear(); }
    }

    private async void createAndSendPostToApi()
    {
        try
        {
            List<PollSelection> allPollSelections = new List<PollSelection>();

            foreach (string selectionText in PollSelections)
            { allPollSelections.Add(new PollSelection(selectionText)); }

            BP_Poll pollPost = new BP_Poll(HeadLine_Entry.Text, Text_Entry.Text, allPollSelections);
            pollPost.CommunityId = Guid.Parse("761b8d06-b8dc-4ff4-9779-912792531219");

            Api api = new Api();

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await api.PostAsync(pollPost, cts.Token);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "ok"); ;
        }
        finally { await Navigation.PopAsync(); }
    }

    private async void Button_Cancle_Clicked(object sender, EventArgs e)
    {
        await close();
    }

    public ObservableCollection<string> PollSelections = new ObservableCollection<string>();

    private void Button_AddPollSelection_Clicked(object sender, EventArgs e)
    {
        PollSelections.Add(PollSelectionText_Entry.Text);
        PollSelectionText_Entry.Text = "";
    }

    private async void Button_Clear_All_Clicked(object sender, EventArgs e)
    { await clearSelections(); }
}