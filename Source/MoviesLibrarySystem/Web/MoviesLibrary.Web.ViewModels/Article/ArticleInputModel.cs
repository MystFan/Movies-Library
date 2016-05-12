namespace MoviesLibrary.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using MoviesLibrary.Data.Common.Constants;
    using MoviesLibrary.Web.Infrastructure.CustomAttributes;

    public class ArticleInputModel
    {
        [Required]
        [StringLength(ArticleValidations.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ArticleValidations.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleValidations.ContentMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ArticleValidations.ContentMaxLength)]
        public string Content { get; set; }

        [FileExtension(FileExtensions = new string[] { ".png", ".jpg" })]
        [FileCount(MinCount = 0, MaxCount = 5)]
        [HttpFileContentLength(MinSize = ImageValidations.MinContentLength, MaxSize = ImageValidations.MaxContentLength)]
        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}
