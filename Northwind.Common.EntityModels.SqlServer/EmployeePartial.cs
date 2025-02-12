using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; // For use of the [NotMapped] annotation
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EntityModels
{ 
    public partial class Employee : IHasLastRefreshed
    {
        [NotMapped] // So that we don't try to add our caching tool property to the SQL Server table
        public DateTimeOffset LastRefreshed { get; set; }
    }
}