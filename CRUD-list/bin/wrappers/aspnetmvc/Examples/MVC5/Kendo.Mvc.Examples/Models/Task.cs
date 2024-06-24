using System;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Task
    {
        public int TaskID { get; set; }

        public System.DateTime Start { get; set; }

        public System.DateTime End { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Nullable<int> OwnerID { get; set; }

        public bool IsAllDay { get; set; }

        public string RecurrenceRule { get; set; }

        public Nullable<int> RecurrenceID { get; set; }

        public string RecurrenceException { get; set; }

        public string StartTimezone { get; set; }

        public string EndTimezone { get; set; }
    }
}