using Xunit;

namespace MutantDetector.Domain.Tests.MainDiagonalTests
{
    public class DebeEncontrarUnaSecuencia : MainDiagonalEvaluatorTests
    {
        [Fact]
        public void AlInicioDeLaDiagonalPrincipal()
        {
            var dna = new[]
            {
                    "CTACCG",
                    "CCCATG",
                    "TCCCAC",
                    "ATACCT",
                    "TTACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaDiagonalPrincipal()
        {
            var dna = new[] {
                    "TTCAAA",
                    "CGCATG",
                    "TCGCAC",
                    "GTAGCT",
                    "CTACGA",
                    "ATACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaDiagonalPrincipal()
        {
            var dna = new[] {
                    "TCCAAA",
                    "TGCATG",
                    "GCGCAC",
                    "ATAGAT",
                    "ATACGA",
                    "CTACCC"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnLaUltimaDiagonalInferior()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "AGATCT",
                    "ATGCCA",
                    "ATCGCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnLaUltimaDiagonalSuperior()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "ATATCA",
                    "ATACCA",
                    "TTGGAA"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void CuandoHayHastaSieteConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "CTAATGGC",
                    "TTTCACCT",
                    "TTCTTGTT",
                    "AAGCTATA",
                    "TTACCTCT",
                    "TTCGTGTT",
                    "CCAATGGC"
                };

            Evaluar(dna, 1);
        }
    }
}
