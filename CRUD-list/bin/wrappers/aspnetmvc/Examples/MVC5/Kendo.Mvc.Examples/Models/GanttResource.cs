using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Models
{
    public partial class GanttResource
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }
    }
}