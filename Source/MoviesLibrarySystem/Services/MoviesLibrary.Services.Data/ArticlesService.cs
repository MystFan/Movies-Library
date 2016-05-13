namespace MoviesLibrary.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class ArticlesService : IArticlesService
    {
        private IDbRepository<Article> articles;

        public ArticlesService(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public IQueryable<Article> Get(int page, string title)
        {
            var articles = this.GetAll();
            return articles;
        }

        public void Add(string title, string content, IEnumerable<string> paths)
        {
            var article = new Article()
            {
                Title = title,
                Content = content,
                Images = paths.Select(imgPath => new ArticleImage() { Url = imgPath }).ToList()
            };

            this.articles.Add(article);
            this.articles.SaveChanges();
        }


        public Article GetById(int id)
        {
            var article = this.articles.GetById(id);
            return article;
        }
    }
}
