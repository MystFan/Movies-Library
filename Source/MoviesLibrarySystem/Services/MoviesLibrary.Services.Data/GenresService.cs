namespace MoviesLibrary.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class GenresService : IGenresService
    {
        public IList<string> GetAll()
        {
            var genres = Enum.GetNames(typeof(Genre)).ToList();

            return genres;
        }
    }
}
