using System.ComponentModel.DataAnnotations; // To use [Required]

namespace Northwind.Models;

public class Employee : Person
{
    public DateTime HireDate {get; set;}
}