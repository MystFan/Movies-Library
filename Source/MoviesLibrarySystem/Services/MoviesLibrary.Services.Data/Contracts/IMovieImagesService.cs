namespace MoviesLibrary.Services.Data.Contracts
{
    using MoviesLibrary.Models;

    public interface IMovieImagesService : IService
    {
        MovieImage GetById(string encodeId);

        MovieImage GetById(int id);
    }
}
