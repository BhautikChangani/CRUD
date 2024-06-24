using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Meeting
    {
        public Meeting()
        {
            this.MeetingAttendees = new HashSet<MeetingAttendee>();
        }

        [Key]
        public int MeetingID { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> RoomID { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }

        [InverseProperty(nameof(MeetingAttendee.Meeting))]
        public virtual ICollection<MeetingAttendee> MeetingAttendees { get; set; }
    }
}