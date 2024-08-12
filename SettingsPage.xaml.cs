using firsttestapp.ViewModel;
using SQLite;
namespace firsttestapp;

public partial class SettingsPage : ContentPage
{
    public SQLiteAsyncConnection _database;
    public SettingsViewModel ViewModel { get; set; }

    public SettingsPage()
    {
        InitializeComponent();
       // loadPreferences();
       // ApplyTheme(App.Current.RequestedTheme);
       
        ViewModel = new SettingsViewModel();
        BindingContext = ViewModel;
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "settings.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<UserSet>().Wait();
        LoadUserSettings();

    }
    private async void SaveSettings_Clicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text; //This would be replaced by saving some login information OR pulling a user account etc.
        int age = 0; //Set age off an entry etc.
        int.TryParse(AgeEntry.Text, out age); // Calculated by the app or taken from account information
        bool theme = togTheme.IsToggled;
        string someEnt = someEntry.Text;

        var userSettings = new UserSet
        {
            Name = name,
            Age = age,
            lightOrDark = theme,
            SomeEntry = someEnt,
            SavedFontSize = ViewModel.FontSize,
            SavedBrightness = ViewModel.Brightness,
            SavedFontFamily = ViewModel.SelectedFontFamily,
        };
        await _database.InsertOrReplaceAsync(userSettings);

        // Show a confirmation message
        await DisplayAlert("Success", "User settings saved", "OK");

    }

    private async void LoadUserSettings()
    {
        // Check if the user settings already exist in the database
        var existingSettings = await _database.Table<UserSet>().FirstOrDefaultAsync();
        if (existingSettings != null)
        {
            NameEntry.Text = existingSettings.Name;
            AgeEntry.Text = existingSettings.Age.ToString();
            someEntry.Text = existingSettings.SomeEntry.ToString();

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

        // Apply the theme
        if (isDarkTheme)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }





    //public void SaveChanges(object sender, EventArgs e)
    //{
    //    DisplayAlert("Save Changes", "Save Changes", "OK");
    //}

  //  public void Brightness(object sender, ValueChangedEventArgs e)
  //  {
  ////      var stepper = (Stepper)sender;
  ////      BindingContext.Brightness = stepper.Value;
  //      DisplayAlert("Brightness", "Brightness", "OK");
  //  }

//    private void FontSize_ValueChanged(object sender, ValueChangedEventArgs e)
//    {
//        var stepper = (Stepper)sender;
//        BindingContext.FontSize = stepper.Value;
//    }
       
    //void onSliderValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    double value = e.NewValue;
    //    //rotationLabel.Rotation = value;
    //    //displayLabel.Text = String.Format("Rotation: {0}", value);
    //}
    //void onStepperValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    double value = e.NewValue;
    //    _rotationLabel.Rotation = value;
    //    _displayLabel.Text = String.Format("Rotation: {0}", value);
    //}

    //void setfont(object sender, EventArgs e)
    //{
    //   // var varsetfont = Preferences.Default.Set("fontfamily", "Times New Roman");
    //   // DisplayAlert("Apply", varsetfont, "OK");

    //}
    //void loadPreferences()
    //{
    //    //ThemePicker.SelectedIndex = Preferences.Get("Theme", 1);
    //    //IsLightTheme = Preferences.Get("Theme", 1) == 1 ? true : false;
    //}

    void SavePreferences(object sender, EventArgs e)
    {
        DisplayAlert("Settings", "Settings have been saved" , "OK");
        Preferences.Set("Theme", ThemePicker.SelectedIndex);
    }
    void ApplyPreferences(object sender, EventArgs e)
    {
        DisplayAlert("Settings", "Settings have been applied" , "OK");
        Preferences.Set("Theme", ThemePicker.SelectedIndex);
    }

}