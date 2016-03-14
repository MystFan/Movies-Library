namespace MoviesLibrary.Web.ViewModels.Movie
{
    using MoviesLibrary.Common;
    using MoviesLibrary.Web.Infrastructure.Mappings;

    public class MovieSearchResultViewModel : IMapFrom<MoviesLibrary.Models.Movie>, IHaveCustomMappings
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

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<MoviesLibrary.Models.Movie, MovieSearchResultViewModel>(this.GetType().Name)
                .ForMember(mv => mv.Genre, opt => opt.MapFrom(m => m.Genre.ToString()));
        }
    }
}
