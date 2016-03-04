namespace MoviesLibrary.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using MoviesLibrary.Web.Controllers;

    [Authorize(Roles = "Admin")]
    public abstract class AdminBaseController : BaseController
    {
    }
}