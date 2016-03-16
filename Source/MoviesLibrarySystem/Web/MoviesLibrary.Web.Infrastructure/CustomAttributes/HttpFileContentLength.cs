namespace MoviesLibrary.Web.Infrastructure.CustomAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class HttpFileContentLength : ValidationAttribute
    {
        private const string DefaultErrorMessage = "File is too large!";
        private const string RangeErrorMessage = "The file size exceeds the limit allowed and cannot be saved! Size must be between {0} and {1} Kb!";

        public int MinSize { get; set; }

        public int MaxSize { get; set; }

        public override bool IsValid(object value)
        {
            var files = value as IEnumerable<HttpPostedFileBase>;
            bool isValid = true;

            if (files != null)
            {
                if (!files.Any(i => i != null))
                {
                    this.ErrorMessage = this.ErrorMessage != null ? this.ErrorMessage : DefaultErrorMessage;
                    isValid = false;
                    return isValid;
                }

                if (this.MinSize == 0 && this.MaxSize == 0)
                {
                    return isValid;
                }

                foreach (var file in files)
                {
                    if (file.ContentLength < this.MinSize || file.ContentLength > this.MaxSize)
                    {
                        isValid = false;
                        this.ErrorMessage = this.ErrorMessage != null ? this.ErrorMessage : RangeErrorMessage;
                        return isValid;
                    }
                }
            }

            return isValid;
        }
    }
}
