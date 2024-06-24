namespace Kendo.Mvc.Examples.Models.PropertyGrid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FontViewModel
    {
        [Required]
        [Display(GroupName = "font", Description = "Sets how thick or thin characters in text must be displayed.")]
        public int fontWeight { get; set; }

        [Required]
        [Display(GroupName = "font", Description = "Specifies the font family name for the element.")]
        public string fontFamily { get; set; }
    }
}