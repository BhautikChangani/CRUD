using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class TimeDurationPickerViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public decimal Duration { get; set; }

        [Required]
        public decimal Banner { get; set; }
    }
}