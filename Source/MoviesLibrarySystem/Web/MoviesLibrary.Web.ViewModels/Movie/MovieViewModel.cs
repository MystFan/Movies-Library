namespace MoviesLibrary.Web.ViewModels.Movie
{
    using System;

    using AutoMapper;
    using MoviesLibrary.Web.Infrastructure.Mappings;

    public class MovieViewModel : IMapFrom<MoviesLibrary.Models.Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<MoviesLibrary.Models.Movie, MovieViewModel>(this.GetType().Name)
                .ForMember(mv => mv.Genre, opt => opt.MapFrom(m => m.Genre.ToString()));
        }
    }
}
