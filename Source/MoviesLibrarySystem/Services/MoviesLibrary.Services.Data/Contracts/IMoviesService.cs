namespace MoviesLibrary.Services.Data.Contracts
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Web;

    using MoviesLibrary.Models;

    public interface IMoviesService : IService
    {
        IQueryable<Movie> GetAll();

        IQueryable<Movie> Get(int page, string title, int? genreType);

        IQueryable<Movie> FilterMoviesCount(string title, int? genreType);

        IQueryable<Movie> GetLastAdded(int count);

        IQueryable<Movie> GetByYear(int year);

        Movie GetByViewId(string viewId);

        Movie GetById(int id);

        IQueryable<int> GetMovieYears();

        void Add(string title, string description, int year, string videoId, int genreType, int coverIndex, IEnumerable<string> actorNames, IEnumerable<string> directorNames, IEnumerable<HttpPostedFileBase> images);
    }
}
