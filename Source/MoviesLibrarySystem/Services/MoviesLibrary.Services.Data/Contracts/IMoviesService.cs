namespace MoviesLibrary.Services.Data.Contracts
{
    using System.Linq;

    using MoviesLibrary.Models;

    public interface IMoviesService : IService
    {
        IQueryable<Movie> GetAll();
    }
}
