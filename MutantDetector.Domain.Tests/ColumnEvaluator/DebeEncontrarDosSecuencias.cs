using Xunit;

namespace MutantDetector.Domain.Tests.ColumnEvaluatorTests
{
    public class DebeEncontrarDosSecuencias : ColumnEvaluatorTests
    {
        [Fact]
        public void CuandoHayAlMenosOchoConsecutivas()
        {
            var dna = new[] {
                    "TTCGTGTT",
                    "TCAATGGC",
                    "TTACACCT",
                    "TAATCTTA",
                    "TAGCCATA",
                    "TTACCGCT",
                    "TTCGTGTT",
                    "TCAATGGC"
                };

            Evaluar(dna, 2);
        }

        [Fact]
        public void CuandoHayDosSecuenciasEnDistintasColumnas()
        {
            var dna = new[] {
                    "TTCGTGTA",
                    "TCAATGGA",
                    "TTACACCA",
                    "TAATCTTA",
                    "GAGCCATA",
                    "CTACCGCT",
                    "ATCGTGTT",
                    "CAATGGCG"
                };

            Evaluar(dna, 2);
        }
    }    
}
