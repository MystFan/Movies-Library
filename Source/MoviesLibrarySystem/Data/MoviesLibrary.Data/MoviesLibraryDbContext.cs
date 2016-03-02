namespace MoviesLibrary.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MoviesLibrary.Models;

    public class MoviesLibraryDbContext : IdentityDbContext<User>
    {
        public MoviesLibraryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MoviesLibraryDbContext Create()
        {
            return new MoviesLibraryDbContext();
        }
    }
}
