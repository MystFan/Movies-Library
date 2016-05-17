namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;
    using MoviesLibrary.Models;

    public class MoviesController : AdminBaseController
    {
        private IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
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
            int genreMinValue = Enum.GetValues(typeof(Genre)).Cast<int>().Min();
            int genreMaxValue = Enum.GetValues(typeof(Genre)).Cast<int>().Max();

            if (model.GenreType < genreMinValue || model.GenreType > genreMaxValue)
            {
                this.ModelState.AddModelError(string.Empty, "Movie genre is required!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.moviesService.Add(
                    model.Title,
                    model.Description,
                    model.Year,
                    model.YouTubeVideoId,
                    model.GenreType,
                    model.PosterIndex,
                    model.Actors,
                    model.Directors,
                    model.MovieImages
                );

            return this.RedirectToAction("Index", "Home", new { Area = string.Empty });
        }
    }
}