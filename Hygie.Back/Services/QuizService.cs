using System;
using System.Runtime.InteropServices;
using Hygie.Model;
using Keras;
using Microsoft.ML;
using Numpy;

namespace Hygie.Back.Services
{   
    public class QuizService
    {
        public QuizService() { }

        public Contenu GetContenu()
        {
            string pathJson;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                pathJson = "..\\Hygie.Back\\Data\\questions.json"; // Chemin pour Windows
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                pathJson = "../Hygie.Back/Data/questions.json"; // Chemin pour macOS
            }
            else
            {
                throw new PlatformNotSupportedException("Unsupported platform.");
            }

            string json = System.IO.File.ReadAllText(pathJson);
            Contenu contenu = System.Text.Json.JsonSerializer.Deserialize<Contenu>(json);

            return contenu;
        }

        public Quiz GetQuiz(QuizCat quizCat)
        {
            Contenu contenu = GetContenu();

            Quiz quiz = contenu.Quizzes.Find(q => q.Category == quizCat);

            return quiz;
        }

        public string PredictQuiz(QuizCat quizCat, int[][] resultats)
        {
            MLContext mlContext = new MLContext();
            DataViewSchema modelSchema;
            string modelPath = Path.GetFullPath("..\\Hygie.Back\\Data\\saved_model.zip");
            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<InputModel, Prediction>(trainedModel);

            var inputModel = new InputModel
            {
                Features = resultats
            };

            var prediction = predictionEngine.Predict(inputModel);
            List<string> celebrities = new List<string> { "Gerard Depardieu", "Homer Simpson", "Kad Merad", "Thomas Pesquet", "Tibo InShape" };

            var maxIndex = prediction.PredictedLabel.ToList().IndexOf(prediction.PredictedLabel.Max());

            return celebrities[maxIndex];
        }

    }
}
