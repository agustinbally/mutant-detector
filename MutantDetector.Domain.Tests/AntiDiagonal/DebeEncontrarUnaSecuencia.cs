using Xunit;

namespace MutantDetector.Domain.Tests.AntiDiagonalTests
{
    public class DebeEncontrarUnaSecuencia : AntiDiagonalEvaluatorTests
    {
        [Fact]
        public void AlInicioDeLaDiagonalSecundario()
        {
            var dna = new[]
            {
                    "CTACCG",
                    "CACATG",
                    "TCTCAC",
                    "ATCCCT",
                    "TCACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaDiagonalSecundario()
        {
            var dna = new[] {
                    "TTCAAA",
                    "CGCAAG",
                    "TCTAAC",
                    "GTACCT",
                    "CTACTA",
                    "ATACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaDiagonalSecundario()
        {
            var dna = new[] {
                    "TTCAAA",
                    "CGCATG",
                    "TCTTAC",
                    "GTTACT",
                    "CTACTA",
                    "ATACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnLaUltimaDiagonalInferior()
        {
            var dna = new[] {
                    "TTCAAA",
                    "CGCATG",
                    "TCTCAC",
                    "GTAACT",
                    "CTACTA",
                    "ATCTAG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnLaUltimaDiagonalSuperior()
        {
            var dna = new[] {
                    "TTCGAA",
                    "CGGATG",
                    "TGTCAC",
                    "GTAACT",
                    "CTACTA",
                    "ATACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void CuandoHayHastaSieteConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "CTAATGCC",
                    "TTTCACCT",
                    "TTCCCGTT",
                    "AAGCTATA",
                    "TTCCCCCT",
                    "TCCGTGTT",
                    "CCAATGGC"
                };

            Evaluar(dna, 1);
        }
    }
}
