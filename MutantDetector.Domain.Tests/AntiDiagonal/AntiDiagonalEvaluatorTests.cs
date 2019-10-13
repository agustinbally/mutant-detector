using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Evaluators.RangeEvaluators;

namespace MutantDetector.Domain.Tests.AntiDiagonalTests
{
    public abstract class AntiDiagonalEvaluatorTests : RangeEvaluatorBaseTests
    {
        private AntiDiagonalEvaluator antiDiagonalEvaluator;

        public AntiDiagonalEvaluatorTests()
        {
            antiDiagonalEvaluator = new AntiDiagonalEvaluator();
        }

        protected override IRangeEvaluator RangeEvaluator => antiDiagonalEvaluator;
    }
}
