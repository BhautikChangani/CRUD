using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class Sushi
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string[] tags { get; set; }
        public string image { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public bool featured { get; set; }
    }
}