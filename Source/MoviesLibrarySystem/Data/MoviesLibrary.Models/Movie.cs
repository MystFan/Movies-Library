namespace MoviesLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class Movie : BaseModel<int>
    {
        private ICollection<Rating> ratings;
        private ICollection<Actor> actors;
        private ICollection<Director> directors;
        private ICollection<MovieImage> images;

        public Movie()
        {
            this.ratings = new HashSet<Rating>();
            this.actors = new HashSet<Actor>();
            this.directors = new HashSet<Director>();
            this.images = new HashSet<MovieImage>();
        }

        [Required]
        [StringLength(MovieValidations.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MovieValidations.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(MovieValidations.DescriptionMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MovieValidations.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [Range(MovieValidations.MinYear, MovieValidations.MaxYear)]
        public int Year { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Actor> Actors
        {
            get { return this.actors; }
            set { this.actors = value; }
        }

        public virtual ICollection<Director> Directors
        {
            get { return this.directors; }
            set { this.directors = value; }
        }

        public virtual ICollection<MovieImage> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
