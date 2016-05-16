namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Services.Web.Contracts;
    using MoviesLibrary.Web.ViewModels.Article;

    public class ArticlesController : AdminBaseController
    {
        private IArticlesService articlesService;
        private IImageEditorService imageEditorService;

        public ArticlesController(IArticlesService articlesService, IImageEditorService imageEditorService)
        {
            this.articlesService = articlesService;
            this.imageEditorService = imageEditorService;
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.articlesService.Add(model.Title, model.Content, model.Images);

            return this.RedirectToAction("All", "Articles", new { Area = "Users" });
        }
    }
}