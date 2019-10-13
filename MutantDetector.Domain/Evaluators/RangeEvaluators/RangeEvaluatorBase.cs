using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Evaluators.RangeEvaluators
{
    public abstract class RangeEvaluatorBase
    {
        protected static void Compare(HumanDna dna,
          ref int patternOccurrences,
          ref int equalElementsCount,
          ref int row,
          ref int col,
          int rowStep,
          int colStep,
          bool doStep = false)
        {
            equalElementsCount = 
                dna.Element(row, col) == dna.Element(row + 1 * rowStep, col + 1 * colStep)
                    ? ++equalElementsCount
                    : 0;

            if (equalElementsCount == 3)
            {
                equalElementsCount = 0;
                patternOccurrences++;
                row = row + 1 * rowStep;
                col = col + 1 * colStep;
            }

            if (doStep)
            {
                row = row + 1 * rowStep;
                col = col + 1 * colStep;
            }            
        }
    }
}
