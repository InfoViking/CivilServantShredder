
using Adminbereich.View.Views;

namespace CivilServantShredder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Feed), typeof(Feed));
            Routing.RegisterRoute(nameof(New_BlogPost_Selection), typeof(New_BlogPost_Selection));
            Routing.RegisterRoute(nameof(New_BlogPost_TextOnly), typeof(New_BlogPost_TextOnly));
            
        }
    }
}
