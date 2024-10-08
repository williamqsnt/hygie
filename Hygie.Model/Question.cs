using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hygie.Model
{
    public class Question
    {
        public int Id { get; set; }

        public string Intitule { get; set; }

        public List<Reponse> Reponses { get; set; }

    }
}
