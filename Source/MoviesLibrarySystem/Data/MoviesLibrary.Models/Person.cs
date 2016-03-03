namespace MoviesLibrary.Models
{
    using System;
    using System.Collections.Generic;

    using MoviesLibrary.Data.Common;

    public class Person : BaseModel<int>
    {
        private ICollection<Movie> movies;

        public Person()
        {
            this.movies = new HashSet<Movie>();
        }

        public string Name { get; set; }

        public DateTime Born { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
