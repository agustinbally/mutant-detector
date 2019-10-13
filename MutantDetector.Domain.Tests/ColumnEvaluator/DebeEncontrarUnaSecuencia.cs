using Xunit;

namespace MutantDetector.Domain.Tests.ColumnEvaluatorTests
{
    public class DebeEncontrarUnaSecuencia : ColumnEvaluatorTests
    {
        [Fact]
        public void AlInicioDeLaPrimeraColumna()
        {
            var dna = new[]
            {
                    "ATCGTA",
                    "AGCATG",
                    "ACTCAC",
                    "ATATCT",
                    "TTACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaPrimeraColumna()
        {
            var dna = new[] {
                    "TTCGTA",
                    "CGCATG",
                    "ACTCAC",
                    "ATATCT",
                    "ATACCA",
                    "ATACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaPrimeraColumna()
        {
            var dna = new[] {
                    "TTCGTA",
                    "AGCATG",
                    "ACTCAC",
                    "ATATCT",
                    "ATACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlInicioDeLaUltimaColumna()
        {
            var dna = new[] {
                    "TCGTAA",
                    "GCATGA",
                    "CTCACA",
                    "TATCTA",
                    "TTACCG",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaUltimaColumna()
        {
            var dna = new[] {
                    "TTCGTA",
                    "CGCATG",
                    "CTCACA",
                    "TATCTA",
                    "TACCAA",
                    "TACCGA"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaUltimaColumna()
        {
            var dna = new[] {
                    "TTCGTG",
                    "GCATGA",
                    "CTCACA",
                    "TATCTA",
                    "TACCAA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlInicioDeLaColumnaMedia()
        {
            var dna = new[] {
                    "TCAGTA",
                    "GCAATG",
                    "CTACAC",
                    "TAATCT",
                    "TTGCCG",
                    "CTTCCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void AlFinalDeLaColumnaMedia()
        {
            var dna = new[] {
                    "TTCGTA",
                    "CGCATG",
                    "CTACAC",
                    "TAATCT",
                    "TCACCA",
                    "TGACCG"
                };

            Evaluar(dna, 1);
        }

        [Fact]
        public void EnElMedioDeLaColumnaMedia()
        {
            var dna = new[] {
                    "TTCGTG",
                    "GCAATG",
                    "CTACAC",
                    "TAATCT",
                    "TAACCA",
                    "CTACCG"
                };

            Evaluar(dna, 1);
        }       

        [Fact]
        public void CuandoHayHastaSieteConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "TCAATGGC",
                    "TTACACCT",
                    "TAATCTTA",
                    "TAGCCATA",
                    "TTACCGCT",
                    "TTCGTGTT",
                    "GCAATGGC"
                };

            Evaluar(dna, 1);
        }

    }
}
