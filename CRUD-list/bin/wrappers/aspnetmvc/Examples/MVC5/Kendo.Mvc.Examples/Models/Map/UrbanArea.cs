using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public class UrbanArea
    {
        [Key]
        public int ID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Country_ISO3 { get; set; }
        public int Pop1950 { get; set; }
        public int Pop1955 { get; set; }
        public int Pop1960 { get; set; }
        public int Pop1965 { get; set; }
        public int Pop1970 { get; set; }
        public int Pop1975 { get; set; }
        public int Pop1980 { get; set; }
        public int Pop1985 { get; set; }
        public int Pop1990 { get; set; }
        public int Pop1995 { get; set; }
        public int Pop2000 { get; set; }
        public int Pop2005 { get; set; }
        public int Pop2010 { get; set; }
        public int Pop2015 { get; set; }
        public int Pop2020 { get; set; }
        public int Pop2025 { get; set; }
        public int Pop2050 { get; set; }

        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]      
        public decimal[] Location {
            get
            {
                return new decimal[] { this.Latitude, this.Longitude };
            }

            private set { }
        }
    }
}
