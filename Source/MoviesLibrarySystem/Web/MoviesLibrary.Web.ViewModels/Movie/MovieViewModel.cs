namespace MoviesLibrary.Web.ViewModels.Movie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using MoviesLibrary.Common;
    using MoviesLibrary.Web.Infrastructure.Mappings;
    using MoviesLibrary.Web.ViewModels.Image;

    public class MovieViewModel : IMapFrom<MoviesLibrary.Models.Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ViewId
        {
            get
            {
                IdentifierProvider idProvider = new IdentifierProvider();
                return idProvider.EncodeId(this.Id);
            }
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public IEnumerable<string> Actors { get; set; }

        public IEnumerable<string> Directors { get; set; }

        public IEnumerable<MovieImageViewModel> Images { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<MoviesLibrary.Models.Movie, MovieViewModel>(this.GetType().Name)
                .ForMember(mv => mv.Genre, opt => opt.MapFrom(m => m.Genre.ToString()));

            configuration.CreateMap<MoviesLibrary.Models.Movie, MovieViewModel>(this.GetType().Name)
                .ForMember(mv => mv.Actors, opt => opt.MapFrom(m => m.Actors.Select(a => a.Name)));

            configuration.CreateMap<MoviesLibrary.Models.Movie, MovieViewModel>(this.GetType().Name)
                .ForMember(mv => mv.Directors, opt => opt.MapFrom(m => m.Directors.Select(d => d.Name)));
        }
    }
}
