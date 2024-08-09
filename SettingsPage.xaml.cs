namespace firsttestapp;

public partial class SettingsPage : ContentPage
{

    public SettingsPage()
    {
        InitializeComponent();
        loadPreferences();
       // ApplyTheme(App.Current.RequestedTheme);
    }


    public void onThemeSwitchToggled(object sender, ToggledEventArgs e)
    {

        bool isDarkTheme = e.Value;
        Preferences.Set("DarkThemeOn", isDarkTheme ? "Dark" : "Light");

        // Apply the theme
        if (isDarkTheme)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
    
    
    
    
    
    public void SaveChanges(object sender, EventArgs e)
    {
        DisplayAlert("Save Changes", "Save Changes", "OK");
    }

    public void Brightness(object sender, ValueChangedEventArgs e)
    {
  //      var stepper = (Stepper)sender;
  //      BindingContext.Brightness = stepper.Value;
        DisplayAlert("Brightness", "Brightness", "OK");
    }

//    private void FontSize_ValueChanged(object sender, ValueChangedEventArgs e)
//    {
//        var stepper = (Stepper)sender;
//        BindingContext.FontSize = stepper.Value;
//    }
       
    void onSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        rotationLabel.Rotation = value;
        displayLabel.Text = String.Format("Rotation: {0}", value);
    }
    void onStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        _rotationLabel.Rotation = value;
        _displayLabel.Text = String.Format("Rotation: {0}", value);
    }

    void setfont(object sender, EventArgs e)
    {
       // var varsetfont = Preferences.Default.Set("fontfamily", "Times New Roman");
       // DisplayAlert("Apply", varsetfont, "OK");

    }
    void loadPreferences()
    {
        //ThemePicker.SelectedIndex = Preferences.Get("Theme", 1);
        //IsLightTheme = Preferences.Get("Theme", 1) == 1 ? true : false;
    }

    void SavePreferences(object sender, EventArgs e)
    {
        DisplayAlert("Settings", "Settings have been saved" , "OK");
        Preferences.Set("Theme", ThemePicker.SelectedIndex);
    }
    void ApplyPreferences(object sender, EventArgs e)
    {
        DisplayAlert("Settings", "Settings have been applied" , "OK");
        Preferences.Set("Theme", ThemePicker.SelectedIndex);
        //DisplayAlert("Settings", (string)ThemePicker.SelectedIndex, "OK");
    }

}