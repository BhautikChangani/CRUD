using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class DirectoryPermission : IDirectoryPermission
    {
        public bool CanAccess(string rootPath, string childPath)
        {
            return childPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase);
        }
    }
}