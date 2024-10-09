using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hygie.Model
{
    public class Question
    {
        public int Id { get; set; }

        [JsonPropertyName("question")]
        public string Intitule { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string SousCategoryText { get; set; }

        [JsonPropertyName("reponses")]
        public List<Reponse> Reponses { get; set; }

    }


    public enum SousCatQuest
    {
        Boisson,
        Fruit,
        Graisse,
        Temps,
        Poisson,
        SourceProt,
        ProduitsLaitiers,
        Nutrition,
        Collations,
        Cuisine,
        ConsommationSel,
        Charcuterie,
        Viande,
        Eau,
        Alcool
    }
}
