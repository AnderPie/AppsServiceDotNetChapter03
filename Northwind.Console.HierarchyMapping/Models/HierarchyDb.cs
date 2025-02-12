using Microsoft.EntityFrameworkCore; // To use DbSet<T>.
namespace Northwind.Models;

public class HierarchyDb : DbContext
{
    public DbSet<Person>? People {get; set;}
    public DbSet<Student>? Students {get; set;}
    public DbSet<Employee>? Employees {get; set;}

    public HierarchyDb(DbContextOptions<HierarchyDb> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            //.UseTphMappingStrategy(); // Default, I think is quite intuitive 
            //.UseTpcMappingStrategy(); // eh its ok
            .UseTptMappingStrategy() // I like a little more than Tpc and a little less than Tph.
            .Property(person => person.Id)
            .HasDefaultValueSql("NEXT VALUE FOR [PersonIds]"); /* This way adding a student, person, or 
        * employee will find the next open ID value amongst Person or any class that inherits from it, preventing
        * awkward ID duplication.*/

        modelBuilder.HasSequence<int>("PersonIds", builder => { builder.StartsAt(4); });
        // I haven't used this stuff much at all though so I'm sure my feelings will change over time.
        
        // Populate database with sample data

        Student p1 = new() { Id = 1, Name = "Greek Gary", Subject = "History"};

        Employee p2 = new() {Id = 2, Name = "Worker Gary", HireDate = new(2014,4,2)};

        // Are we sure we were right to hire this guy, he seems a little sus?
        Employee p3 = new() {Id = 3, Name = "Slobodan Milosevich", HireDate = new(2020,9,12) }; 

        modelBuilder.Entity<Student>().HasData(p1);
        modelBuilder.Entity<Employee>().HasData(p2,p3);

    }
}