using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Hygie.Model
{
    public class Quiz
    {
        [JsonPropertyName("category")]
        public string TextCategory { get; set; }
        public QuizCat Category
        {
            get
            {
                if(TextCategory != null)
                {
                    switch (TextCategory)
                    {
                        case "Alimentation":
                            return QuizCat.Alimentation;
                        case "ActivitePhysique":
                            return QuizCat.ActivitePhysique;
                        case "Sommeil":
                            return QuizCat.Sommeil;
                        case "ConsommationSubstances":
                            return QuizCat.Consommation;
                        case "Total":
                            return QuizCat.Total;
                        case "SanteMentale":
                            return QuizCat.SanteMentale;
                        default:
                            return QuizCat.Total;
                    }
                }
                else
                    return QuizCat.Total;
            }
            set
            {

            }
        }

        [JsonPropertyName("questions")]
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    public enum QuizCat
    {
        [Description("Alimentation")]
        Alimentation,
        [Description("Activite Physique")]
        ActivitePhysique,
        [Description("Sommeil et Temps d'écran")]
        Sommeil,
        [Description("Consommation et Addiction")]
        Consommation,
        [Description("Global")]
        Total,
        [Description("Santé Mentale")]
        SanteMentale
    }
}
