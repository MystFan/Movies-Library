namespace MoviesLibrary.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using MoviesLibrary.Models;

    public interface IArticlesService : IService
    {
        IQueryable<Article> GetAll();

        IQueryable<Article> Get(int page, string title);

        void Add(string title, string content, IEnumerable<string> paths);

        Article GetById(int id);
    }
}
