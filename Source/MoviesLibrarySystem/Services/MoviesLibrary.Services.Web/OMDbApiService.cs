namespace MoviesLibrary.Services.Web
{
    using System.Net;

    using MoviesLibrary.Services.Web.Contracts;
    using MoviesLibrary.Services.Web.Helpers;
    using Newtonsoft.Json;

    public class OMDbApiService : IMovieAdditionalInfoApiService
    {
        public MovieInfo GetMovie(string title, int year)
        {
            WebClient webClient = new WebClient();
            string url = string.Format("http://www.omdbapi.com/?t={0}&y={1}&plot=full&r=json", title, year);
            string entry = webClient.DownloadString(url);
            var result = JsonConvert.DeserializeObject<MovieInfo>(entry);

            return result;
        }
    }
}
