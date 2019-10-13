using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Evaluators.RangeEvaluators;

namespace MutantDetector.Domain.Tests.ColumnEvaluatorTests
{
    public abstract class ColumnEvaluatorTests : RangeEvaluatorBaseTests
    {
        private ColumnEvaluator columnEvaluator;

        public ColumnEvaluatorTests()
        {
            columnEvaluator = new ColumnEvaluator();
        }

        protected override IRangeEvaluator RangeEvaluator => columnEvaluator;               
    }
}
