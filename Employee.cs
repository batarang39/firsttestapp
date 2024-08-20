﻿using SQLite;

public class Employee
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Department { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
