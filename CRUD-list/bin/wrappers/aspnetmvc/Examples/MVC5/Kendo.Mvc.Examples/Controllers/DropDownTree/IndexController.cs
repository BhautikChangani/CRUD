namespace Kendo.Mvc.Examples.Controllers
{
    using Kendo.Mvc.UI;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class DropDownTreeController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            ViewBag.Countries = GetCountries();
            return View();
        }
        private static List<DropDownTreeItemModel> GetCountries()
        {
            return new List<DropDownTreeItemModel>()
            {
                new DropDownTreeItemModel() {
                    Id = "1",
                    Text = "Italy",
                    Expanded = true,
                    HasChildren = true,
                    Items = new List<DropDownTreeItemModel>()
                    {
                        new DropDownTreeItemModel() { Id = "2", Text = "Napoli" },
                        new DropDownTreeItemModel() { Id = "3", Text = "Rome" },
                        new DropDownTreeItemModel() { Id = "4", Text = "Venice" },
                    }
                },
                new DropDownTreeItemModel() {
                    Id = "5",
                    Text = "France",
                    Items = new List<DropDownTreeItemModel>()
                    {
                        new DropDownTreeItemModel() { Id = "6", Text = "Nice" },
                        new DropDownTreeItemModel() { Id = "7", Text = "Paris" },
                        new DropDownTreeItemModel() { Id = "8", Text = "Marseille" }
                    }
                },
                new DropDownTreeItemModel() {
                    Id = "9",
                    Text = "Portugal",
                    Items = new List<DropDownTreeItemModel>()
                    {
                        new DropDownTreeItemModel() { Id = "10", Text = "Porto" },
                        new DropDownTreeItemModel() { Id = "11", Text = "Lisbon" },
                        new DropDownTreeItemModel() { Id = "12", Text = "Braga" }
                    }
                },
                new DropDownTreeItemModel() {
                    Id = "13",
                    Text = "Brazil",
                    Items = new List<DropDownTreeItemModel>()
                    {
                        new DropDownTreeItemModel() { Id = "14", Text = "Rio De Janeiro" },
                        new DropDownTreeItemModel() { Id = "15", Text = "Sao Paulo" }
                    }
                },
                new DropDownTreeItemModel() {
                    Id = "16",
                    Text = "USA",
                    Items = new List<DropDownTreeItemModel>()
                    {
                        new DropDownTreeItemModel() { Id = "18", Text = "New York" },
                        new DropDownTreeItemModel() { Id = "19", Text = "Atlanta" },
                        new DropDownTreeItemModel() { Id = "20", Text = "Los Angeles" }
                    }
                }
            };
        }
    }
}