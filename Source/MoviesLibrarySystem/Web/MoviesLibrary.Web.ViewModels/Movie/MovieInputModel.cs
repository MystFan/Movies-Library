namespace MoviesLibrary.Web.ViewModels.Movie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Data.Common.Constants;
    using MoviesLibrary.Web.Infrastructure.CustomAttributes;
    using MoviesLibrary.Models;

    public class MovieInputModel
    {
        [Required]
        [StringLength(MovieValidations.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MovieValidations.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(MovieValidations.DescriptionMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = MovieValidations.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public int GenreType { get; set; }

        [Required]
        [Range(MovieValidations.MinYear, MovieValidations.MaxYear)]
        public int Year { get; set; }

        [Display(Name = "YouTube Video Id")]
        [MaxLength(MovieValidations.YouTubeVideoIdMaxLength, ErrorMessage = "YouTube video id cannot be longer than 100 characters")]
        public string YouTubeVideoId { get; set; }

        [Required]
        public int PosterIndex { get; set; }

        [FileExtension(FileExtensions = new string[] { ".png", ".jpg" })]
        [FileCount(MinCount = 1, MaxCount = 5)]
        [HttpFileContentLength(MinSize = ImageValidations.MinContentLength, MaxSize = ImageValidations.MaxContentLength)]
        public IEnumerable<HttpPostedFileBase> MovieImages { get; set; }

        [CollectionCount(MinCount = 1, MaxCount = 100)]
        public IEnumerable<string> Actors { get; set; }

        [CollectionCount(MinCount = 1, MaxCount = 5)]
        public IEnumerable<string> Directors { get; set; }
    }
}
