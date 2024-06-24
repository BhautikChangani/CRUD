using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Models
{
    public partial class GanttResourceAssignment
    {
        [Key]
        public int ID { get; set; }

        public int TaskID { get; set; }

        public int ResourceID { get; set; }

        public decimal Units { get; set; }
    }
}