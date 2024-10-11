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
            //String prediction = _quizService.PredictQuiz(quizCat, JsonSerializer.Deserialize<int[][]>(valuesAnswers));

            Quiz quiz = _quizService.GetQuiz(quizCat);
            List<string> recommandationsImportantes = new List<string>();
            List<string> recommandationsImportantesMoyennes = new List<string>();
            List<string> recommandationsMoyennes = new List<string>();
            List<string> recommandationsPresque = new List<string>();
            List<string> recommandationsFelicitation = new List<string>();

            // Variable pour stocker la somme des scores
            int scoreTotal = 0;

            int[][] resultats = JsonSerializer.Deserialize<int[][]>(valuesAnswers);

            foreach (var answer in resultats)
            {
                // Ajouter le score de la réponse à la somme totale
                scoreTotal += answer[1];

                if (answer[1] == 0)
                {
                    recommandationsImportantes.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
                if (answer[1] == 1)
                {
                    recommandationsImportantesMoyennes.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
                if (answer[1] == 2)
                {
                    recommandationsMoyennes.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
                if (answer[1] == 3)
                {
                    recommandationsPresque.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
                if (answer[1] == 4)
                {
                    recommandationsFelicitation.Add(quiz.Questions[answer[0]].Reponses.FirstOrDefault(r => r.Score == answer[1]).Recommandation);
                }
            }

            // Créer une liste finale à partir des autres listes
            List<string> recommandationsFinales = new List<string>();
            recommandationsFinales.AddRange(recommandationsImportantes);
            recommandationsFinales.AddRange(recommandationsImportantesMoyennes);
            recommandationsFinales.AddRange(recommandationsMoyennes);
            recommandationsFinales.AddRange(recommandationsPresque);
            recommandationsFinales.AddRange(recommandationsFelicitation);

            // Retourner les listes et la somme des scores cumulés
            return View(Tuple.Create(recommandationsImportantes, recommandationsImportantesMoyennes, recommandationsMoyennes, recommandationsPresque, recommandationsFelicitation, scoreTotal));
        }

    }
}