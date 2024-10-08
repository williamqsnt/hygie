using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hygie.Model
{
    public class Contenu
    {
        [JsonPropertyName("quiz")]
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
