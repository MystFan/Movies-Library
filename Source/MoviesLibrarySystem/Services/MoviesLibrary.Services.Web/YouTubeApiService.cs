namespace MoviesLibrary.Services.Web
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using Google.Apis.YouTube.v3;
    using MoviesLibrary.Services.Web.Helpers;

    public class YouTubeApiService
    {
        public static YouTubeService YouTubeService = Auth();

        private static YouTubeService Auth()
        {
            UserCredential credentionals;
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("/") + "client_secret_58321505165-4709percnv8b6vj3ltntkufhoso0u4jk.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                var secrets = GoogleClientSecrets.Load(fs).Secrets;
                var scope = new[] { YouTubeService.Scope.YoutubeReadonly };
                var username = "Web client 1";
                var fileDataStore = new FileDataStore("YouTubeAPI");
                credentionals = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scope, username, CancellationToken.None, fileDataStore).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentionals,
                ApplicationName = "YouTubeAPI"
            });

            return service;
        }

        public YouTubeVideo GetVideoById(string videoId)
        {
            var requestVideo = YouTubeService.Videos.List("snippet");// type of request - snippet
            requestVideo.Id = videoId;

            var video = new YouTubeVideo();
            video.Id = videoId;

            var response = requestVideo.Execute();
            if (response.Items.Count > 0)
            {
                video.Title = response.Items.FirstOrDefault().Snippet.Title;
                video.Description = response.Items.FirstOrDefault().Snippet.Description;
                video.PublishedDate = response.Items.FirstOrDefault().Snippet.PublishedAt.Value;
            }

            return video;
        }
    }
}