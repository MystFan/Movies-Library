using MoviesLibrary.Data.Repositories;
using MoviesLibrary.Models;
using MoviesLibrary.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Services.Data
{
    public class ArticleImagesService : IArticleImagesService
    {
        private IDbRepository<ArticleImage> articleImages;

        public ArticleImagesService(IDbRepository<ArticleImage> articleImages)
        {
            this.articleImages = articleImages;
        }

        public ArticleImage GetById(int id)
        {
            return this.articleImages.GetById(id);
        }
    }
}
