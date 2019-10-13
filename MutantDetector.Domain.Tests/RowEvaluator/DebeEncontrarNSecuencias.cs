using Xunit;

namespace MutantDetector.Domain.Tests.RowEvaluatorTests
{
    public class DebeEncontrarNSecuencias : RowEvaluatorTests
    {
        [Fact]
        public void CuandoLiminoLaCantidadMaximaComoN()
        {
            var dna = new[] {
                    "AAAAAA",
                    "AAAAAA",
                    "AAAAAA",
                    "AAAAAA",
                    "AAAAAA",
                    "AAAAAA"
                };

            Evaluar(dna, 1, 1);
            Evaluar(dna, 2, 2);
            Evaluar(dna, 3, 3);
            Evaluar(dna, 4, 4);
            Evaluar(dna, 5, 5);
        }
    }
}
