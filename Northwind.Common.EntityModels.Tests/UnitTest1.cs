using Northwind.EntityModels; // To make use of the properties and methods we want to test
namespace Northwind.Common.EntityModels.Tests
{
    /*
     * As a refresher, tests have three parts
     * Arrange: Initialize variables for use by the test
     * Act: Do the thing that you're testing
     * Assert: Assert whether or not it worked as expected
     */
    public class NorthwindEntityModelsTests
    {
        [Fact]
        public void CanConnectIsTrue()
        {
            using (NorthwindContext db = new()) // arrange
            {
                bool canConnect = db.Database.CanConnect(); // act

                Assert.True(canConnect); // assert
            }
        }

        [Fact]
        public void ProviderIsSqlServer()
        {
            using (NorthwindContext db = new())
            {
                string? provider = db.Database.ProviderName;
                Assert.Equal("Microsoft.EntityFrameworkCore.SqlServer", provider);
            }
        }

        [Fact]
        public void ProductId1IsChai()
        {
            using(NorthwindContext db = new())
            {
                Product product1 = db.Products.Single(p => p.ProductId == 1); 
                Assert.Equal("Chai", product1.ProductName);
            }
        }

        [Fact]
        public void EmployeeHasLastRefreshedIn10sWindow()
        {
            using (NorthwindContext db = new())
            {
                Employee employee1 = db.Employees.Single(p=>p.EmployeeId == 1); 
                DateTimeOffset now = DateTimeOffset.UtcNow;
                Assert.InRange(actual: employee1.LastRefreshed, now.Subtract(TimeSpan.FromSeconds(5)), now.AddSeconds(5));
            }
        }
    }
}