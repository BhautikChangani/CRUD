using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models
{
    public interface IDirectoryPermission
    {
        bool CanAccess(string rootPath, string childPath);
    }
}
