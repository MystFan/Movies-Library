namespace MoviesLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class MovieLibraryImage : BaseModel<int>
    {
        [Required]
        [StringLength(ImageValidations.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ImageValidations.NameMinLength)]
        public string OriginalName { get; set; }

        [Required]
        [StringLength(ImageValidations.ExtensionMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ImageValidations.ExtensionMinLength)]
        public string Extension { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
