namespace MoviesLibrary.Web.ViewModels.Movie
{
    using MoviesLibrary.Services.Web.Helpers;

    public class MovieDetailsViewModel
    {
        public string VideoTitle { get; set; }

        public MovieViewModel Movie { get; set; }

        public MovieInfo MovieAdditionalInfo { get; set; }
    }
}
