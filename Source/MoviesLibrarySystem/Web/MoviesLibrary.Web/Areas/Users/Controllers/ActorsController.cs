namespace MoviesLibrary.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Actor;
    using MoviesLibrary.Web.ViewModels.Movie;

    public class ActorsController : UsersBaseController
    {
        public IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        [HttpGet]
        public ActionResult GetMovies(string actorName)
        {
            if (actorName == null)
            {
                return this.PartialView("_MoviesSearchNoResult");
            }

            var actorMovies = this.actorsService
                .GetByName(actorName)
                .Movies
                .AsQueryable()
                .ProjectTo<MovieViewModel>()
                .ToList();

            var actorViewModel = new ActorViewModel()
            {
                Name = actorName,
                Movies = actorMovies
            };

            return this.View(actorViewModel);
        }
    }
}