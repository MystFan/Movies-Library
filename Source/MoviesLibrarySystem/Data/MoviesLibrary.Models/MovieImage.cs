namespace MoviesLibrary.Models
{
    public class MovieImage : MovieLibraryImage
    {
        public bool IsCover { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
