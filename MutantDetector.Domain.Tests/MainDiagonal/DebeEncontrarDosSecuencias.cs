using Xunit;

namespace MutantDetector.Domain.Tests.MainDiagonalTests
{
    public class DebeEncontrarDosSecuencias : MainDiagonalEvaluatorTests
    {
        [Fact]
        public void CuandoHayAlMenosOchoConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "CTAATGGC",
                    "TTTCACCT",
                    "TTCTTGTT",
                    "AAGCTATA",
                    "TTACCTCT",
                    "TTCGTGTT",
                    "CCAATGGT"
                };

            Evaluar(dna, 2);
        }

        [Fact]
        public void CuandoHayDosSecuenciasEnDistintasDiagonals()
        {
            // ultimas inferior y superior
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "AGATCA",
                    "ATGCCA",
                    "ATCGCG"
                };

            Evaluar(dna, 2);
        }
    }    
}
