using System.ComponentModel.DataAnnotations;


namespace Kendo.Mvc.Examples.Models
{
    public class TerritoryViewModel
    {
        [Key]
        public string TerritoryID { get; set; }

        public string TerritoryDescription { get; set; }
    }
}