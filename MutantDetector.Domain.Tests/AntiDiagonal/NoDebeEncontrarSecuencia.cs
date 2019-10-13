using Xunit;

namespace MutantDetector.Domain.Tests.AntiDiagonalTests
{
    public class NoDebeEncontrarSecuencia : AntiDiagonalEvaluatorTests
    {
        [Fact]
        public void CuandoNoHayMasDeTresEnNingunaDiagonal()
        {
            var dna = new[] {
                    "CTGCCC",
                    "AGTACA",
                    "GATTAC",
                    "TTAAGC",
                    "TAGGCA",
                    "ATGCCA"
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
        public void CuandoHaySecuenciasEnDiagonalPrincipal()
        {
            var dna = new[] {
                    "TCCGTG",
                    "GTAGTG",
                    "TCTAAC",
                    "TACTAC",
                    "TTCCTC",
                    "ATTCCT"
                };

            Evaluar(dna, 0);
        }

        [Fact]
        public void CuandoHayEntreDiagonalsConsecutivasArribaHaciaAbajo()
        {
            var dna = new[] {
                    "ACCTTT",
                    "TCTTGG",
                    "CCATGT",// arranca C en pos 0 hacia arriba, pasa a fila 3 col 0
                    "CCTCCT", 
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
                    "GACTCT", // arranca T en pos 3 e hacia arriba, pasa a fila 5 col 2
                    "TCGTCA",
                    "ACTACT",
                    "ATCCTC"
                };

            Evaluar(dna, 0);
        }
    }
}
