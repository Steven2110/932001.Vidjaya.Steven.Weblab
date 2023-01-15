using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab12.Models;

namespace Lab12.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Manual() {
        if (Request.Method == "POST") {
            try {
                var calculatorModel = new CalcModel
                {
                    num1 = Int32.Parse(HttpContext.Request.Form["num1"]),
                    operation = HttpContext.Request.Form["operation"],
                    num2 = Int32.Parse(HttpContext.Request.Form["num2"])
                };

                ViewData["Result"] = calculatorModel.Calculate();
            }
            catch {
                ViewData["Result"] = "Invalid input";
            }

            return View("Result");
        }
        return View("Calculator");
    }

    [HttpGet]
    [ActionName("ManualWithSeparateHandlers")]
    public IActionResult ManualWithSeparateHandlersGet() {
        return View("Calculator");
    }

    [HttpPost]
    [ActionName("ManualWithSeparateHandlers")]
    public IActionResult ManualWithSeparateHandlersPost() {
        try {
            var calculatorModel = new CalcModel {
                num1 = Int32.Parse(HttpContext.Request.Form["num1"]),
                operation = HttpContext.Request.Form["operation"],
                num2 = Int32.Parse(HttpContext.Request.Form["num2"])
            };

            ViewData["Result"] = calculatorModel.Calculate();
        }
        catch {
            ViewData["Result"] = "Invalid input";
        }

        return View("Result");
    }

    [HttpGet]
    [ActionName("ModelBindingInParameters")]
    public IActionResult ModelBindingInParametersGet() {
        return View("Calculator");
    }

    [HttpPost]
    [ActionName("ModelBindingInParameters")]
    public IActionResult ModelBindingInParametersPost(int num1, string operation, int num2) {
        if (ModelState.IsValid) {
            var calculatorModel = new CalcModel {
                num1 = num1,
                num2 = num2,
                operation = operation
            };
            
            ViewData["Result"] = calculatorModel.CalculateResult();
        }
        else {
            ViewData["Result"] = "Invalid input";
        }
        return View("Result");
    }

    [HttpGet]
    [ActionName("ModelBindingInSeparateModel")]
    public IActionResult ModelBindingInSeparateModelGet() {
        return View("Calculator");
    }

    [HttpPost]
    [ActionName("ModelBindingInSeparateModel")]
    public IActionResult ModelBindingInSeparateModelPost(CalcModel model) {
        if (ModelState.IsValid) {
            ViewData["Result"] = model.CalculateResult();
        }
        else {
            ViewData["Result"] = "Invalid input";
        }

        return View("Result");
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
