using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    public class MainDiagonalEvaluator : RangeEvaluatorBase, IRangeEvaluator
    {
        public int GetPatternOccurrences(HumanDna dna, int atMost)
        {
            var patternOccurrences = 0;
            var equalElementsCount = 0;

            // recorro diagonales de la parte inferior de la matriz y la diagonal primaria
            for (var fixRow = 0; 
                fixRow <= dna.Length - 3 && patternOccurrences < atMost; 
                fixRow++)
            {
                var row = fixRow;
                var col = 0;
                equalElementsCount = 0;

                while (row < dna.Length - 1 && patternOccurrences < atMost)
                {
                    Compare(dna, ref patternOccurrences, ref equalElementsCount, ref row, ref col, 1, 1, true);                    
                }
            }

            // recorro diagonales de la parte superior de la matriz 
            for (var fixCol = 1; 
                fixCol <= dna.Length - 3 && patternOccurrences < atMost; 
                fixCol++)
            {
                var row = 0;
                var col = fixCol;
                equalElementsCount = 0;

                while (col < dna.Length - 1 && patternOccurrences < atMost)
                {
                    Compare(dna, ref patternOccurrences, ref equalElementsCount, ref row, ref col, 1, 1, true);
                }
            }

            return patternOccurrences;
        }
    }
}
