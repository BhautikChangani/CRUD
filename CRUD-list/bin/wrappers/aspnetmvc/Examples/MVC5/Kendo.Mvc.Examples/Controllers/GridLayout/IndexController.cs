using Kendo.Mvc.Examples.Models.GridLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridLayoutController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            var viewModel = new GridLayoutData()
            {
                SelectedDate = DateTime.Today,
                Articles = GetArticles(DateTime.Today),
                RecommendedArticles = GetRecommendedArticles(DateTime.Today),
                Tags = new List<string>() { "Art", "Books", "Film", "Gaming", "Music", "Photography", "Podcasts", "TV", "Visual Design" }
            };

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetData(DateTime selectedDate)
        {
            return Json(new { Articles = GetArticles(selectedDate), RecommendedArticles = GetRecommendedArticles(selectedDate) }, JsonRequestBehavior.AllowGet);
        }

        private List<GridLayoutArticle> GetArticles(DateTime selectedDate)
        {
            var rnd = new Random();

            var articles = new List<GridLayoutArticle>()
            {
                new GridLayoutArticle()
                {
                    Author = "Camille Fournier",
                    Title = "An incomplete list of skills senior engineers need",
                    MinsLength = 4,
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Mathew MacDonald",
                    Title = "A Closer Look at 5 New Features in C# 10",
                    MinsLength = 6,
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Camille Fournier",
                    Title = "20 Necessary Requirements of a Perfect Laptop",
                    MinsLength = 4,
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Anton Subbotin",
                    Title = "Top 3 Coding Teachers",
                    MinsLength = 5,
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Umair Haque",
                    Title = "Welcome to a New Dark Age",
                    MinsLength = 9,
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Jean Campbell",
                    Title = "An Open Letter to Millennials",
                    MinsLength = 7,
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
            }.OrderBy(a => a.Date).ToList();

            return articles;
        }

        private List<GridLayoutArticle> GetRecommendedArticles(DateTime selectedDate)
        {
            var rnd = new Random();

            var recommendedArticles = new List<GridLayoutArticle>()
            {
                new GridLayoutArticle()
                {
                    Author = "Andreas Maier",
                    Title = "Pattern Recognition and the Fundamental Methods of Machine Learning",
                    SubTitle = "A Comprehensive Overview of Classical ML Methods",
                    MinsLength = 7,
                    ImageUrl = Url.Content("~/Content/web/gridlayout/image1.jpg"),
                    ImageRight = "Photo by Nathan Van Egmond on Unsplash",
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Whet Moser",
                    Title = "Our Climate Change Future Looks Like the Everglades",
                    SubTitle = "We are all Florida man.",
                    MinsLength = 6,
                    ImageUrl = Url.Content("~/Content/web/gridlayout/image2.jpg"),
                    ImageRight="",
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                },
                new GridLayoutArticle()
                {
                    Author = "Ali Tamaseb",
                    Title = "What I Learned About Startups by Collecting 30,000 Data Points",
                    SubTitle = "I spend 4 years conducting one of the largest studies.",
                    MinsLength = 8,
                    ImageUrl = Url.Content("~/Content/web/gridlayout/image3.jpg"),
                    ImageRight = "Photo by Firmbee.com on Unsplash",
                    Date = new DateTime(selectedDate.Year, selectedDate.Month, rnd.Next(1, 28))
                }
            }.OrderBy(a => a.Date).ToList();

            return recommendedArticles;
        }
    }
}