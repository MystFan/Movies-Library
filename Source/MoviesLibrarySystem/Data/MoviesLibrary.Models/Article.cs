namespace MoviesLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MoviesLibrary.Data.Common;
    using MoviesLibrary.Data.Common.Constants;

    public class Article : BaseModel<int>
    {
        private ICollection<Comment> comments;

        public Article()
        {
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(ArticleValidations.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ArticleValidations.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ArticleValidations.ContentMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = ArticleValidations.ContentMinLength)]
        public string Content { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}
