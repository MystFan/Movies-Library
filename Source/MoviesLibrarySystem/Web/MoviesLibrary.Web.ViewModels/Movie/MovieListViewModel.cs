namespace MoviesLibrary.Web.ViewModels.Movie
{
    using System.Collections.Generic;

    public class MovieListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }

        public string Title { get; set; }

        public int? Type { get; set; }
    }
}
