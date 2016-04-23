using MoviesLibrary.Data.Common;
using MoviesLibrary.Data.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Models
{
    public class Comment : BaseModel<int>
    {
        [Required]
        [StringLength(CommentValidations.ContentMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = CommentValidations.ContentMinLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User Author { get; set; }
    }
}
