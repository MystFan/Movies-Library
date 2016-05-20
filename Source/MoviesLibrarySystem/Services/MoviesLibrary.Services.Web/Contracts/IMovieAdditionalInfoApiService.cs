namespace MoviesLibrary.Services.Web.Contracts
{
    using MoviesLibrary.Services.Web.Helpers;

    public interface IMovieAdditionalInfoApiService
    {
        MovieInfo GetMovie(string title, int year);
    }
}
