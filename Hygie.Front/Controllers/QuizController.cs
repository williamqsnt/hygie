using Hygie.Back.Services;
using Hygie.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpPost]
        public async Task<IActionResult> PostResultQuiz(QuizCat quizCat, string valuesAnswers)
        {
            Quiz quiz = _quizService.GetQuiz(quizCat);
            List<string> recommandations = new List<string>();
            int[][] resultats = JsonSerializer.Deserialize<int[][]>(valuesAnswers);

            foreach (var answer in resultats)
            {
                if (answer[1] == 0)
                {
                    recommandations.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
            }

            return Json(recommandations);
        }

        [Route("/result")]
        public ActionResult GetResultQuiz(string valuesAnswers, QuizCat quizCat)
        {
            Quiz quiz = _quizService.GetQuiz(quizCat);
            List<string> recommandations = new List<string>();
            int[][] resultats = JsonSerializer.Deserialize<int[][]>(valuesAnswers);

            foreach (var answer in resultats)
            {
                if (answer[1] == 0)
                {
                    recommandations.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
            }

            return View(recommandations);
        }
    }
}
