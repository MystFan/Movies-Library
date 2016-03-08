﻿namespace MoviesLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;

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
            var movies = this.moviesService
                .GetLastAdded(3)
                .ProjectTo<MovieViewModel>()               
                .ToList();

            return this.View(movies);
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