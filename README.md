The following is work undertaken to learn C# through use of Mark Price's C#12 and .NET 8 Modern Cross-Platform Development Fundamentals.  
# Exercise 3.1 - Test your knowledge

## What can the dotnet-ef tool be used for?
Scaffolding your C# project so that the .NET classes can be generated from the tables in your database automagically.
## What type would you use for the property that represents a table, for eample, the Products property of a data context?
You would use a DBSet<YourClass> type. In the above example, DBSet<Products>
## What type would you use for the property that represents a one-to-many relationship, for example, the Products property of a Category unit?
You would use an ICollection<YourClass> type, in the above example, ICollection<Products>
## What is the EF Core convention for primary keys?
You can mark them with the [Key] annotation for clarity. They also usually have the term 'Id' after their name.
For example ProductId.
## Why might you choose the Fluent API in preference to annotation attributes
Some people find the Fluent API easier to read. I personally prefer the annotation attributes, but to each their own.
## Why might you implement the IMaterializationInterceptor interface in an entity type
This interface is handy for setting the LastRefreshed property of an entity implementing the interface when an entity is on
the refresh of that entity. This is in turn handy for determining if the EFCore object you are working with really represents
the latest version of the object in the database. For example, if a customer has been changed in EFCore, but also changed
elsewhere, you can look at the database and see if changes occurred to the object after the object was loaded into EFCore,
and reconcile those changes if necessary. 


