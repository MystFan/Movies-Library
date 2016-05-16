namespace MoviesLibrary.Services.Data
{
    using MoviesLibrary.Common;
    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class ArticleImagesService : IArticleImagesService
    {
        private IDbRepository<ArticleImage> articleImages;

        public ArticleImagesService(IDbRepository<ArticleImage> articleImages)
        {
            this.articleImages = articleImages;
        }

        public ArticleImage GetById(int id)
        {
            return this.articleImages.GetById(id);
        }

        public ArticleImage GetById(string viewId)
        {
            IdentifierProvider idProvider = new IdentifierProvider();
            int id = idProvider.DecodeId(viewId);
            var articleImage = this.GetById(id);

            return articleImage;
        }
    }
}
