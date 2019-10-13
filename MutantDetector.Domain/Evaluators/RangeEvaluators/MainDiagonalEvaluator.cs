using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    public class MainDiagonalEvaluator : IRangeEvaluator
    {
        public int GetPatternOccurrences(HumanDna dna, int atMost)
        {
            var patternOccurrences = 0;
            var equalElementsCount = 0;

            // recorro diagonales de la parte inferior de la matriz y la diagonal primaria
            for (var fixRow = 0; 
                fixRow <= dna.Length - 3 && patternOccurrences < atMost; 
                fixRow++, equalElementsCount = 0)
            {
                var row = fixRow;
                var col = 0;
                equalElementsCount = 0;

                while (row < dna.Length - 1 && patternOccurrences < atMost)
                {
                    equalElementsCount = dna.Element(row, col) == dna.Element(row + 1, col + 1)
                                       ? ++equalElementsCount
                                       : 0;

                    if (equalElementsCount == 3)
                    {
                        equalElementsCount = 0;
                        patternOccurrences++;
                        row = row + 1;
                        col = col + 1;
                    }

                    row = row + 1;
                    col = col + 1;
                }
            }

            // recorro diagonales de la parte superior de la matriz 
            for (var fixCol = 1; 
                fixCol <= dna.Length - 3 && patternOccurrences < atMost; 
                fixCol++, equalElementsCount = 0)
            {
                var row = 0;
                var col = fixCol;
                equalElementsCount = 0;

                while (col < dna.Length - 1 && patternOccurrences < atMost)
                {
                    equalElementsCount = dna.Element(row, col) == dna.Element(row + 1, col + 1)
                                       ? ++equalElementsCount
                                       : 0;

                    if (equalElementsCount == 3)
                    {
                        equalElementsCount = 0;
                        patternOccurrences++;
                        row = row + 1;
                        col = col + 1;
                    }

                    row = row + 1;
                    col = col + 1;
                }
            }

            return patternOccurrences;
        }
    }
}
