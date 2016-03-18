namespace MoviesLibrary.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using MoviesLibrary.Data.Common.Constants;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.Infrastructure.CustomFilters;

    public class RatingsController : UsersBaseController
    {
        private IRatingService ratingService;

        public RatingsController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult AddRating(int movieId, int ratingValue)
        {
            if (ratingValue < RatingValidations.MinRating)
            {
                ratingValue = RatingValidations.MinRating;
            }

            if (ratingValue > RatingValidations.MaxRating)
            {
                ratingValue = RatingValidations.MaxRating;
            }

            var userId = this.User.Identity.GetUserId();

            this.ratingService.AddRating(userId, movieId, ratingValue);

            var movieRating = this.ratingService.GetMovieRating(movieId);

            return this.Json(new { Count = movieRating });
        }
    }
}