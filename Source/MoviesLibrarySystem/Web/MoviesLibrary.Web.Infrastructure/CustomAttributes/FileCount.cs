namespace MoviesLibrary.Web.Infrastructure.CustomAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FileCount : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Files collection must contain at least one file!";
        private const string RangeErrorMessage = "Files collection count must be between {0} and {1}";

        public int MinCount { get; set; }

        public int MaxCount { get; set; }

        public override bool IsValid(object value)
        {
            var files = value as IEnumerable<HttpPostedFileBase>;
            bool isValid = true;

            if (this.MinCount == 0 && this.MaxCount == 0)
            {
                return isValid;
            }

            if (files != null)
            {
                int filesCount = files.Count(i => i != null);

                if (filesCount < this.MinCount || filesCount > this.MaxCount)
                {
                    this.ErrorMessage = this.ErrorMessage != null ? this.ErrorMessage : string.Format(RangeErrorMessage, this.MinCount, this.MaxCount);
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
