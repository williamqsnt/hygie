using Hygie.Back.Services;
using Hygie.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hygie.Front.Controllers
{
    [Route("quiz")]
    public class QuizController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuizService _quizService;

        public QuizController(ILogger<HomeController> logger, QuizService quizService)
        {
            _logger = logger;
            _quizService = quizService;
        }

        public ActionResult ShowQuiz(QuizCat quizCat)
        {
            Quiz quiz = _quizService.GetQuiz(quizCat);

            return View(quiz);
        }
    }
}
