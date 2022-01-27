using Microsoft.AspNetCore.Mvc;

namespace BackendExercise.Controllers
{
	public class Doctor : Controller
    {
        [HttpGet]
        public IActionResult Fewer()
        {
            ViewBag.Text = "State your body temperature to know if you have fewer.";
            return View();
        }

        [HttpPost]
        public IActionResult Fewer(double temperature)
        {
            
            ViewBag.Answer = Models.Methods.FewerControll(temperature);
            ViewBag.text = "You can check again if you have fewer!";
            return View();
        }
	}
}
