using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models.WordsProcessing
{
    public class DocumentDescriptionViewModel
    {
        public string Columns { get; set; }

        public string FileType { get; set; }

        public bool RepeateHeader { get; set; }

        public string RowBackground { get; set; }

        public string GroupHeaderBackground { get; set; }

        public string HeaderBackground { get; set; }
    }
}