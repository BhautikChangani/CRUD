using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Column_Virtualization()
        {
            return View();
        }

        public ActionResult Column_Read([DataSourceRequest] DataSourceRequest request)
        {
            int numberOfRows = 100;
            int numberOfColumns = 500;

            var dataTable = new DataTable();

            for (int i = 1; i <= numberOfColumns; i++)
            {
                dataTable.Columns.Add("Field" + i.ToString());
            }

            for (int i = 1; i <= numberOfRows; i++)
            {
                var row = dataTable.NewRow();

                for (int j = 1; j <= numberOfColumns; j++)
                {
                    row["Field" + j.ToString()] = "R" + i + ":C" + j;
                }
                dataTable.Rows.Add(row);
            }
            return Json(dataTable.ToDataSourceResult(request));
        }
    }
}
