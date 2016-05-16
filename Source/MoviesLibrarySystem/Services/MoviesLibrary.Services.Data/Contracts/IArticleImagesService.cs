namespace MoviesLibrary.Services.Data.Contracts
{
    using MoviesLibrary.Models;

    public interface IArticleImagesService : IService
    {
        ArticleImage GetById(int id);

        ArticleImage GetById(string viewId);
    }
}
