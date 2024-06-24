using System;

namespace Kendo.Mvc.Examples.Models
{
    public partial class OrgChartConnection
    {
        public int Id { get; set; }

        public Nullable<int> FromShapeId { get; set; }

        public Nullable<int> ToShapeId { get; set; }

        public string Text { get; set; }

        public Nullable<int> FromPointX { get; set; }

        public Nullable<int> FromPointY { get; set; }

        public Nullable<int> ToPointX { get; set; }

        public Nullable<int> ToPointY { get; set; }
    }
}