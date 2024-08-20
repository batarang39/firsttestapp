namespace firsttestapp;
public partial class UpdateEmployee : ContentPage
{
    private Employee _selectedEmployee;
    private DatabaseService _databaseServiceSQL;

    public UpdateEmployee(Employee selectedEmployee, DatabaseService databaseService) //DatabaseService databaseService
                                                                                                                             // public UpdateEmployee() //DatabaseService databaseService
    {
        InitializeComponent();
        _selectedEmployee = selectedEmployee;

        _databaseServiceSQL = databaseService;

        FirstNameEntry.Text = _selectedEmployee.FirstName;
        SurnameEntry.Text = _selectedEmployee.Surname;
        PhoneEntry.Text = _selectedEmployee.Phone;
        DepartmentEntry.Text = _selectedEmployee.Department;
        StreetEntry.Text = _selectedEmployee.Street;
        CityEntry.Text = _selectedEmployee.City;
        StateEntry.Text = _selectedEmployee.State;
        ZipCodeEntry.Text = _selectedEmployee.ZipCode;
        CountryEntry.Text = _selectedEmployee.Country;
        EnrollmentDatePicker.Date = _selectedEmployee.EnrollmentDate;

    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        _selectedEmployee.FirstName = FirstNameEntry.Text;
        _selectedEmployee.Surname = SurnameEntry.Text;
        _selectedEmployee.Phone = PhoneEntry.Text;
        _selectedEmployee.Department = DepartmentEntry.Text;
        _selectedEmployee.Street = StreetEntry.Text;
        _selectedEmployee.City = CityEntry.Text;
        _selectedEmployee.State = StateEntry.Text;
        _selectedEmployee.ZipCode = ZipCodeEntry.Text;
        _selectedEmployee.Country = CountryEntry.Text;
        _selectedEmployee.EnrollmentDate = EnrollmentDatePicker.Date;

        await _databaseServiceSQL.UpdateEmployeeAsync(_selectedEmployee);

        await Navigation.PopAsync();

    }
}
