namespace Kendo.Mvc.Examples.Models
{
    public interface IImageResizer
    {
        ImageSize Resize(ImageSize originalSize, ImageSize targetSize);
    }
}
