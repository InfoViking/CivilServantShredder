
namespace CivilServantShredder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Feed), typeof(Feed));
        }
    }
}
