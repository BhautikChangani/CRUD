using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class RadioGroupController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            var itemsList = new List<IInputGroupItem>()
            {
                new InputGroupItemModel()
                {
                    Label = "Green",
                    Enabled = true,
                    CssClass = "green",
                    Encoded = false,
                    Value = "one",
                    HtmlAttributes = new Dictionary<string,object>() { { "data-custom", "custom" } }
                },
                 new InputGroupItemModel()
                {
                    Label = "Blue",
                    Enabled = true,
                    Encoded = false,
                    CssClass = "blue",
                    Value = "two"
                },
                  new InputGroupItemModel()
                {
                    Label = "Red",
                    Enabled = true,
                    Encoded = false,
                    CssClass = "red",
                    Value = "three",
                    HtmlAttributes = new Dictionary<string,object>() { { "data-custom", "custom" } }
                }
            };

            return View(new RadioGroupViewModel() { Items = itemsList, RadioGroupValue = "one" });
        }
    }
}
