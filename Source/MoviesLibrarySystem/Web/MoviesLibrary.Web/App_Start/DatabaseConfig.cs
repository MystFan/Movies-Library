namespace MoviesLibrary.Web
{
    using System.Data.Entity;

    using MoviesLibrary.Data;
    using MoviesLibrary.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesLibraryDbContext, Configuration>());
            MoviesLibraryDbContext.Create().Database.Initialize(true);
        }
    }
}