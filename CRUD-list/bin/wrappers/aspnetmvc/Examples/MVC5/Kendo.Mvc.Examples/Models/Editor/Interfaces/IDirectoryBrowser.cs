using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public interface IDirectoryBrowser
    {
        IEnumerable<FileBrowserEntry> GetFiles(string path, string filter);

        IEnumerable<FileBrowserEntry> GetDirectories(string path);

        HttpServerUtilityBase Server
        {
            get;
            set;
        }
    }
}
