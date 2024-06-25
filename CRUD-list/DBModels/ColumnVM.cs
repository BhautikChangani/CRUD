using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_list.DBModels
{
    public partial class ColumnVM
    {
        public int ColumnId { get; set; }
        public string ColumnName { get; set; }
        public int PageId { get; set; }
        public string ColumnTitle { get; set; }
    }
}