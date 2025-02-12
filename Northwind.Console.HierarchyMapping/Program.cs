using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder
using Microsoft.Extensions.Options; 
using Microsoft.EntityFrameworkCore; // GenerateCreateScript();
using Northwind.Models; // HierarchyDb, Person, Student, Employee

DbContextOptionsBuilder<HierarchyDb> options = new();

SqlConnectionStringBuilder builder = new();

builder.DataSource = "."; // ServerName\InstanceName
builder.InitialCatalog = "HierarchyMapping";
builder.TrustServerCertificate = true;
builder.MultipleActiveResultSets = true;

// Because we want to fail faster, 3 seconds is shorter than 15 (default)
builder.ConnectTimeout = 3;

// Because we're using windows integrated authentication
builder.IntegratedSecurity = true;

options.UseSqlServer(builder.ConnectionString);

using(HierarchyDb db = new(options.Options)){
    bool deleted = await db.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await db.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");

    WriteLine("SQL script used to create the database:");
    WriteLine(db.Database.GenerateCreateScript());

    if(db.Students is null || !db.Students.Any()){
        WriteLine("There are no students!");
    }
    else{
        foreach(Student student in db.Students){
            WriteLine($"{student.Name} studies {student.Subject}");
        }
    }

    if(db.Employees is null || !db.Employees.Any()){
        WriteLine("There are no employees!");
    }
    else{
        foreach(Employee employee in db.Employees){
            WriteLine($"{employee.Name} was hired on {employee.HireDate}");
        }
    }

    if(db.People is null || !db.People.Any()){
        WriteLine("There are no people");
    }
    else{
        foreach (Person person in db.People){
            WriteLine($"{person.Name} has ID of {person.Id}");
        }
    }
}