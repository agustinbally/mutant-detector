using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    public class ColumnEvaluator : RangeEvaluatorBase, IRangeEvaluator
    {
        public int GetPatternOccurrences(HumanDna dna, int atMost)
        {
            var patternOccurrences = 0;
            var equalElementsCount = 0;

            for (int col = 0; col < dna.Length && patternOccurrences < atMost; col++, equalElementsCount = 0)
            {                
                for (int row = 0;
                    row < dna.Length - 1 && patternOccurrences < atMost;
                    row++)
                {
                    Compare(dna, ref patternOccurrences, ref equalElementsCount, ref row, ref col, 1, 0);                   
                }
            }

            return patternOccurrences;
        }
    }
}
