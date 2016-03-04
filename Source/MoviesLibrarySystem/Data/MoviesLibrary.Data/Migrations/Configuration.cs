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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleName = "Admin";
            IdentityResult roleResult;

            if (!roleManager.RoleExists(roleName))
            {
                PasswordHasher hasher = new PasswordHasher();
                var userManager = new UserManager<User>(new UserStore<User>(context));

                roleResult = roleManager.Create(new IdentityRole(roleName));
                var admin = new User
                {
                    Email = "TodorDimitrov@gmail.com",
                    PasswordHash = hasher.HashPassword("todor.OneMoment1984"),
                    UserName = "TodorDimitrov@gmail.com"
                };

                context.Users.Add(admin);
                context.SaveChanges();
                userManager.UpdateSecurityStamp(admin.Id);

                userManager.AddToRole(admin.Id, roleName);
            }
        }
    }
}
