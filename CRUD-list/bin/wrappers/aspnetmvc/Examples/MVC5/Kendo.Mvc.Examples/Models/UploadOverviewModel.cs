using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class UploadOverviewModel
    {
        public bool IsLimited { get; set; }
        public string[] AllowedExtensions { get; set; }
    }
}