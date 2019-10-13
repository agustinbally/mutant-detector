using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Evaluators.RangeEvaluators;

namespace MutantDetector.Domain.Tests.MainDiagonalTests
{

    public abstract class MainDiagonalEvaluatorTests : RangeEvaluatorBaseTests
    {
        private MainDiagonalEvaluator mainDiagonalEvaluator;

        public MainDiagonalEvaluatorTests()
        {
            mainDiagonalEvaluator = new MainDiagonalEvaluator();
        }

        protected override IRangeEvaluator RangeEvaluator => mainDiagonalEvaluator;            
    }
}
