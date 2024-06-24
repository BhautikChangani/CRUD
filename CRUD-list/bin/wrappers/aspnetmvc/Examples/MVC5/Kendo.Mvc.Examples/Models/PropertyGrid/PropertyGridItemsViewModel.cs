namespace Kendo.Mvc.Examples.Models.PropertyGrid
{
    using Kendo.Mvc.UI;
    using System.ComponentModel.DataAnnotations;

    public class PropertyGridItemsViewModel
    {
        [Display(GroupName = "Kendo UI/Telerik",
    Description = "Controls the overall physical size of a button. Default value is \"medium\".")]
        public ComponentSize size { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Controls how the color is applied to the button. Default value is \"solid\".")]
        public ButtonFillMode fillMode { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Controls the main color applied to the button.")]
        public ThemeColor themeColor { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Controls what border radius is applied to a button.")]
        public Rounded rounded { get; set; }

        [Display(GroupName = "Kendo UI/Telerik",
            Description = "Defines a name of an existing icon in the Kendo UI theme sprite.")]
        public string icon { get; set; }

        [Display(GroupName = "HTML")]
        public FontViewModel font { get; set; }
    }
}