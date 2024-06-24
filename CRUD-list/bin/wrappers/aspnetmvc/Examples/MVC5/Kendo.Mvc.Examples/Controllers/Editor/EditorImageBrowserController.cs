using Kendo.Mvc.UI;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public abstract class EditorImageBrowserController : BaseFileBrowserController, IImageBrowserController
    {
        private readonly Models.IThumbnailCreator thumbnailCreator;

        private const int ThumbnailHeight = 80;
        private const int ThumbnailWidth = 80;

        protected EditorImageBrowserController(
            Models.IDirectoryBrowser directoryBrowser,
            Models.IDirectoryPermission permission,
            Models.IVirtualPathProvider pathProvider,
            Models.IThumbnailCreator thumbnailCreator)
            : base(directoryBrowser, permission, pathProvider)
        {
            this.thumbnailCreator = thumbnailCreator;
        }

        /// <summary>
        /// Gets the valid file extensions by which served files will be filtered.
        /// </summary>
        public override string Filter
        {
            get
            {
                return EditorImageBrowserSettings.DefaultFileTypes;
            }
        }

        public virtual bool AuthorizeThumbnail(string path)
        {
            return CanAccess(path);
        }

        /// <summary>
        /// Serves an image's thumbnail by given path.
        /// </summary>
        /// <param name="path">The path to the image.</param>
        /// <returns>Thumbnail of an image.</returns>
        /// <exception cref="HttpException">Throws 403 Forbidden if the <paramref name="path"/> is outside of the valid paths.</exception>
        /// <exception cref="HttpException">Throws 404 File Not Found if the <paramref name="path"/> refers to a non existant image.</exception>
        [OutputCache(Duration = 3600, VaryByParam = "path")]
        public virtual ActionResult Thumbnail(string path)
        {
            path = NormalizePath(path);

            if (AuthorizeThumbnail(path))
            {
                var physicalPath = Server.MapPath(path);

                if (System.IO.File.Exists(physicalPath))
                {
                    Response.AddFileDependency(physicalPath);

                    return CreateThumbnail(physicalPath);
                }
                else
                {
                    throw new HttpException(404, "File Not Found");
                }
            }
            else
            {
                throw new HttpException(403, "Forbidden");
            }
        }

        private FileContentResult CreateThumbnail(string physicalPath)
        {
            using (var fileStream = System.IO.File.OpenRead(physicalPath))
            {
                var desiredSize = new Models.ImageSize
                {
                    Width = ThumbnailWidth,
                    Height = ThumbnailHeight
                };

                const string contentType = "image/png";

                return File(thumbnailCreator.Create(fileStream, desiredSize, contentType), contentType);
            }
        }
    }
}
