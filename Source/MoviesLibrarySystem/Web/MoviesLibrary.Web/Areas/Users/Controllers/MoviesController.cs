namespace MoviesLibrary.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;

    public class MoviesController : UsersBaseController
    {
        private IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var movie = this.moviesService.GetByViewId(id);
            var model = Mapper.Map<MovieViewModel>(movie);
            return this.View(model);
        }
    }
}