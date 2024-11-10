using Adminbereich.Models;
using Adminbereich;
using System.Collections.ObjectModel;
using CivilServantShredder.Models;

namespace CivilServantShredder.ViewModel;

public class PollViewModel
{
    public ObservableCollection<Poll> Polls { get; } = new();
    public Command GetPollsAsyncCommand { get; set; }
    public Api Api { get; set; }

    public PollViewModel()
    {
        Api = new Api();
        GetPollsAsyncCommand = new Command(execute: async () => { await GetPollsAsync(); });
    }

    public async Task GetPollsAsync()
    {
        try
        {
            Polls.Clear();

            Guid communityCuid = Guid.Parse("761b8d06-b8dc-4ff4-9779-912792531219");

            var pollsApi = await Api.GetByCommunityAsync<BP_Poll>(communityCuid, new CancellationToken());

            foreach (var item in pollsApi.ToList())
            {
                Polls.Add(new Poll(item));
            }
            Polls.OrderBy(x => x.CreationTime);


        }
        catch (Exception ex)
        {

            Task.Run(async () => await Shell.Current.DisplayAlert("Error!", ex.Message, "OK")).Wait();
        }
    }
}
