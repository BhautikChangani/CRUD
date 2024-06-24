using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public class FileManagerDataController : Controller
    {
        private readonly FileContentBrowser directoryBrowser;
        //
        // GET: /FileManager/
        private const string contentFolderRoot = "~/Content/";
        private const string prettyName = "Folders/";
        private static readonly string[] foldersToCopy = new[] { "~/Content/shared/filemanager" };
        private const string SessionDirectory = "Dir";
        private const string DefaultTarget = "Folders";


        public FileManagerDataController()
        {
            // Helper utility for the FileManager controller
            directoryBrowser = new FileContentBrowser();
        }


        /// <summary>
        /// Gets the base paths from which content will be served.
        /// </summary>
        public string ContentPath
        {
            get
            {
                return CreateUserFolder();
            }
        }

        /// <summary>
        /// Gets the valid file extensions by which served files will be filtered.
        /// </summary>
        public string Filter
        {
            get
            {
                return "*.*";
            }
        }

        private string CreateUserFolder()
        {
            var virtualPath = Path.Combine(contentFolderRoot, "UserFiles", prettyName);

            var path = Server.MapPath(virtualPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                foreach (var sourceFolder in foldersToCopy)
                {
                    CopyFolder(Server.MapPath(sourceFolder), path);
                }
            }
            return virtualPath;
        }

        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(file));
                System.IO.File.Copy(file, dest);
            }

            foreach (var folder in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(folder));
                CopyFolder(folder, dest);
            }
        }

        /// <summary>
        /// Determines if content of a given path can be browsed.
        /// </summary>
        /// <param name="path">The path which will be browsed.</param>
        /// <returns>true if browsing is allowed, otherwise false.</returns>
        public bool Authorize(string path)
        {
            return CanAccess(path);
        }

        public bool CanAccess(string path)
        {
            return path.StartsWith(ToAbsolute(ContentPath), StringComparison.OrdinalIgnoreCase);
        }

        private string ToAbsolute(string virtualPath)
        {
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }

        private string CombinePaths(string basePath, string relativePath)
        {
            return VirtualPathUtility.Combine(VirtualPathUtility.AppendTrailingSlash(basePath), relativePath);
        }

        public string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return ToAbsolute(ContentPath);
            }

            return CombinePaths(ToAbsolute(ContentPath), path);
        }

        public FileManagerEntry VirtualizePath(FileManagerEntry entry)
        {
            return new FileManagerEntry {
                Created = entry.Created,
                CreatedUtc = entry.CreatedUtc,
                Extension = entry.Extension,
                HasDirectories = entry.HasDirectories,
                IsDirectory = entry.IsDirectory,
                Modified = entry.Modified,
                ModifiedUtc = entry.ModifiedUtc,
                Name = entry.Name,
                Path = entry.Path.Replace(Server.MapPath(ContentPath), "").Replace(@"\", "/"),
                Size = entry.Size
            };
        }

        public ActionResult Create(string target, FileManagerEntry entry)
        {
            FileManagerEntry newEntry;

            if (!Authorize(NormalizePath(target)))
            {
                throw new HttpException(403, "Forbidden");
            }


            if (String.IsNullOrEmpty(entry.Path))
            {
                newEntry = CreateNewFolder(target, entry);
            }
            else
            {
                newEntry = CopyEntry(target, entry);
            }

            UpdateSessionDir();

            return Json(VirtualizePath(newEntry));
        }

        public FileManagerEntry CopyEntry(string target, FileManagerEntry entry)
        {
            var path = NormalizePath(entry.Path);
            var physicalPath = Server.MapPath(path);
            var physicalTarget = EnsureUniqueName(NormalizePath(target), entry);

            FileManagerEntry newEntry;

            if (entry.IsDirectory)
            {                
                newEntry = CopyDirectory(new DirectoryInfo(physicalPath), Directory.CreateDirectory(physicalTarget));
            }
            else
            {
                newEntry = CopyFile(physicalPath, physicalTarget);
            }

            return newEntry;
        }

        public FileManagerEntry CopyFile(string source, string target)
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;
            var entry = sessionDir.FirstOrDefault(x => x.Path == source);

            entry.Path = target;

            return entry;
        }

        public FileManagerEntry CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;
            var currentEntry = sessionDir.FirstOrDefault(x => x.Path == source.FullName);

            currentEntry.Path = target.FullName;

            foreach (FileInfo fi in source.GetFiles())
            { 
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                CopyFile(fi.FullName, Path.Combine(target.FullName, fi.Name));
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }

            return currentEntry;
        }

        public FileManagerEntry CreateNewFolder(string target, FileManagerEntry entry)
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;
            var path = NormalizePath(target);
            string physicalPath = EnsureUniqueName(path, entry);

            entry.Path = physicalPath;
            entry.Created = DateTime.Now;
            entry.CreatedUtc = DateTime.UtcNow;
            entry.Modified = DateTime.Now;
            entry.ModifiedUtc = DateTime.UtcNow;
            sessionDir.Add(entry);

            return entry;
        }

        public string EnsureUniqueName(string target, FileManagerEntry entry)
        {
            var tempName = entry.Name + entry.Extension;
            int sequence = 0;
            var physicalTarget = NormalizePath(Path.Combine(target, tempName));

            if (!Authorize(physicalTarget))
            {
                throw new HttpException(403, "Forbidden");
            }

            physicalTarget = Server.MapPath(physicalTarget);

            if (entry.IsDirectory)
            {
                while (Directory.Exists(physicalTarget))
                {
                    tempName = entry.Name + String.Format("({0})", ++sequence);
                    physicalTarget = Path.Combine(Server.MapPath(target), tempName);
                }
            }
            else
            {
                while (System.IO.File.Exists(physicalTarget))
                {
                    tempName = entry.Name + String.Format("({0})", ++sequence) + entry.Extension;
                    physicalTarget = Path.Combine(Server.MapPath(target), tempName);
                }
            }

            return physicalTarget;
        }

        public ActionResult Destroy(FileManagerEntry entry)
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;
            var path = Server.MapPath(NormalizePath(entry.Path));
            var currentEntry = sessionDir.FirstOrDefault(x => x.Path == path);


            if (currentEntry != null)
            {
                sessionDir.Remove(currentEntry);
                return Json(new object[0]);
            }

            throw new HttpException(404, "File Not Found");
        }

        public void DeleteFile(string path)
        {
            if (!Authorize(path))
            {
                throw new HttpException(403, "Forbidden");
            }

            var physicalPath = Server.MapPath(path);

            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
            }
        }

        public void DeleteDirectory(string path)
        {
            if (!Authorize(path))
            {
                throw new HttpException(403, "Forbidden");
            }

            var physicalPath = Server.MapPath(path);

            if (Directory.Exists(physicalPath))
            {
                Directory.Delete(physicalPath, true);
            }
        }

        public JsonResult Read(string target)
        {
            var path = NormalizePath(target);
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;

            if (Authorize(path))
            {
                try
                {
                    directoryBrowser.Server = Server;

                    if (sessionDir == null)
                    {
                        Session[SessionDirectory] = sessionDir = directoryBrowser.GetAll(Server.MapPath(NormalizePath(null)));
                    }
                    
                    var result = sessionDir.Where(d=> TargetMatch(target, d.Path)).Select(VirtualizePath).ToList();

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (DirectoryNotFoundException)
                {
                    throw new HttpException(404, "File Not Found");
                }
            }

            throw new HttpException(403, "Forbidden");
        }

        /// <summary>
        /// Updates an entry with a given entry.
        /// </summary>
        /// <param name="path">The path to the parent folder in which the folder should be created.</param>
        /// <param name="entry">The entry.</param>
        /// <returns>An empty <see cref="ContentResult"/>.</returns>
        /// <exception cref="HttpException">Forbidden</exception>
        public ActionResult Update(string target, FileManagerEntry entry)
        {
            FileManagerEntry newEntry;
            var path = Server.MapPath(NormalizePath(entry.Path));

            if (!Authorize(NormalizePath(entry.Path)) && !Authorize(NormalizePath(target)))
            {
                throw new HttpException(403, "Forbidden");
            }

            newEntry = RenameEntry(entry);

            return Json(VirtualizePath(newEntry));
        }

        public FileManagerEntry RenameEntry(FileManagerEntry entry)
        {
            var path = NormalizePath(entry.Path);
            var physicalPath = Server.MapPath(path);
            var physicalTarget = EnsureUniqueName(Path.GetDirectoryName(path), entry); //NormalizePath(Path.Combine(physicalPath, entry.Name + entry.Extension));
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;
            FileManagerEntry currentEntry = sessionDir.FirstOrDefault(x => x.Path == physicalPath);

            currentEntry.Name = entry.Name;
            currentEntry.Path = physicalTarget;
            currentEntry.Extension = entry.Extension ?? "";

            return currentEntry;
        }

        /// <summary>
        /// Determines if a file can be uploaded to a given path.
        /// </summary>
        /// <param name="path">The path to which the file should be uploaded.</param>
        /// <param name="file">The file which should be uploaded.</param>
        /// <returns>true if the upload is allowed, otherwise false.</returns>
        public bool AuthorizeUpload(string path, HttpPostedFileBase file)
        {
            if (!CanAccess(path))
            {
                throw new DirectoryNotFoundException(String.Format("The specified path cannot be found - {0}", path));
            }

            if (!IsValidFile(file.FileName))
            {
                throw new InvalidDataException(String.Format("The type of file is not allowed. Only {0} extensions are allowed.", Filter));
            }

            return true;
        }

        private bool IsValidFile(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var allowedExtensions = Filter.Split(',');

            return allowedExtensions.Any(e => e.Equals("*.*") || e.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Uploads a file to a given path.
        /// </summary>
        /// <param name="path">The path to which the file should be uploaded.</param>
        /// <param name="file">The file which should be uploaded.</param>
        /// <returns>A <see cref="JsonResult"/> containing the uploaded file's size and name.</returns>
        /// <exception cref="HttpException">Forbidden</exception>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(string path, HttpPostedFileBase file)
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;
            FileManagerEntry newEntry = new FileManagerEntry();
            path = NormalizePath(path);
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);

            if (AuthorizeUpload(path, file))
            {
                newEntry.Path = Path.Combine(Server.MapPath(Path.Combine(path, file.FileName)));
                newEntry.Name = fileName;
                newEntry.Modified = DateTime.Now;
                newEntry.ModifiedUtc = DateTime.Now;
                newEntry.Created = DateTime.Now;
                newEntry.CreatedUtc = DateTime.UtcNow;
                newEntry.Size = file.ContentLength;
                newEntry.Extension = Path.GetExtension(file.FileName);
                sessionDir.Add(newEntry);

                return Json(VirtualizePath(newEntry), "text/plain");
            }

            throw new HttpException(403, "Forbidden");
        }

        private bool TargetMatch(string target, string path)
        {
            var targetFullPath = Server.MapPath(NormalizePath(target));
            var parentPath = Directory.GetParent(path).FullName;

            return targetFullPath.Trim('\\') == parentPath.Trim('\\');
        }

        private void UpdateSessionDir()
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;

            foreach (var item in sessionDir)
            {
                item.HasDirectories = HasSubDirectories(item);
            }
        }

        private bool HasSubDirectories(FileManagerEntry entry)
        {
            ICollection<FileManagerEntry> sessionDir = Session[SessionDirectory] as ICollection<FileManagerEntry>;

            foreach (var item in sessionDir)
            {
                if (item.IsDirectory && item.Path.Contains(entry.Path))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class FileContentBrowser
    {
        public ICollection<FileManagerEntry> GetFiles(string path, string filter)
        {
            var directory = new DirectoryInfo(Server.MapPath(path));

            var extensions = (filter ?? "*").Split(new string[] { ", ", ",", "; ", ";" }, System.StringSplitOptions.RemoveEmptyEntries);

            return extensions.SelectMany(directory.GetFiles)
                .Select(file => new FileManagerEntry
                {
                    Name = Path.GetFileNameWithoutExtension(file.Name),
                    Size = file.Length,
                    Path = file.FullName,
                    Extension = file.Extension,
                    IsDirectory = false,
                    HasDirectories = false,
                    Created = file.CreationTime,
                    CreatedUtc = file.CreationTimeUtc,
                    Modified = file.LastWriteTime,
                    ModifiedUtc = file.LastWriteTimeUtc
                }).ToList();
        }

        public ICollection<FileManagerEntry> GetAll(string path)
        {
            var directory = new DirectoryInfo(path);
            var directories = directory.GetDirectories();
            var files = directory.GetFiles();
            var result = new List<FileManagerEntry>();

            foreach (var item in files)
            {
                result.Add(GetFile(item.FullName));
            }

            foreach (var item in directories)
            {
                result.Add(GetDirectory(item.FullName));

                if (item.GetDirectories().Length > 0 || item.GetFiles().Length > 0)
                {
                    result.AddRange(GetAll(item.FullName));
                }
            }

            return result;
        }

        public ICollection<FileManagerEntry> GetDirectories(string path)
        {
            var directory = new DirectoryInfo(Server.MapPath(path));

            return directory.GetDirectories()
                .Select(subDirectory => new FileManagerEntry
                {
                    Name = subDirectory.Name,
                    Path = subDirectory.FullName,
                    Extension = subDirectory.Extension,
                    IsDirectory = true,
                    HasDirectories = subDirectory.GetDirectories().Length > 0,
                    Created = subDirectory.CreationTime,
                    CreatedUtc = subDirectory.CreationTimeUtc,
                    Modified = subDirectory.LastWriteTime,
                    ModifiedUtc = subDirectory.LastWriteTimeUtc
                }).ToList();
        }

        public FileManagerEntry GetDirectory(string path)
        {
            var directory = new DirectoryInfo(path);

            return new FileManagerEntry
            {
                Name = directory.Name,
                Path = directory.FullName,
                Extension = directory.Extension,
                IsDirectory = true,
                HasDirectories = directory.GetDirectories().Length > 0,
                Created = directory.CreationTime,
                CreatedUtc = directory.CreationTimeUtc,
                Modified = directory.LastWriteTime,
                ModifiedUtc = directory.LastWriteTimeUtc
            };
        }

        public FileManagerEntry GetFile(string path)
        {
            var file = new FileInfo(path);

            return new FileManagerEntry
            {
                Name = Path.GetFileNameWithoutExtension(file.Name),
                Path = file.FullName,
                Size = file.Length,
                Extension = file.Extension,
                IsDirectory = false,
                HasDirectories = false,
                Created = file.CreationTime,
                CreatedUtc = file.CreationTimeUtc,
                Modified = file.LastWriteTime,
                ModifiedUtc = file.LastWriteTimeUtc
            };
        }

        public HttpServerUtilityBase Server
        {
            get;
            set;
        }
    }
}


