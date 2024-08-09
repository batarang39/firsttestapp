namespace firsttestapp;

public partial class StaffList : ContentPage
{
	public StaffList()
	{
         InitializeComponent();
	}
	public void ViewStaffClicked(object sender, EventArgs e)
    {
        DisplayAlert("View Staff", "View Staff", "OK");
    }
}