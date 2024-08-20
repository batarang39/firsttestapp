using System.Collections.ObjectModel;
using System.Globalization;
using CsvHelper;
using System.Diagnostics.Metrics;


namespace firsttestapp;

public partial class StaffList : ContentPage
{ 
    private DatabaseService _databaseServiceSQL;
    private List<Employee> _employee;

public StaffList()
	{
        InitializeComponent();
		//BindingContext = viewModel;
        //viewModel.ImportSomeRecords();

        _databaseServiceSQL = new DatabaseService();

        //Load Employee
        LoadEmployeeAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadEmployeeAsync();
    }

    private async void UpdateEmployee_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = (Employee)((Button)sender).BindingContext;
        await Navigation.PushAsync(new UpdateEmployee(selectedEmployee, _databaseServiceSQL));
    }

    private async void DeleteEmployee_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = (Employee)((Button)sender).BindingContext;
        bool result = await DisplayAlert("Delete Employee", "Are you sure you want to delete this Employee?", "Yes", "No");

        if (result)
        {
            await _databaseServiceSQL.DeleteEmployeeAsync(selectedEmployee);

            LoadEmployeeAsync();
        }
    }

    private async void ViewDetails_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = (Employee)((Button)sender).BindingContext;
        await Navigation.PushAsync(new EmployeeDetails(selectedEmployee));
    }
    public async void LoadEmployeeAsync()
    {
        try
        {
            _employee = await _databaseServiceSQL.GetEmployeeAsync();

            EmployeeListView.ItemsSource = _employee;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
        }
    }


    private async void AddEmployee_Clicked(object sender, EventArgs e)
    {
        var newEmployee = new Employee
        {
            FirstName = FirstNameEntry.Text,
            Surname = SurnameEntry.Text,
            Phone = PhoneEntry.Text,
            Department = DepartmentEntry.Text,
            Street = StreetEntry.Text,
            City = CityEntry.Text,
            State = StateEntry.Text,
            ZipCode = ZipCodeEntry.Text,
            Country = Country.Text,
            EnrollmentDate = EnrollmentDatePicker.Date

        };

        await _databaseServiceSQL.AddEmployeeAsync(newEmployee);

        //Un-comment for pop-ups/troubleshooting
        await DisplayAlert("Add Employee","You Added an Employee","Ok");


        FirstNameEntry.Text = SurnameEntry.Text = PhoneEntry.Text = DepartmentEntry.Text = StreetEntry.Text = CityEntry.Text = StateEntry.Text = ZipCodeEntry.Text = Country.Text = string.Empty;

        LoadEmployeeAsync();
    }

}

    
