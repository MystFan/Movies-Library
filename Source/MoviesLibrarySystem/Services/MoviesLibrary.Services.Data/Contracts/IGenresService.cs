namespace MoviesLibrary.Services.Data.Contracts
{
    using System.Collections.Generic;

    public interface IGenresService : IService
    {
        IList<string> GetAll();
    }
}
