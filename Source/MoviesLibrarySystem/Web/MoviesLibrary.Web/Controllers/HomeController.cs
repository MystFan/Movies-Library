namespace MoviesLibrary.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;
    using MoviesLibrary.Services.Web;
    using MoviesLibrary.Services.Web.Helpers;

    public class HomeController : BaseController
    {
        private IMoviesService moviesService;
        private IMovieImagesService movieImagesService;

        public HomeController(IMoviesService moviesService, IMovieImagesService movieImagesService)
        {
            this.moviesService = moviesService;
            this.movieImagesService = movieImagesService;
        }

        public ActionResult Index()
        {
            var movies = this.Cache.Get(HomePageConstants.MoviesCacheKey,
                                    () => this.moviesService
                                            .GetLastAdded(HomePageConstants.MoviesCount)
                                            .ProjectTo<MovieViewModel>()
                                            .ToList(),
                                    HomePageConstants.MoviesCacheDuration);

            return this.View(movies);
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = HomePageConstants.YearsCacheDuration)]
        public ActionResult GetYears()
        {
            var years = this.moviesService
                .GetMovieYears()
                .Select(y => y.ToString())
                .ToList();

            return this.PartialView("_YearsListPartial", years);
        }

        [HttpGet]
        public ActionResult GetImage(string id)
        {
            var img = this.movieImagesService.GetById(id);
            string imgExtension = img.Extension;

            return new FileContentResult(img.Content, "image/" + imgExtension);
        }
    }
}