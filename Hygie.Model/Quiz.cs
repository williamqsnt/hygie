﻿using System.ComponentModel;
using System.Reflection;
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
                if (TextCategory != null)
                {
                    switch (TextCategory)
                    {
                        case "Alimentation":
                            return QuizCat.Alimentation;
                        case "Activite Sportive":
                            return QuizCat.ActivitePhysique;
                        case "Sommeil":
                            return QuizCat.Sommeil;
                        case "Consommation et Addiction":
                            return QuizCat.Consommation;
                        case "Global":
                            return QuizCat.Total;
                        case "Santé Mentale":
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
                // Optionnel : Ajoutez une logique ici si nécessaire
            }
        }

        public string GetCategoryDescription()
        {
            return GetEnumDescription(Category);
        }

        [JsonPropertyName("questions")]
        public List<Question> Questions { get; set; } = new List<Question>();

        private string GetEnumDescription(QuizCat category)
        {
            FieldInfo field = category.GetType().GetField(category.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : category.ToString();
        }
    }

    public enum QuizCat
    {
        [Description("Alimentation")]
        Alimentation,
        [Description("Activite Sportive")]
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
