namespace MoviesLibrary.Web.Infrastructure.CustomAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CollectionCount : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Collection must contain at least one item!";
        private const string RangeErrorMessage = "Collection count must be between {0} and {1}";

        public byte MinCount { get; set; }

        public byte MaxCount { get; set; }

        public override bool IsValid(object value)
        {
            var items = value as IEnumerable<object>;
            bool isValid = true;

            if (items != null)
            {
                if (!items.Any(i => i != null))
                {
                    this.ErrorMessage = this.ErrorMessage != null ? this.ErrorMessage : DefaultErrorMessage;
                    isValid = false;
                    return isValid;
                }

                if (this.MinCount == 0 && this.MaxCount == 0)
                {
                    return isValid;
                }

                int itemsCount = items.Count(i => i != null);

                if (itemsCount < this.MinCount || itemsCount > this.MaxCount)
                {
                    this.ErrorMessage = this.ErrorMessage != null ? this.ErrorMessage : string.Format(RangeErrorMessage, this.MinCount, this.MaxCount);
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
