namespace MoviesLibrary.Web.ViewModels.Article
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using MoviesLibrary.Web.Infrastructure.Mappings;
    using MoviesLibrary.Web.ViewModels.Image;

    public class ArticleViewModel : IMapFrom<MoviesLibrary.Models.Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public IList<ArticleImageViewModel> Images { get; set; }

        public IEnumerable<string> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<MoviesLibrary.Models.Article, ArticleViewModel>(this.GetType().Name)
                .ForMember(av => av.Images, opt => opt.MapFrom(a => a.Images.Select(i => new ArticleImageViewModel() { Id = i.Id })));

            configuration.CreateMap<MoviesLibrary.Models.Article, ArticleViewModel>(this.GetType().Name)
                .ForMember(av => av.Comments, opt => opt.MapFrom(a => a.Comments.Select(c => c.Content)));
        }
    }
}
