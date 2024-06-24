using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Models
{
    public partial class GanttTask
    {
        [Key]
        public int ID { get; set; }

        public Nullable<int> ParentID { get; set; }

        public int OrderID { get; set; }

        public string Title { get; set; }

        public System.DateTime Start { get; set; }

        public System.DateTime End { get; set; }

        public decimal PercentComplete { get; set; }

        public bool Expanded { get; set; }

        public bool Summary { get; set; }
    }
}