namespace MoviesLibrary.Services.Data.Contracts
{
    public interface IRatingService : IService
    {
        void AddRating(string userId, int movieId, int ratingValue);

        int GetMovieRating(int movieId);
    }
}
