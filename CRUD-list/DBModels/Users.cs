using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_list.DBModels
{
    public partial class Users
    {
        public int? EmpId { get; set; }

        public int? DeptId { get; set; }

        public int? MngrId { get; set; }

        public string EmpName { get; set; }

        public decimal? Salary { get; set; }
        public string DeptName { get; set; }
        public string MngrName { get; set; }
    }
}