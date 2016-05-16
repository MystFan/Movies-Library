﻿namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web;
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

            var lastId = this.articlesService.GetLastId();
            var paths = this.SaveImages(model.Images, "/App_Data/Images", lastId);
            this.articlesService.Add(model.Title, model.Content, paths);

            return this.RedirectToAction("All", "Articles", new { Area = "Users" });
        }

        private IEnumerable<string> SaveImages(IEnumerable<HttpPostedFileBase> files, string rootPath, int count)
        {
            List<string> paths = new List<string>();
            int foldersCount = ++count;
            string directoryName = ((foldersCount % 1000000)).ToString();
            string directory = Path.Combine(Server.MapPath("~" + rootPath), directoryName);
            bool exists = Directory.Exists(directory);

            if (files.Any(f => f != null))
            {
                while (exists)
                {
                    directoryName = ((++foldersCount % 1000000)).ToString();
                    directory = Path.Combine(Server.MapPath("~" + rootPath), directoryName);
                    exists = Directory.Exists(directory);
                }

                if (!exists)
                {
                    Directory.CreateDirectory(directory);
                }
            }
            else
            {
                return paths;
            }


            foreach (var file in files)
            {
                if (file != null)
                {
                    Image resizedImage = this.imageEditorService.ResizeImageFromStream(file.InputStream);
                    
                    string imageName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(directory, imageName);

                    resizedImage.Save(path);
                    paths.Add(rootPath + "/" + directoryName + "/" + file.FileName);
                }
            }

            return paths;
        }
    }
}