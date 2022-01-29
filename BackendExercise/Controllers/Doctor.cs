using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult Fewer(double? temperature)
        {
            double temperature_value;
            if (temperature != null)
            {
                temperature_value = Convert.ToDouble(temperature);
                ViewBag.Answer = Models.Methods.FewerControll(temperature_value);
                ViewBag.text = "You can check again if you have fewer!";
            }

            return View();
        }
	}
}
