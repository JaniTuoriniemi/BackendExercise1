using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

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
        [HttpGet]
        public IActionResult GuessingGame()
        {
            int random;
            Random rand = new Random();
            random = rand.Next(1, 101);
            HttpContext.Session.SetInt32("random", Convert.ToInt32(random));
            HttpContext.Session.SetInt32("guesses", 0);

            ViewBag.Message = "The server has generated an number between 1 and 100. Guess which one";
            
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guess)
        {
              Int32 number = Convert.ToInt32(HttpContext.Session.GetInt32("guesses"));
              Int32  random = Convert.ToInt32(HttpContext.Session.GetInt32("random"));
           
            if (guess==random)
            {
                ViewBag.Message ="You guessed right. It took "+Convert.ToString(number+1)+" attempts.\n The game has been restarted with a new random number.";
                Random rand = new Random();
                random = rand.Next(1, 101);
                HttpContext.Session.SetInt32("random", Convert.ToInt32(random));
                HttpContext.Session.SetInt32("guesses", 0);
                
            }
            else if (guess>random)
            {
                ViewBag.Message = "You guessed a too high number. You have spend " + Convert.ToString(number+1) + " attempts.";
                HttpContext.Session.SetInt32("guesses", number + 1);
            }
            else
            {
                ViewBag.Message = "You guessed a too low number. You have spend " + Convert.ToString(number + 1) + " attempts.";
                HttpContext.Session.SetInt32("guesses", number + 1);
            }
            
            
            return View();
        }
    }
}
