namespace MoviesLibrary.Services.Data
{
    using System.Linq;

    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class MoviesService : IMoviesService
    {
        private IDbRepository<Movie> movies;

        public MoviesService(IDbRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }
    }
}
