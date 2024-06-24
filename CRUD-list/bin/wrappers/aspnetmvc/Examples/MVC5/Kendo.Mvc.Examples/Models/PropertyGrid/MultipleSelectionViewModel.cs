namespace Kendo.Mvc.Examples.Models.PropertyGrid
{
    using System.ComponentModel.DataAnnotations;

    public class MultipleSelectionViewModel
    {
        [Display(GroupName = "Kendo UI/Telerik",
Description = "Controls the overall physical size of a button. Default value is \"medium\".")]
        public string size { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Controls how the color is applied to the button. Default value is \"solid\".")]
        public string fillMode { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Controls the main color applied to the button.")]
        public string themeColor { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Controls what border radius is applied to a button.")]
        public string rounded { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Defines a name of an existing icon in the Kendo UI theme sprite.")]
        public string icon { get; set; }

        [Display(GroupName = "Kendo UI/Telerik", Description = "Enable or disable the control.")]
        public bool enable { get; set; }

        [Display(GroupName = "HTML")]
        public FontViewModel font { get; set; }
    }
}