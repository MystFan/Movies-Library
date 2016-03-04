namespace MoviesLibrary.Data.Migrations
{
    using System.Configuration;
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MoviesLibrary.Models;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesLibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesLibraryDbContext context)
        {
        }
    }
}
