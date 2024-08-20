//using firsttestapp.ViewModel;
using SQLite;
namespace firsttestapp;

public partial class SettingsPage : ContentPage
{
    public SQLiteAsyncConnection _database;
    public SettingsViewModel ViewModel { get; set; }

    public SettingsPage()
    {
        InitializeComponent();
        ViewModel = new SettingsViewModel();
        BindingContext = ViewModel;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "settings.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<UserSet>().Wait();

        LoadUserSettings();

    }
    private async void SaveSettings_Clicked(object sender, EventArgs e)
    {
        //var name = NameEntry.Text; 
        //  int age = 0; 
        //  int.TryParse(AgeEntry.Text, out age);
        //  bool theme = togTheme.IsToggled;
        // string someEnt = someEntry.Text;
        int fontSize = (int)fontSizeSlider.Value;
        float brightness = (float)brightnessSlider.Value;
        string selectedFont = fontFamilyPicker.SelectedItem.ToString();

        var userSettings = new UserSet
        {
            //  Name = name,
            //   Age = age,
            //  lightOrDark = theme,
            // SomeEntry = someEnt,
            SavedFontSize = ViewModel.FontSize,
            SavedBrightness = ViewModel.Brightness,
            SavedFontFamily = ViewModel.SelectedFontFamily,
        };
        await _database.InsertOrReplaceAsync(userSettings);

        await DisplayAlert("Success", "User settings saved", "OK");

    }

    private async void LoadUserSettings()
    {
        var existingSettings = await _database.Table<UserSet>().FirstOrDefaultAsync();
        if (existingSettings != null)
        {
            // NameEntry.Text = existingSettings.Name;
            //AgeEntry.Text = existingSettings.Age.ToString();
            //someEntry.Text = existingSettings.SomeEntry.ToString();

            fontSizeSlider.Value = (double)existingSettings.SavedFontSize;
            brightnessSlider.Value = (double)existingSettings.SavedBrightness;
            fontFamilyPicker.SelectedItem = existingSettings.SavedFontFamily;


            if (existingSettings.lightOrDark)
            {
                togTheme.IsToggled = true;
            }
            else
            {
                togTheme.IsToggled = false;
            }

            var currentTheme = existingSettings.lightOrDark;
            if (currentTheme)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;
        }
    }

    private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
    {

        bool isDarkTheme = e.Value;
        Preferences.Set("DarkThemeOn", isDarkTheme ? "Dark" : "Light");
        if (isDarkTheme)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}
