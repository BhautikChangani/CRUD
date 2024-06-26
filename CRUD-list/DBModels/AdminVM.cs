using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_list.DBModels
{
    public partial class AdminVM
    {
        public int? AdminId { get; set; }
        public string Admin {  get; set; }
        public string AdminDept { get; set; }
        public decimal? AdminSalary { get; set; }
        public string AdminAst {  get; set; }
    }
}