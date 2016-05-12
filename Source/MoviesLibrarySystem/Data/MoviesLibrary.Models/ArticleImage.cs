namespace MoviesLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class ArticleImage : BaseModel<int>
    {
        [Required]
        [StringLength(ImageValidations.UrlMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ImageValidations.UrlMinLength)]
        public string Url { get; set; }
    }
}
