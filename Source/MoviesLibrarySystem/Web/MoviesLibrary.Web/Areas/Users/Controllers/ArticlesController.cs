namespace MoviesLibrary.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Article;

    public class ArticlesController : UsersBaseController
    {
        private IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var article = this.articlesService.GetById(id);

            ArticleViewModel model = new ArticleViewModel()
            {
                Title = article.Title,
                Content = article.Content,
                CreatedOn = article.CreatedOn,
                Id = article.Id,
                Comments = article.Comments.Select(c => c.Content),
                Images = article.Images.Select(a => a.Url).ToList()
            };

            return View(model);
        }
    }
}