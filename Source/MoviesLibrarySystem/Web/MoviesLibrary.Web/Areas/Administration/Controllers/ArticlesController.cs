namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Article;

    public class ArticlesController : AdminBaseController
    {
        private IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
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

            var articlesCount = this.articlesService.GetAll().Count();
            var paths = this.SaveImages(model.Images, "/Images", articlesCount);
            this.articlesService.Add(model.Title, model.Content, paths);

            return this.RedirectToAction("Index", "Home", new { Area = string.Empty });
        }

        private IEnumerable<string> SaveImages(IEnumerable<HttpPostedFileBase> files, string rootPath, int count)
        {
            List<string> paths = new List<string>();
            count++;
            string directoryName = ((count % 1000000)).ToString();
            foreach (var file in files)
            {
                if (file != null)
                {
                    string directory = Path.Combine(Server.MapPath(rootPath), directoryName);
                    bool exists = Directory.Exists(directory);

                    if (!exists)
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string imageName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(directory, imageName);

                    file.SaveAs(path);
                    paths.Add(rootPath + "/" + directoryName + "/" + file.FileName);
                }
            }

            return paths;
        }
    }
}