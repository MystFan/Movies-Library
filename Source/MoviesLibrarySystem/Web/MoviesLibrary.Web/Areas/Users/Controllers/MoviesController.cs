namespace MoviesLibrary.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Services.Web.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;
    using MoviesLibrary.Web.Infrastructure.CustomFilters;

    [AllowAnonymous]
    public class MoviesController : UsersBaseController
    {
        private IMoviesService moviesService;
        private IGenresService genresService;
        private IVideoApiService youtubeService;
        private IMovieAdditionalInfoApiService movieInfoService;

        public MoviesController(IMoviesService moviesService, IGenresService genresService, IVideoApiService youtubeService, IMovieAdditionalInfoApiService movieInfoService)
        {
            this.moviesService = moviesService;
            this.genresService = genresService;
            this.youtubeService = youtubeService;
            this.movieInfoService = movieInfoService;
        }

        [HttpGet]
        public ActionResult All(string title, int? genreType, int page = 1)
        {
            var moviesResult = this.moviesService
                .Get(page, title, genreType)
                .ProjectTo<MovieViewModel>()
                .ToList();

            int totalMovies = this.moviesService.GetAll().Count();
            int totalPages = (int)Math.Ceiling(totalMovies / (decimal)MovieConstants.MoviesListDefaultPageSize);

            MovieListViewModel viewModel = new MovieListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Movies = moviesResult
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var movie = this.moviesService.GetByViewId(id);
            var movieViewModel = Mapper.Map<MovieViewModel>(movie);

            var viewModel = new MovieDetailsViewModel()
            {
                Movie = movieViewModel,
                MovieAdditionalInfo = this.movieInfoService.GetMovie(movie.Title, movie.Year),
                VideoTitle = youtubeService.GetVideoTitle(movie.VideoId)
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetByYear(int? year)
        {
            List<MovieSearchResultViewModel> movies = null;

            if (year.HasValue)
            {
                movies = this.Cache.Get(
                                    year.Value.ToString(),
                                    () => this.moviesService
                                                .GetByYear(year.Value)
                                                .ProjectTo<MovieSearchResultViewModel>()
                                                .ToList(),
                                    MovieConstants.ByYearCacheDuration);
            }

            return this.View(movies);
        }

        [ChildActionOnly]
        public ActionResult Genres()
        {
            var genres = this.genresService.GetAll();
            return this.PartialView("_GenresDropdownPartial", genres);
        } 

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetMovieDescription(string id)
        {
            var description = this.moviesService
                .GetByViewId(id)
                .Description;

            return this.Content(description);
        }
    }
}