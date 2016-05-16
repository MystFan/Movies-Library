namespace MoviesLibrary.Web.Areas.Users.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Article;

    public class ArticlesController : UsersBaseController
    {
        private IArticlesService articlesService;
        private IArticleImagesService articleImagesService;

        public ArticlesController(IArticlesService articlesService, IArticleImagesService articleImagesService)
        {
            this.articlesService = articlesService;
            this.articleImagesService = articleImagesService;
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var article = this.articlesService.GetById(id);
            var articleViewModel = Mapper.Map<Article, ArticleViewModel>(article);

            return View(articleViewModel);
        }

        [AllowAnonymous]
        public ActionResult All(string title, int page = 1)
        {
            var articles = this.articlesService
               .Get(page, title)
               .ProjectTo<ArticleViewModel>()
               .ToList();

            int totalArticles = this.articlesService.GetAll().Count();
            int totalPages = (int)Math.Ceiling(totalArticles / (decimal)ArticleConstants.ArticlesListDefaultPageSize);

            ArticleListViewModel viewModel = new ArticleListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Articles = articles
            };

            return this.View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult GetArticleImage(string id)
        {
            var articleImg = this.articleImagesService.GetById(id);
            string imgExtension = articleImg.Extension;

            return new FileContentResult(articleImg.Content, "image/" + imgExtension);
        }
    }
}