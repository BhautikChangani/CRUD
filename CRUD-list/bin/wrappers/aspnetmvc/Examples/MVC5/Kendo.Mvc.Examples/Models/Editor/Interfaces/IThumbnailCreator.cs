using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models
{
    public interface IThumbnailCreator
    {
        byte[] Create(Stream source, ImageSize desiredSize, string contentType);
    }
}
