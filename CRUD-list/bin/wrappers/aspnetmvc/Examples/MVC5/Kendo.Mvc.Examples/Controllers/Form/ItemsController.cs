using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Form;


namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : Controller
    {
        [Demo]
        public ActionResult Items()
        {
            return View(new FormItemsViewModels()
            {
                TextBox = "John Doe",
                TextArea = "Multiline\ninput",
                NumericTextBox = 2,
                MaskedTextBox = "21313",
                RadioGroup = "2",
                CheckBoxGroup = new string[] { "1", "2" },
                DatePicker = new DateTime(2020, 5, 7),
                DateTimePicker = new DateTime(2020, 5, 7, 9, 1, 0),
                Switch = false,
                ComboBox = "1",
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Items(FormOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Items";
                return View("Success");
            }
        }

        public JsonResult Items_GetProducts()
        {
            var northwind = new DemoDBContext();

            var products = northwind.Products.Select(product => new ProductViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0,
                UnitsInStock = product.UnitsInStock ?? 0,
                UnitsOnOrder = product.UnitsOnOrder ?? 0,
                Discontinued = product.Discontinued
            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}