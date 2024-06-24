using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Models
{
    public class NavigationExampleGroup
    {
        public NavigationExample[] Items { get; set; } = new NavigationExample[] { };
        public string Name { get; set; } = string.Empty;
    }
}
