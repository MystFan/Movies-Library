namespace MoviesLibrary.Services.Web.Contracts
{
    using MoviesLibrary.Services.Web.Helpers;
    using System.Threading.Tasks;

    public interface IVideoApiService
    {
        MovieVideo GetVideoById(string videoId);

        string GetVideoTitle(string videoId);
    }
}
