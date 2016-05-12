namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MoviesLibrary.Web.ViewModels.Article;

    public class ArticlesController : AdminBaseController
    {
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

            return this.RedirectToAction("Index", "Home", new { Area = string.Empty });
        }
    }
}