using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml;

namespace Kendo.Mvc.Examples.Controllers
{
    public class HomeController : Controller
    {
        [Home]
        public ActionResult Index()
        {
            ViewBag.SearchAction = Url.Action("HubSearch", "Home");
            return View();
        }
      
        [Home]
        public ActionResult Search()
        {
            ViewBag.GoogleApiKey = "AIzaSyAoMzKVlaLGxBlzHnHXYUekeDC1Sg0UMzY";
            ViewBag.GoogleCustomSearchInstance = "017812832676623302965:bhwhramaeos";

            return View();
        }

        [Home]
        public ActionResult HubSearch()
        {
            ViewBag.SearchAction = Url.Action("HubSearch", "Home");
            ViewBag.GoogleApiKey = "AIzaSyAoMzKVlaLGxBlzHnHXYUekeDC1Sg0UMzY";
            ViewBag.GoogleCustomSearchInstance = "017812832676623302965:bhwhramaeos";

            return View();
        }

        [Home]
        public void SitemapXml()
        {
            XmlDocument doc = SitemapGenerator.Generate(
             (IEnumerable<NavigationWidget>)ViewBag.Navigation);
            Response.ContentType = "application/xml";
            Response.Write(doc.OuterXml);
        }

        public JsonResult GetProducts(string text)
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

            if (!string.IsNullOrEmpty(text))
            {
                products = products.Where(p => p.ProductName.Contains(text));
            }

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomers()
        {
            var customers = new DemoDBContext().Customers.Select(customer => new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Bool = customer.Bool
            });

            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}
