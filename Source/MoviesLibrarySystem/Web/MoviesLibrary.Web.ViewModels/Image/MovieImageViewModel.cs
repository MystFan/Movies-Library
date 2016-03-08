namespace MoviesLibrary.Web.ViewModels.Image
{
    using MoviesLibrary.Models;
    using MoviesLibrary.Web.Infrastructure.Mappings;
    using MoviesLibrary.Common;

    public class MovieImageViewModel : IMapFrom<MovieImage>
    {
        public int Id { get; set; }

        public string ViewId
        {
            get
            {
                IdentifierProvider idProvider = new IdentifierProvider();
                return idProvider.EncodeId(this.Id);
            }
        }

        public bool IsCover { get; set; }
    }
}
