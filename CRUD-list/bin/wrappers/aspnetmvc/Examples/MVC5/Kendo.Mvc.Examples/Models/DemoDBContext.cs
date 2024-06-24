using Kendo.Mvc.Examples.Models;
using System;
using System.Data.Entity;
using System.Data.SQLite;

namespace Kendo.Mvc.Examples
{
    public partial class DemoDBContext : DbContext
    {
        public DemoDBContext() :
            base(
                new SQLiteConnection()
                {
                    ConnectionString = new SQLiteConnectionStringBuilder()
                    {
                        DataSource = $"{AppDomain.CurrentDomain.GetData("DataDirectory").ToString()}\\demos.db",
                        ForeignKeys = true
                    }.ConnectionString
                },
                true)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Intraday> Intradays { get; set; }

        public DbSet<MeetingAttendee> MeetingAttendees { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Territory> Territories { get; set; }

        public DbSet<Weather> Weathers { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<GanttDependency> GanttDependencies { get; set; }

        public DbSet<GanttTask> GanttTasks { get; set; }

        public DbSet<UrbanArea> UrbanAreas { get; set; }

        public DbSet<EmployeeDirectory> EmployeeDirectory { get; set; }

        public DbSet<GanttResourceAssignment> GanttResourceAssignments { get; set; }

        public DbSet<GanttResource> GanttResources { get; set; }

        public DbSet<OrgChartConnection> OrgChartConnections { get; set; }

        public DbSet<OrgChartShape> OrgChartShapes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<DetailProduct> DetailProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}