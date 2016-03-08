namespace MoviesLibrary.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;

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

        public void Add(string title, string description, int year, int genreType, int coverIndex, IEnumerable<string> actorNames, IEnumerable<string> directorNames, IEnumerable<HttpPostedFileBase> images)
        {
            var movieImages = this.HttpFileToMovieImage(images);
            movieImages[coverIndex].IsCover = true;

            this.movies.Add(new Movie()
            {
                Title = title,
                Description = description,
                Year = year,
                Actors = actorNames.Select(n => new Actor() { Name = n}).ToList(),
                Directors = directorNames.Select(n => new Director() { Name = n }).ToList(),
                Images = movieImages,
                Genre = (Genre)genreType
            });

            this.movies.SaveChanges();
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
