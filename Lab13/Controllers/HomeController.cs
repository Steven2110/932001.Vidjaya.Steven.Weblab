using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab13.Models;

namespace Lab13.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() {
        return View();
    }

    static readonly QuizModel quiz = new QuizModel();

    public IActionResult Quiz() {
        quiz.results = new List<string>();
        quiz.questionCount = 0;
        quiz.correctAnswerCount = 0;
        quiz.generateQuestion();
        ViewBag.Question = quiz.question;
        return View();
    }

    public IActionResult Result() {
        ViewBag.RightAnswersCount = quiz.correctAnswerCount;
        ViewBag.AnswersCount = quiz.questionCount;
        ViewBag.Results = quiz.results;
        return View();
    }

    [HttpPost]
    public IActionResult NextQuestion(int answer) {
        quiz.GetResult(answer);
        quiz.generateQuestion();
        ViewBag.Question = quiz.question;
        return View("Quiz");
    }

    public IActionResult Finish(int answer) {
        quiz.GetResult(answer);
        ViewBag.CorrectAnswerCount = quiz.correctAnswerCount;
        ViewBag.QuestionCount = quiz.questionCount;
        ViewBag.Results = quiz.results;
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
