using Microsoft.EntityFrameworkCore; // To use QueryString
using Microsoft.Data.SqlClient; // To use SqlConnectonsStringBuilder
using Northwind.Models; // To use NorthwindDb and the rest

SqlConnectionStringBuilder builder = new();

builder.DataSource = ".";
builder.IntegratedSecurity = true;

DbContextOptionsBuilder<NorthwindDb> options = new();
options.UseSqlServer(builder.ConnectionString);

using (NorthwindDb db = new(options.Options)){
    Write("Enter a unit price:");
    string? priceText = ReadLine();

    if(!decimal.TryParse(priceText, out decimal price)){
        WriteLine("You must enter a valid unit price");
        return;
    }

// We have to use a var because we are projecting into an anonymous type
var products = db.Products
    .Where(p=>p.UnitPrice > price)
    .Select(p => new {p.ProductId, p.ProductName, p.UnitPrice});

#region Products table from query
WriteLine("-", 60);
WriteLine("| {0,5} | {1,-35} | {2,8} |", "Id", "Name", "Price");
WriteLine("-", 60);

foreach(var p in products){
    WriteLine("| {0,5} | {1,-35} | {2,8:C} |", p.ProductId, p.ProductName, p.UnitPrice);
}

#endregion




    WriteLine("-",60);
    WriteLine(products.ToQueryString());
    WriteLine();
    WriteLine($"Provider: {db.Database.ProviderName}");
    WriteLine($"Connection: {db.Database.GetConnectionString()}");
}