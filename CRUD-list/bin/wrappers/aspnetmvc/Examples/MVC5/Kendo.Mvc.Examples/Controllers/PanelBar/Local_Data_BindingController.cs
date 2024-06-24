using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Examples.Models;
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PanelBarController : Controller
    {
        [Demo]
        public ActionResult Local_Data_Binding()
        {
            ViewBag.inlineDefault = Local_Data_Binding_GetDefaultInlineData();
            ViewBag.inline = Local_Data_Binding_GetInlineData();
            return View();
        }

        private IEnumerable<PanelBarItemModel> Local_Data_Binding_GetDefaultInlineData()
        {
            List<PanelBarItemModel> inlineDefault = new List<PanelBarItemModel>
                {
                    new PanelBarItemModel
                    {
                        Text = "Furniture",
                        Items = new List<PanelBarItemModel>
                        {
                            new PanelBarItemModel()
                            {
                                Text = "Tables & Chairs"
                            },
                            new PanelBarItemModel
                            {
                                 Text = "Sofas"
                            },
                            new PanelBarItemModel
                            {
                                 Text = "Occasional Furniture"
                            }
                        }
                    },
                    new PanelBarItemModel
                    {
                        Text = "Decor",
                        Items = new List<PanelBarItemModel>
                        {
                            new PanelBarItemModel()
                            {
                                Text = "Bed Linen"
                            },
                            new PanelBarItemModel
                            {
                                 Text = "Curtains & Blinds"
                            },
                            new PanelBarItemModel
                            {
                                 Text = "Carpets"
                            }
                        }
                    }
                };

            return inlineDefault;
        }

        private IEnumerable<CategoryItem> Local_Data_Binding_GetInlineData()
        {
            List<CategoryItem> inline = new List<CategoryItem>
                {
                    new CategoryItem
                    {
                        CategoryName = "Storage",
                        SubCategories = new List<SubCategoryItem>
                        {
                            new SubCategoryItem()
                            {
                                SubCategoryName = "Wall Shelving"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Floor Shelving"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Kids Storag"
                            }
                        }
                    },
                    new CategoryItem
                    {
                        CategoryName = "Lights",
                        SubCategories = new List<SubCategoryItem>
                        {
                            new SubCategoryItem()
                            {
                                SubCategoryName = "Ceiling"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Table"
                            },
                            new SubCategoryItem
                            {
                                 SubCategoryName = "Floor"
                            }
                        }
                    }
                };

            return inline;
        }
    }
}
