namespace MoviesLibrary.Services.Data
{
    using System.Linq;

    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class RatingService : IRatingService
    {
        private IDbRepository<Rating> ratings;
        private IDbRepository<Movie> movies;

        public RatingService(IDbRepository<Rating> ratings, IDbRepository<Movie> movies)
        {
            this.ratings = ratings;
            this.movies = movies;
        }

        public void AddRating(string userId, int movieId, int ratingValue)
        {
            var rating = this.ratings
                .All()
                .FirstOrDefault(r => r.AuthorId == userId);

            if (rating != null)
            {
                rating.Value = ratingValue;
            }
            else
            {
                this.ratings.Add(new Rating()
                {
                    Value = ratingValue,
                    AuthorId = userId,
                    MovieId = movieId
                });
            }

            this.ratings.SaveChanges();
        }

        public int GetMovieRating(int movieId)
        {
            var movie = this.movies.GetById(movieId);
            var ratingsCount = movie.Ratings.Count();
            var rating = 0;

            if (ratingsCount == 0)
            {
                return rating;
            }

            rating = movie.Ratings.Sum(r => r.Value) / movie.Ratings.Count();

            return rating;
        }
    }
}
