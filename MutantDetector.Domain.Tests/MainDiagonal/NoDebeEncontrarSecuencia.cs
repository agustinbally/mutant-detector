using Xunit;

namespace MutantDetector.Domain.Tests.MainDiagonalTests
{
    public class NoDebeEncontrarSecuencia : MainDiagonalEvaluatorTests
    {
        [Fact]
        public void CuandoNoHayMasDeTresEnNingunaDiagonal()
        {
            var dna = new[] {
                    "CTACCC",
                    "ACTACA",
                    "GACTAC",
                    "TGAAGC",
                    "ATGTCA",
                    "ATTCCA"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHaySecuenciasEnColumnas()
        {
            var dna = new[] {
                    "CTAATG",
                    "CTAGTG",
                    "CTAGAC",
                    "CTAGAC",
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
                    "CCCCTG",
                    "TTTTAC",
                    "TATTAC",
                    "TACCAC",
                    "CTTCCT"
                };

            Evaluar(dna, 0);
        }

       

        [Fact]
        public void CuandoHaySecuenciasEnAntiDiagonal()
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
        public void CuandoHayEntreDiagonalsConsecutivasArribaHaciaAbajo()
        {
            var dna = new[] {
                    "ACGTTT",
                    "TACTGG",
                    "CAATCT",
                    "ACTCCT", // arranca C en pos 3 hacia abajo, pasa a fila 0 col 1
                    "ACCACT",
                    "TCCGTC"
                };

            Evaluar(dna, 0);
        }
        [Fact]
        public void CuandoHayEntreDiagonalsConsecutivasAbajoHaciaArriba()
        {
            var dna = new[] {
                    "TTGTGT",
                    "CTGTTT",
                    "GATACT", // arranca T en pos 2 e hacia arriba, pasa a fila 4 col  5
                    "TCTATT",
                    "ACCACT",
                    "ATCCTC"
                };

            Evaluar(dna, 0);
        }
    }
}
