using Xunit;

namespace MutantDetector.Domain.Tests.RowEvaluatorTests
{
    public class NoDebeEncontrarSecuencia : RowEvaluatorTests
    {
        [Fact]
        public void CuandoNoHayMasDeTresEnNingunaFila()
        {
            var dna = new[] {
                    "CTACCC",
                    "TTTCGA",
                    "GCTCAC",
                    "TAAATC",
                    "ATATCT",
                    "ATACCA"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHaySecuenciasEnColumnas()
        {
            var dna = new[] {
                    "CTTATG",
                    "CTAGTG",
                    "CTAGAC",
                    "CTTGAC",
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
        public void CuandoHayEntreFilasConsecutivasArribaHaciaAbajo()
        {
            var dna = new[] {
                    "ACGTTT",
                    "TTGTGG",
                    "CAGACT",
                    "ACTACT",
                    "ACCACT",
                    "TCCCTC"
                };

            Evaluar(dna, 0);
        }
        [Fact]
        public void CuandoHayEntreFilasConsecutivasAbajoHaciaArriba()
        {
            var dna = new[] {
                    "TTGTGT",
                    "CAGTTT",
                    "GAGACT",
                    "TCTACT",
                    "ACCACT",
                    "ATCCTC"
                };

            Evaluar(dna, 0);
        }
    }
}
