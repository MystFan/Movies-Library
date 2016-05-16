namespace MoviesLibrary.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using MoviesLibrary.Models;
    using MoviesLibrary.Data.Common.Contracts;

    public class MoviesLibraryDbContext : IdentityDbContext<User>
    {
        public MoviesLibraryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<MovieImage> MovieImages { get; set; }

        public virtual IDbSet<Actor> Actors { get; set; }

        public virtual IDbSet<Director> Directors { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<ArticleImage> ArticleImages { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static MoviesLibraryDbContext Create()
        {
            return new MoviesLibraryDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
