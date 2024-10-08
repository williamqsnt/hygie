using Hygie.Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hygie.Back.Services;
using Hygie.Model;

namespace Hygie.Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuizService _quizService;

        public HomeController(ILogger<HomeController> logger, QuizService quizService)
        {
            _logger = logger;
            _quizService = quizService;
        }

        public IActionResult Index()
        {
            Contenu content = _quizService.GetContenu();
            return View(content);
        }

        public IActionResult APropos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
