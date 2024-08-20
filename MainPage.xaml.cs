


namespace firsttestapp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }
        private async void ViewStaffClicked(object sender, EventArgs e)
        {
              await Navigation.PushAsync(new StaffList());
        }
        private async void ViewHRToolsClicked(object sender, EventArgs e)
        {
              await Navigation.PushAsync(new HRToolsPage());
        }


        private async void ONSettingsClicked(object sender, EventArgs e)
        {
              await Navigation.PushAsync(new SettingsPage());
        }
        private void LogOutClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    
}

