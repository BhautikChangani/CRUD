namespace Kendo.Mvc.Examples.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DestinationViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
