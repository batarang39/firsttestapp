
using Microsoft.Maui.Controls;
//using Microsoft.Maui.Essentials;

namespace firsttestapp
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

            //private void OnCounterClicked(object sender, EventArgs e)
            //{

            //}
            private void ViewStaffClicked(object sender, EventArgs e)
            {
                DisplayAlert("View Staff", "View Staff", "OK");

            }
            private void ViewHRToolsClicked(object sender, EventArgs e)
            {
                DisplayAlert("View HR Tools", "View HR Tools", "OK");
            }

            private void ONSettingsClicked(object sender, EventArgs e)
            {
                // Navigate to the Settings page
                //Navigation.PushAsync(new Settings());
                DisplayAlert("Settings", "Settings", "OK");
            }
            private void LoginOutClicked(object sender, EventArgs e) { }
        }
} 

