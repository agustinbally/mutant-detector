using Xunit;

namespace MutantDetector.Domain.Tests.AntiDiagonalTests
{
    public class DebeEncontrarDosSecuencias : AntiDiagonalEvaluatorTests
    {
        [Fact]
        public void CuandoHayAlMenosOchoConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTC",
                    "CTAATGCC",
                    "TTTCACCT",
                    "TTCCCGTT",
                    "AAGCTATA",
                    "TTCCCCCT",
                    "TCCGTGTT",
                    "CCAATGGC"
                };

            Evaluar(dna, 2);
        }

        [Fact]
        public void CuandoHayDosSecuenciasEnDistintasDiagonals()
        {
            // ultimas inferior y superior
            var dna = new[] {
                    "TTCGAA",
                    "CGGATG",
                    "TGTCAC",
                    "GTAACT",
                    "CTACTA",
                    "ATCCCG"
                };

            Evaluar(dna, 2);
        }
    }
}
