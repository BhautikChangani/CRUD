using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
     public abstract class EditorFileBrowserController : BaseFileBrowserController
    {
        protected EditorFileBrowserController(
            Models.IDirectoryBrowser browser,
            Models.IDirectoryPermission permission,
            Models.IVirtualPathProvider provider)
                :base(browser, permission, provider)
                {
                
                }
    /// <summary>
    /// Gets the valid file extensions by which served files will be filtered.
    /// </summary>
    public override string Filter
        {
            get
            {
                return EditorFileBrowserSettings.DefaultFileTypes;
            }
        }
    }
}
