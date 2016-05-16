namespace MoviesLibrary.Models
{
    public class ArticleImage : MovieLibraryImage
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
