namespace MoviesLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class MovieImage : BaseModel<int>
    {
        [Required]
        [StringLength(MovieImageValidations.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MovieImageValidations.NameMinLength)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(MovieImageValidations.ExtensionMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MovieImageValidations.ExtensionMinLength)]
        public string Extension { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public bool IsPoster { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
