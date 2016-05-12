namespace MoviesLibrary.Web.Infrastructure.CustomAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Web;

    public class FileExtension : ValidationAttribute
    {
        private const string DefaultErrorMessage = "File is not in a supported format.";

        public string[] FileExtensions { get; set; }

        public override bool IsValid(object value)
        {
            var files = value as IEnumerable<HttpPostedFileBase>;
            bool isValid = true;

            if (this.FileExtensions.Length == 0)
            {
                return isValid;
            }
          
            if (files != null && this.FileExtensions.Length > 0)
            {
                foreach (var file in files)
                {
                    if (file == null)
                    {
                        continue;
                    }

                    string fileExtension = Path.GetExtension(file.FileName);

                    if (!this.FileExtensions.Contains(fileExtension))
                    {
                        this.ErrorMessage = this.ErrorMessage != null ? this.ErrorMessage : DefaultErrorMessage;
                        isValid = false;
                    }
                }
            }

            return isValid;
        }
    }
}
