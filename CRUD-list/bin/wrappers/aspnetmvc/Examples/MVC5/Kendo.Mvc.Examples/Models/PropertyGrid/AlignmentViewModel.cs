namespace Kendo.Mvc.Examples.Models.PropertyGrid
{
    using System.ComponentModel.DataAnnotations;

    public class AlignmentViewModel
    {
        [Required]
        [Display(GroupName = "alignment", Description = "Add space around the element.")]
        public int margin { get; set; }

        [Required]
        [Display(GroupName = "alignment", Description = "Add space around the content of the element.")]
        public int padding { get; set; }
    }
}