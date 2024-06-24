namespace Kendo.Mvc.Examples.Models.Form
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FormItemsViewModels
    {
        [Required]
        public string TextBox { get; set; }
        public string TextArea { get; set; }

        [Required]
        public int? NumericTextBox { get; set; }

        public string MaskedTextBox { get; set; }

        public DateTime? DatePicker { get; set; }

        [Required]
        public DateTime? DateTimePicker { get; set; }

        [Required]
        public bool Switch { get; set; }

        public string ComboBox { get; set; }

        public string RadioGroup { get; set; }

        public string[] CheckBoxGroup { get; set; }

        [Required]
        public bool Agree { get; set; }
    }
}
