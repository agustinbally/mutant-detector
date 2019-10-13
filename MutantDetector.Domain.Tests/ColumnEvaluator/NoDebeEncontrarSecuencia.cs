using Xunit;

namespace MutantDetector.Domain.Tests.ColumnEvaluatorTests
{
    public class NoDebeEncontrarSecuencia : ColumnEvaluatorTests
    {
        [Fact]
        public void CuandoNoHayMasDeTresEnNingunaColumna()
        {
            var dna = new[] {
                    "TCCGTG",
                    "GCAGTG",
                    "TCAGAC",
                    "TAATAC",
                    "TACCAC",
                    "CTTCCT"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHaySecuenciasEnFilas()
        {
            var dna = new[] {
                    "AAAATG",
                    "GCAGTG",
                    "TCAGAC",
                    "TATTAC",
                    "TACCAC",
                    "CTTCCT"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHaySecuenciasEnDiagonalPrincipal()
        {
            var dna = new[] {
                    "TCCGTG",
                    "GTGTGA",
                    "TCTGAC",
                    "TAATAC",
                    "TACCAC",
                    "CTTCCT"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHaySecuenciasEnAntiPrincipal()
        {
            var dna = new[] {
                    "TCCGTG",
                    "GCAGTG",
                    "TCAAAC",
                    "TAATAC",
                    "TACCAC",
                    "ATTCCT"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHayEntreColumnasConsecutivasArribaHaciaAbajo()
        {
            var dna = new[] {
                    "CCGTGT",
                    "CAGTGG",
                    "CAGACT",
                    "ACTACT",
                    "ACCACT",
                    "TCCCTC"
                };

            Evaluar(dna, 0);
        }
        [Fact]
        public void CuandoHayEntreColumnasConsecutivasAbajoHaciaArriba()
        {
            var dna = new[] {
                    "CAGTGT",
                    "CAGTGG",
                    "CAGACT",
                    "TCTACT",
                    "ACCACT",
                    "ATCCTC"
                };

            Evaluar(dna, 0);
        }
    }
}
