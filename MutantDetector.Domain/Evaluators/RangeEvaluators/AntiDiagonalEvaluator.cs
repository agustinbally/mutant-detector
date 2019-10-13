using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    /// <summary>
    /// Recorre diagonales invertidas de la matriz
    /// </summary>
    public class AntiDiagonalEvaluator : IRangeEvaluator
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
                    equalElementsCount = dna.Element(row, col) == dna.Element(row -1, col + 1)
                                       ? ++equalElementsCount
                                       : 0;

                    if (equalElementsCount == 3)
                    {
                        equalElementsCount = 0;
                        patternOccurrences++;
                        row = row - 1;
                        col = col + 1;
                    }

                    row = row - 1;
                    col = col + 1;
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
                    equalElementsCount = dna.Element(row, col) == dna.Element(row - 1, col + 1)
                                       ? ++equalElementsCount
                                       : 0;

                    if (equalElementsCount == 3)
                    {
                        equalElementsCount = 0;
                        patternOccurrences++;
                        row = row - 1;
                        col = col + 1;
                    }

                    row = row - 1;
                    col = col + 1;
                }
            }

            return patternOccurrences;
        }
    }
}
