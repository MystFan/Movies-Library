namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class MoviesController : AdminBaseController
    {
        public ActionResult Add()
        {
            return this.View();
        }
    }
}