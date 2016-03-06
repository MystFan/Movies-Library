namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Web.ViewModels.Movie;

    public class MoviesController : AdminBaseController
    {
        private IGenresService genresData;

        public MoviesController(IGenresService genresData)
        {
            this.genresData = genresData;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieInputModel model, IEnumerable<HttpPostedFileBase> movieImages)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }



            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult All()
        {
            var genres = this.genresData.GetAll();
            return this.PartialView("_GenresDropdownPartial", genres);
        } 
    }
}