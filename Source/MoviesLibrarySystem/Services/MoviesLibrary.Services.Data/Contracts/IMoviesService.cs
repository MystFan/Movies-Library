namespace MoviesLibrary.Services.Data.Contracts
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Web;

    using MoviesLibrary.Models;

    public interface IMoviesService : IService
    {
        IQueryable<Movie> GetAll();

        IQueryable<Movie> GetLastAdded(int count);

        Movie GetByViewId(string viewId);

        Movie GetById(int id);

        void Add(string title, string description, int year, int genreType, int coverIndex, IEnumerable<string> actorNames, IEnumerable<string> directorNames, IEnumerable<HttpPostedFileBase> images);
    }
}
