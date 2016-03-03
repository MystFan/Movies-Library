namespace MoviesLibrary.Web
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}