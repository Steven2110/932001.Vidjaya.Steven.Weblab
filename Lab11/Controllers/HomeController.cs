using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab11.Models;

namespace Lab11.Controllers
{
    public class HomeController : Controller
    {
        private  Random r = new Random();
        public  int num1;
        public  int num2;
        public string add;
        public string sub;
        public string mult;
        public string div;

        public HomeController()
        {
            num1 = r.Next(0, 100);
            num2 = r.Next(0, 100);
            add = $"{num1} + {num2} = {num1 + num2}";
            sub = $"{num1} - {num2} = {num1 - num2}";
            mult = $"{num1} * {num2} = {num1 * num2}";
            if (num2 == 0)
            {
                div = $"{num1} / {num2} = Деление на ноль";
            }
            else
            {
                div = $"{num1} / {num2} = {(double)num1 / num2}";
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassUsingModel()
        {
            var calcModel = new CalcModel(num1, num2, add, sub, mult, div);
            return View(calcModel);
        }

        public IActionResult PassUsingViewData()
        {
            ViewData["num1"] = num1;
            ViewData["num2"] = num2;
            ViewData["add"] = add;
            ViewData["sub"] = sub;
            ViewData["mult"] = mult;
            ViewData["div"] = div;
            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            ViewBag.num1 = num1;
            ViewBag.num2 = num2;
            ViewBag.add = add;
            ViewBag.sub = sub;
            ViewBag.mult = mult;
            ViewBag.div = div;
            return View();
        }

        public IActionResult AccessServiceDirectly()
        {
            return View(this);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}