using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class MeetingAttendee
    {
        public int Id { get; set; }

        public int? MeetingID { get; set; }

        public int? AttendeeID { get; set; }

        [ForeignKey(nameof(MeetingID))]
        [InverseProperty(nameof(Models.Meeting.MeetingAttendees))]
        public virtual Meeting Meeting { get; set; }
    }
}