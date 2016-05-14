namespace MoviesLibrary.Services.Web
{
    using System.Drawing;
    using System.IO;

    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Services.Web.Contracts;

    public class ImageEditorService : IImageEditorService
    {
        public Image ResizeImageFromStream(Stream stream)
        {
            Image originalImage = Image.FromStream(stream, true, true);
            Image resizedImage = ResizeImage(originalImage, new Size(ImageConstants.ArticleImageWidth, ImageConstants.ArticleImageHeight));
            return resizedImage;
        }

        private static Image ResizeImage(Image imgToResize, Size size)
        {
            Image result = (Image)(new Bitmap(imgToResize, size));
            return result;
        }
    }
}
