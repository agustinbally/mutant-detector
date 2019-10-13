using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Evaluators.RangeEvaluators;

namespace MutantDetector.Domain.Tests.RowEvaluatorTests
{
    public abstract class RowEvaluatorTests : RangeEvaluatorBaseTests
    {
        private RowEvaluator rowEvaluator;

        public RowEvaluatorTests()
        {
            rowEvaluator = new RowEvaluator();
        }

        protected override IRangeEvaluator RangeEvaluator => rowEvaluator; 
    }
}
