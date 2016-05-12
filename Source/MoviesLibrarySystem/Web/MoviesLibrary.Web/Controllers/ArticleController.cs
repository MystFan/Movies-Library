namespace MoviesLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Article;

    public class ArticleController : BaseController
    {
        public IArticlesService articlesService;

        public ArticleController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public ActionResult All()
        {
            return this.View();
        }

        public ActionResult GetArticles()
        {
            var articles = this.articlesService
                .GetAll()
                .ProjectTo<ArticleViewModel>()
                .ToList();

            return this.PartialView("_ArticlesListPartial", articles);
        }
    }
}