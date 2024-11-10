using Adminbereich;
using Adminbereich.Models;
using CivilServantShredder.Models;
using System.Collections.ObjectModel;

namespace CivilServantShredder.ViewModel;

public class FeedViewModel
{
    public ObservableCollection<BP_TextOnlyModel> BP_TextOnlys { get; } = new();
    public Command GetBP_TextOnlyAsyncCommand { get; set; }
    public Api Api { get; set; }

    public FeedViewModel()
    {
        Api = new Api();
        GetBP_TextOnlyAsyncCommand = new Command(execute: async () => { await GetBP_TextOnlyAsync(); });
    }

    public async Task GetBP_TextOnlyAsync()
    {
        try
        {
            BP_TextOnlys.Clear();

            Guid communityCuid = Guid.Parse("761b8d06-b8dc-4ff4-9779-912792531219");

            var bP_TextOnlys = await Api.GetByCommunityAsync<BP_TextOnly>(communityCuid, new CancellationToken());

            foreach(var item in bP_TextOnlys.ToList())
            {
                BP_TextOnlys.Add(new BP_TextOnlyModel(item));
            }
            BP_TextOnlys.OrderBy(x => x.CreationTime);


        }
        catch (Exception ex)
        {

            Task.Run(async () => await Shell.Current.DisplayAlert("Error!", ex.Message, "OK")).Wait();
        }
    }
}
