namespace MoviesLibrary.Services.Web.Contracts
{
    using System.IO;
    using System.Drawing;

    public interface IImageEditorService
    {
        Image ResizeImageFromStream(Stream stream);
    }
}
