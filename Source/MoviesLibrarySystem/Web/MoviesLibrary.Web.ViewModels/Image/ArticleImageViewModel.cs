using MoviesLibrary.Models;
using MoviesLibrary.Web.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Web.ViewModels.Image
{
    public class ArticleImageViewModel : IMapFrom<ArticleImage>
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }
}
