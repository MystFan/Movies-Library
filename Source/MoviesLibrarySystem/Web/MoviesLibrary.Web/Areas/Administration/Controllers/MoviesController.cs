namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;

    public class MoviesController : AdminBaseController
    {
        private IGenresService genresService;
        private IMoviesService moviesService;

        public MoviesController(IGenresService genresService, IMoviesService moviesService)
        {
            this.genresService = genresService;
            this.moviesService = moviesService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.moviesService.Add(
                    model.Title,
                    model.Description,
                    model.Year,
                    model.GenreType,
                    model.PosterIndex,
                    model.Actors,
                    model.Directors,
                    model.MovieImages
                );

            return this.RedirectToAction("Index", "Home", new { Area = string.Empty });
        }

        [ChildActionOnly]
        public ActionResult Genres()
        {
            var genres = this.genresService.GetAll();
            return this.PartialView("_GenresDropdownPartial", genres);
        } 
    }
}