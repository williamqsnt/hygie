using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hygie.Model
{
    public class InputModel
    {
        [VectorType(15, 2)]  // Indique que l'entrée est un tableau de 15 lignes avec 2 colonnes
        public int[][] Features { get; set; }
    }

    public class Prediction
    {
        [VectorType(5)]  // Indique que la sortie est un vecteur de taille 5
        public float[] PredictedLabel { get; set; }
    }
}
