namespace MoviesLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class Person : BaseModel<int>
    {
        private ICollection<Movie> movies;

        public Person()
        {
            this.movies = new HashSet<Movie>();
        }

        [Required]
        [StringLength(PersonValidations.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = PersonValidations.NameMinLength)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
