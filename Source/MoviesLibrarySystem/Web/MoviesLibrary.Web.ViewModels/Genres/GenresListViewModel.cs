using System;
namespace MoviesLibrary.Web.ViewModels.Genres
{
    using System.Collections.Generic;

    public class GenresListViewModel
    {
        public int Selected { get; set; }

        public IList<string> Genres { get; set; }
    }
}
