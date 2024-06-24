using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class RadioGroupViewModel
    {
        public List<IInputGroupItem> Items { get; set; }

        public string RadioGroupValue { get; set; }
    }
}