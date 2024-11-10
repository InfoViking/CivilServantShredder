using CivilServantShredder.ViewModel;
using Microsoft.Extensions.Logging;

namespace CivilServantShredder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddSingleton<FeedViewModel>();
            builder.Services.AddSingleton<Feed>();

            builder.Services.AddSingleton<PollViewModel>();
            builder.Services.AddSingleton<PollPage>();
#endif

            return builder.Build();
        }
    }
}
