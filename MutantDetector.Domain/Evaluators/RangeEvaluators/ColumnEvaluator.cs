using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    public class ColumnEvaluator : IRangeEvaluator
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
                    equalElementsCount = dna.Element(row, col) == dna.Element(row + 1, col)
                                        ? ++equalElementsCount
                                        : 0;
                    
                    if  (equalElementsCount == 3)
                    {
                        equalElementsCount = 0;
                        patternOccurrences++;
                        row++;
                    }
                }
            }

            return patternOccurrences;
        }
    }
}
