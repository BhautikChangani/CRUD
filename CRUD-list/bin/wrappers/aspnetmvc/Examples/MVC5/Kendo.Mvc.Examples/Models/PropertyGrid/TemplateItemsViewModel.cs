namespace Kendo.Mvc.Examples.Models.PropertyGrid
{
    using System.ComponentModel.DataAnnotations;

    public class TemplateItemsViewModel
    {
        [Display(GroupName = "First Group")]
        public string text { get; set; }

        [Display(GroupName = "First Group", Description = "Select a different color that will be applied in the template.")]
        public string color { get; set; }

        [Display(GroupName = "First Group", Description = "Define a name of an existing icon in the Kendo UI theme sprite.")]
        public string icon { get; set; }

        [Display(GroupName = "HTML")]
        public FontViewModel font { get; set; }
    }
}