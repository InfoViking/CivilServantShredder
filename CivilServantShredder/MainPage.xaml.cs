using Plugin.NFC;

namespace CivilServantShredder
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            CrossNFC.Current.StartListening();
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
    }

}
