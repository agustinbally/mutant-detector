using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    /// <summary>
    /// Recorre diagonales de la matriz
    /// </summary>
    public class RowEvaluator : IRangeEvaluator
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
                    equalElementsCount = dna.Element(row, col) == dna.Element(row, col + 1)
                                       ? ++equalElementsCount
                                       : 0;

                    if (equalElementsCount == 3)
                    {
                        equalElementsCount = 0;
                        patternOccurrences++;
                        col++;
                    }
                }
            }

            return patternOccurrences;
        }
    }
}
