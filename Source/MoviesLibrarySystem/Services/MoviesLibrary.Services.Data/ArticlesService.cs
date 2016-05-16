namespace MoviesLibrary.Services.Data
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web;

    using MoviesLibrary.Common.Globals;
    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Services.Web;

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
            var articles = this.GetAll()
                    .OrderByDescending(m => m.CreatedOn)
                    .Skip((page - 1) * ArticleConstants.ArticlesListDefaultPageSize)
                    .Take(ArticleConstants.ArticlesListDefaultPageSize);

            return articles;
        }

        public void Add(string title, string content, IEnumerable<HttpPostedFileBase> images)
        {
            var article = new Article()
            {
                Title = title,
                Content = content,
                Images = this.HttpFileToArticleImage(images)
            };

            this.articles.Add(article);
            this.articles.SaveChanges();
        }

        public Article GetById(int id)
        {
            var article = this.articles.GetById(id);
            return article;
        }

        private List<ArticleImage> HttpFileToArticleImage(IEnumerable<HttpPostedFileBase> images)
        {
            List<ArticleImage> filesDataResult = new List<ArticleImage>();

            foreach (var image in images)
            {
                if (image == null)
                {
                    continue;
                }

                ArticleImage articleImage = new ArticleImage();
                articleImage.OriginalName = image.FileName;
                articleImage.Extension = Path.GetExtension(image.FileName);

                ImageEditorService editor = new ImageEditorService();
                var resizedImage = editor.ResizeImageFromStream(image.InputStream);
                ImageFormat format = null;
                switch (articleImage.Extension)
                {
                    case ".jpg": format = ImageFormat.Jpeg; break;
                    case ".png": format = ImageFormat.Png; break;
                    default:
                        break;
                }

                articleImage.Content = this.ImageToByteArray(resizedImage, format);
                filesDataResult.Add(articleImage);
            }

            return filesDataResult;
        }

        private byte[] ImageToByteArray(Image image, ImageFormat format)
        {
            using (var memoryStrem = new MemoryStream())
            {
                image.Save(memoryStrem, format);
                return memoryStrem.ToArray();
            }
        }
    }
}
