using System;
using System.Runtime.InteropServices;
using Hygie.Model;

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
    }
}
