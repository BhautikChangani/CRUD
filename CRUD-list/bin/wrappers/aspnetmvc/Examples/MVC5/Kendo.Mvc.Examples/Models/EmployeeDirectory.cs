using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Models
{
    public partial class EmployeeDirectory
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Nullable<int> ReportsTo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public Nullable<int> Extension { get; set; }

        public Nullable<System.DateTime> BirthDate { get; set; }

        public Nullable<System.DateTime> HireDate { get; set; }

        public string Position { get; set; }
    }
}