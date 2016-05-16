namespace MoviesLibrary.Web.ViewModels.Image
{
    using MoviesLibrary.Common;
    using MoviesLibrary.Models;
    using MoviesLibrary.Web.Infrastructure.Mappings;

    public class ArticleImageViewModel : IMapFrom<ArticleImage>
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
    }
}
