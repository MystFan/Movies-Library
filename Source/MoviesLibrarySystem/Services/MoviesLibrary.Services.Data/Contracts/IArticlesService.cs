namespace MoviesLibrary.Services.Data.Contracts
{
    using System.Linq;

    using MoviesLibrary.Models;

    public interface IArticlesService : IService
    {
        IQueryable<Article> GetAll();

        IQueryable<Article> Get(int page, string title);
    }
}
