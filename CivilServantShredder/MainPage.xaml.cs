using Plugin.NFC;

namespace CivilServantShredder
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            if (!CrossNFC.Current.IsAvailable) throw new Exception("NFC not available");
            if (!CrossNFC.Current.IsEnabled) throw new Exception("NFC not enabled");

            CrossNFC.Current.OnMessageReceived += CurrentOnOnMessageReceived;
            CrossNFC.Current.OnTagDiscovered += CurrentOnOnTagDiscovered;
            CrossNFC.Current.OnNfcStatusChanged += Current_OnNfcStatusChanged;
        }

        private void Current_OnNfcStatusChanged(bool isenabled)
        {
            throw new NotImplementedException();
        }

        private void CurrentOnOnTagDiscovered(ITagInfo taginfo, bool format)
        {
            throw new NotImplementedException();
        }

        private void CurrentOnOnMessageReceived(ITagInfo taginfo)
        {
            throw new NotImplementedException();
        }

        public void ChangePasswordVisibility()
        {
            if (EntryPassword.IsPassword == true)
            {
                EntryPassword.IsPassword = false;
            }
            else
            {
                EntryPassword.IsPassword = true;
            }
        }

        private void ShowPassword_Clicked(object sender, EventArgs e)
        {
            ChangePasswordVisibility();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Feed), true);
        }

        private void BtnNfc_OnClicked(object? sender, EventArgs e)
        {
            CrossNFC.Current.StartListening();
        }
    }

}
