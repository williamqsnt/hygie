using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hygie.Model
{
    public class Reponse
    {
        [JsonPropertyName("contenu")]
        public string Contenu { get; set; }

        [JsonPropertyName("Score")]
        public int Score { get; set; }

        [JsonPropertyName("recommandation")]
        public string Recommandation { get; set; }
    }
}
