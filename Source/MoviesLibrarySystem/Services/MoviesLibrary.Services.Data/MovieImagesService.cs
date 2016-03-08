namespace MoviesLibrary.Services.Data
{
    using MoviesLibrary.Common;
    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class MovieImagesService : IMovieImagesService
    {
        private IDbRepository<MovieImage> moviesImages;

        public MovieImagesService(IDbRepository<MovieImage> moviesImages)
        {
            this.moviesImages = moviesImages;
        }

        public MovieImage GetById(string encodeId)
        {
            IdentifierProvider idProvider = new IdentifierProvider();
            int id = idProvider.DecodeId(encodeId);
            var image = this.GetById(id);
            return image;
        }

        public MovieImage GetById(int id)
        {
            var image = this.moviesImages.GetById(id);
            return image;
        }
    }
}
