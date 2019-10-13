using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    /// <summary>
    /// Recorre diagonales de la matriz
    /// </summary>
    public class RowEvaluator : RangeEvaluatorBase, IRangeEvaluator
    {
        public int GetPatternOccurrences(HumanDna dna, int atMost)
        {
            var patternOccurrences = 0;
            var equalElementsCount = 0;

            for (int row = 0; row < dna.Length && patternOccurrences < atMost; row++, equalElementsCount = 0)
            {                
                for (int col = 0;
                    col < dna.Length - 1 && patternOccurrences < atMost;
                    col++)
                {
                    Compare(dna, ref patternOccurrences, ref equalElementsCount, ref row, ref col, 0, 1);                    
                }
            }

            return patternOccurrences;
        }
    }
}
