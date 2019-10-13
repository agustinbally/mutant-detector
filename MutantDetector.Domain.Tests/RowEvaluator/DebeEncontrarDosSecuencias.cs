using Xunit;

namespace MutantDetector.Domain.Tests.RowEvaluatorTests
{
    public class DebeEncontrarDosSecuencias : RowEvaluatorTests
    {
        [Fact]
        public void CuandoHayAlMenosOchoConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "CCAATGGC",
                    "TTACACCT",
                    "AAAAAAAA",
                    "AAGCCATA",
                    "TTACCGCT",
                    "TTCGTGTT",
                    "CCAATGGC"
                };

            Evaluar(dna, 2);
        }

        [Fact]
        public void CuandoHayDosSecuenciasEnDistintasFilas()
        {
            var dna = new[] {
                    "TTTTACTG",
                    "AAAATGGC",
                    "TTACACCT",
                    "AATTACCA",
                    "AAGCCATA",
                    "TTACCGCT",
                    "TTCGTGTT",
                    "CCAATGGC"
                };

            Evaluar(dna, 2);
        }
    }    
}
