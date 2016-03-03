namespace MoviesLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;

    public class HomeController : BaseController
    {
        private IMoviesService moviesData;

        public HomeController(IMoviesService moviesData)
        {
            this.moviesData = moviesData;
        }

        public ActionResult Index()
        {
            var movies = this.moviesData
                .GetAll()
                .ProjectTo<MovieViewModel>()
                .ToList();

            return this.View();
        }
    }
}