using MoviesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Services.Data.Contracts
{
    public interface IArticleImagesService : IService
    {
        ArticleImage GetById(int id);
    }
}
