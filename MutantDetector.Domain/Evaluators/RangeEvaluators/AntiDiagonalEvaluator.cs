using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    /// <summary>
    /// Recorre diagonales invertidas de la matriz
    /// </summary>
    public class AntiDiagonalEvaluator : RangeEvaluatorBase, IRangeEvaluator
    {
        public int GetPatternOccurrences(HumanDna dna, int atMost)
        {
            var patternOccurrences = 0;
            var equalElementsCount = 0;

            // recorro diagonales de la parte superior superior de la matriz y la diagonal secundaria
            for (var fixRow = 3; 
                fixRow <= dna.Length-1 && patternOccurrences < atMost; 
                fixRow++)
            {
                var row = fixRow;
                var col = 0;
                equalElementsCount = 0;

                while (row >= 1 && patternOccurrences < atMost)
                {
                    Compare(dna, ref patternOccurrences, ref equalElementsCount, ref row, ref col, -1 , 1, true);
                }
            }

            // recorro diagonales de la parte inferior de la matriz
            for (var fixCol = 1; 
                fixCol <= dna.Length - 3 && patternOccurrences < atMost; 
                fixCol++)
            {
                var row = dna.Length - 1;
                var col = fixCol;
                equalElementsCount = 0;

                while (col < dna.Length - 1 && patternOccurrences < atMost)
                {
                    Compare(dna, ref patternOccurrences, ref equalElementsCount, ref row, ref col, -1, 1, true);                   
                }
            }

            return patternOccurrences;
        }      
    }
}
