namespace MoviesLibrary.Services.Data.Contracts
{
    using MoviesLibrary.Models;

    public interface IActorsService : IService
    {
        Actor GetByName(string name);
    }
}
