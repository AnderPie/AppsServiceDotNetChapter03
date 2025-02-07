using System.ComponentModel.DataAnnotations; // To use [Required]

namespace Northwind.Models;

public class Student : Person
{
    public string? Subject {get; set;}
}