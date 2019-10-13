using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities.Builders;
using Xunit;

namespace MutantDetector.Domain.Tests
{
    public abstract class RangeEvaluatorBaseTests
    {
        protected abstract IRangeEvaluator RangeEvaluator { get;  }

        protected void Evaluar(string[] dna, int cantidadEsperada, int cantidadMaximaBuscada = 100)
        {
            var humanDna = new HumanDnaBuilder().AddDna(dna).BuildHumanDna();

            var result = RangeEvaluator.GetPatternOccurrences(humanDna, cantidadMaximaBuscada);

            Assert.Equal(cantidadEsperada, result);            
        }
    }
}
