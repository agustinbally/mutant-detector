using MutantDetector.Domain.Entities;
using MutantDetector.Domain.Entities.Builders;
using System.Collections.Generic;
using Xunit;

namespace MutantDetector.Domain.Tests
{
    public class HumanDnaTests
    {
        [Theory]
        [MemberData(nameof(ListaDnas))]
        public void HumanDnaDebeEntregarElElementoC22orrecto(string[] dna)
        {
            var humanDna = CrearHumanDna(dna);

            for (var i = 0; i < dna.Length; i++)
            {
                for (var j = 0; j < dna.Length; j++)
                {
                    Assert.Equal(dna[i][j], humanDna.Element(i, j));
                }
            }
        }

        public static IEnumerable<object[]> ListaDnas => new List<object[]>
        {
            new object[] { new[] { "ACG", "CAA", "GCG" } },
            new object[] { new[] { "ATCG", "CAAT", "GTCG", "CTAA" } },
            new object[] { new[] {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"} },
            new object[] { new[] {"TTCGTGTT","CCAATGGC","TTACACCT","AAAAAAAA","AAGCCATA","TTACCGCT","TTCGTGTT","CCAATGGC" } }
        };

        private static HumanDna CrearHumanDna(string[] dna)
        {
            return new HumanDnaBuilder().AddDna(dna).BuildHumanDna();
        }
    }

}
