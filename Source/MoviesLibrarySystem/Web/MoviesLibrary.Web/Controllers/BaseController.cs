namespace MoviesLibrary.Web.Controllers
{
    using System.Web.Mvc;

    using MoviesLibrary.Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}