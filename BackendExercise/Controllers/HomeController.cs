
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendExercise.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {    
            ViewBag.Title="Index";
            ViewBag.Page = "/Index";
            return View(); }
        
        public IActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Page = "/home/About";

            return View(); }
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Page = "/home/Contact";
            return View();
        }
        public IActionResult Projects()
        {
            ViewBag.Title = "Projects";
            ViewBag.Page = "/home/Projects";
            return View();
        }

    }
}
