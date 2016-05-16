using MoviesLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoviesLibrary.Services.Data
{
    public class ImageConvertorService
    {
        public IEnumerable<MovieImage> HttpToMovieImage(IEnumerable<HttpPostedFileBase> images)
        {
            return null;
        }

        public IEnumerable<MovieImage> HttpToArticleImage(IEnumerable<HttpPostedFileBase> images)
        {
            return null;
        }

        private List<MovieLibraryImage> HttpFileToMovieImage(IEnumerable<HttpPostedFileBase> images)
        {
            List<MovieLibraryImage> filesDataResult = new List<MovieLibraryImage>();

            foreach (var image in images)
            {
                if (image == null)
                {
                    continue;
                }

                MovieImage movieImage = new MovieImage();
                movieImage.OriginalName = image.FileName;
                movieImage.Extension = Path.GetExtension(image.FileName);

                MemoryStream target = new MemoryStream();
                image.InputStream.CopyTo(target);
                movieImage.Content = target.ToArray();

                filesDataResult.Add(movieImage);
            }

            return filesDataResult;
        }
    }
}
