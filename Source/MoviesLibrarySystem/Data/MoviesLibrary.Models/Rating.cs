namespace MoviesLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class Rating : BaseModel<int>
    {
        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Range(RatingValidations.MinRating, RatingValidations.MaxRating)]
        public int Value { get; set; }
    }
}
