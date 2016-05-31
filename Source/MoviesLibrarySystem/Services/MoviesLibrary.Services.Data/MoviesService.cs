namespace MoviesLibrary.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;

    using MoviesLibrary.Common;
    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class MoviesService : IMoviesService
    {
        private IDbRepository<Movie> movies;

        public MoviesService(IDbRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public IQueryable<Movie> GetLastAdded(int count)
        {
            return this.GetAll()
                .OrderByDescending(m => m.CreatedOn)
                .Take(count);
        }

        public IQueryable<Movie> GetByYear(int year)
        {
            var movies = this.GetAll()
                .Where(m => m.Year == year)
                .OrderByDescending(m => m.Year);

            return movies;
        }

        public void Add(string title, string description, int year, string videoId, int genreType, int coverIndex, IEnumerable<string> actorNames, IEnumerable<string> directorNames, IEnumerable<HttpPostedFileBase> images)
        {
            var movieImages = this.HttpFileToMovieImage(images);
            movieImages[coverIndex].IsCover = true;

            this.movies.Add(new Movie()
            {
                Title = title,
                Description = description,
                Year = year,
                VideoId = videoId,
                Actors = actorNames.Select(n => new Actor() { Name = n }).ToList(),
                Directors = directorNames.Select(n => new Director() { Name = n }).ToList(),
                Images = movieImages,
                Genre = (Genre)genreType
            });

            this.movies.SaveChanges();
        }

        public Movie GetByViewId(string viewId)
        {
            IdentifierProvider idProvider = new IdentifierProvider();
            int id = idProvider.DecodeId(viewId);
            var movie = this.GetById(id);

            return movie;
        }

        public Movie GetById(int id)
        {
            var movie = this.movies.GetById(id);
            return movie;
        }

        public IQueryable<int> GetMovieYears()
        {
            var years = this.GetAll()
                .Select(m => m.Year)
                .Distinct()
                .OrderByDescending(y => y);

            return years;
        }

        public IQueryable<Movie> Get(int page, string title, int? genreType)
        {
            title = title != null ? title : string.Empty;

            IQueryable<Movie> moviesResult = null;
            if (genreType.HasValue && genreType.Value >= 0 && title != string.Empty)
            {
                moviesResult = this.movies
                    .All()
                    .Where(m => m.Title.ToLower().Contains(title.ToLower()) && (int)m.Genre == genreType.Value);
            }
            else if (!genreType.HasValue && title != string.Empty)
            {
                moviesResult = this.movies
                    .All()
                    .Where(m => m.Title.ToLower().Contains(title.ToLower()));
            }
            else if (genreType.HasValue && genreType.Value >= 0 && title == string.Empty)
            {
                moviesResult = this.movies
                    .All()
                    .Where(m => (int)m.Genre == genreType.Value);
            }
            else
            {
                moviesResult = this.movies.All();
            }

            moviesResult = moviesResult
                    .OrderByDescending(m => m.CreatedOn)
                    .Skip((page - 1) * MovieConstants.MoviesListDefaultPageSize)
                    .Take(MovieConstants.MoviesListDefaultPageSize);

            return moviesResult;
        }

        private List<MovieImage> HttpFileToMovieImage(IEnumerable<HttpPostedFileBase> images)
        {
            List<MovieImage> filesDataResult = new List<MovieImage>();

            foreach (var image in images)
            {
                if (image == null)
                {
                    continue;
                }

                MovieImage movieImage = new MovieImage();
                movieImage.OriginalName = image.FileName;
                movieImage.Extension = Path.GetExtension(image.FileName);

                MemoryStream target = new MemoryStream();
                image.InputStream.CopyTo(target);
                movieImage.Content = target.ToArray();

                filesDataResult.Add(movieImage);
            }

            return filesDataResult;
        }
    }
}
