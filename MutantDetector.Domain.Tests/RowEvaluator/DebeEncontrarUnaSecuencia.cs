using Xunit;

namespace MutantDetector.Domain.Tests.RowEvaluatorTests
{
    public class DebeEncontrarUnaSecuencia : RowEvaluatorTests
    {
        [Fact]
        public void AlInicioDeLaPrimeraFila()
        {
            var dna = new[]
            {
                    "AAAATA",
                    "CGCATG",
                    "TCTCAC",
                    "ATATCT",
                    "TTACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaPrimeraFila()
        {
            var dna = new[] {
                    "TTAAAA",
                    "CGCATG",
                    "TCTCAC",
                    "GTATCT",
                    "CTACCA",
                    "ATACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaPrimeraFila()
        {
            var dna = new[] {
                    "TAAAAA",
                    "TGCATG",
                    "GCTCAC",
                    "ATATCT",
                    "ATACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlInicioDeLaUltimaFila()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "ATATCT",
                    "ATACCA",
                    "AAAACG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaUltimaFila()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "ATATCT",
                    "ATACCA",
                    "TTAAAA"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaUltimaFila()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "ATATCT",
                    "ATACCA",
                    "TAAAAC"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlInicioDeLaFilaMedia()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "AAAATT",
                    "ATATCT",
                    "ATACCA"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaFilaMedia()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "TTAAAA",
                    "ATATCT",
                    "ATACCA"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaFilaMedia()
        {
            var dna = new[] {
                    "CTACCG",
                    "TGCATG",
                    "GCTCAC",
                    "TAAAAT",
                    "ATATCT",
                    "ATACCA"
                };

            Evaluar(dna, 1);
        }       

        [Fact]
        public void CuandoHayHastaSieteConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "CCAATGGC",
                    "TTACACCT",
                    "AAAAAAAT",
                    "AAGCCATA",
                    "TTACCGCT",
                    "TTCGTGTT",
                    "CCAATGGC"
                };

            Evaluar(dna, 1);
        }

    }
}
