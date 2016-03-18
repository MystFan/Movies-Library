namespace MoviesLibrary.Web.ViewModels.Actor
{
    using System.Collections.Generic;

    using MoviesLibrary.Web.ViewModels.Movie;

    public class ActorViewModel
    {
        public string Name { get; set; }

        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}
