using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class SpreadsheetSubmitViewModel
    {
        public IList<SpreadsheetProductViewModel> Created { get; set; }

        public IList<SpreadsheetProductViewModel> Destroyed { get; set; }

        public IList<SpreadsheetProductViewModel> Updated { get; set; }
    }
}