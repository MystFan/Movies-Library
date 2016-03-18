namespace MoviesLibrary.Services.Data
{
    using System.Linq;

    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Models;
    using MoviesLibrary.Services.Data.Contracts;

    public class ActorsService : IActorsService
    {
        private IDbRepository<Actor> actors;

        public ActorsService(IDbRepository<Actor> actors)
        {
            this.actors = actors;
        }

        public Actor GetByName(string name)
        {
            var actor = this.actors
                .All()
                .FirstOrDefault(a => a.Name.ToLower() == name.ToLower());

            return actor;
        }
    }
}
