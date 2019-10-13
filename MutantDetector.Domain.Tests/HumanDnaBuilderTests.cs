using MutantDetector.Domain.Entities;
using MutantDetector.Domain.Entities.Builders;
using System;
using Xunit;

namespace MutantDetector.Domain.Tests
{
    public class HumanDnaBuilderTests
    { 
        [Fact]
        public void HumanDnaToStringDebeSepararLosElementosConUnGuion()
        {
            var dna = new[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            var humanDna = CrearHumanDna(dna);

            Assert.Equal(string.Join("-", dna), humanDna.ToString());
        }
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void AlCrearHumanDnaDebeTenerLongitudDelDna(int length)
        {
            var dna = new string[length];
            for (var i = 0; i < length; i++)
            {
                dna[i] = new string('A', length);
            }

            Assert.Equal(length, CrearHumanDna(dna).Length);
        }

        [Fact]
        public void AlCrearHumanDnaConDnaNuloLanzaArgumentException()
        {
            ValidarCreacioHumanDnaArgumentException(null);
        }

        [Fact]
        public void AlCrearHumanDnaConDnaVacioLanzaArgumentException()
        {
            ValidarCreacioHumanDnaArgumentException(new string[0]);
        }

        [Fact]
        public void AlCrearHumanDnaConDnaConMasFilasQueColumnasLanzaArgumentException()
        {
            ValidarCreacioHumanDnaArgumentException(new[] { "AA", "AA", "TT" });
        }

        [Fact]
        public void AlCrearHumanDnaConDnaConMasColumnasQueFilasLanzaArgumentException()
        {
            ValidarCreacioHumanDnaArgumentException(new[] { "AAA", "TTT" });
        }

        private void ValidarCreacioHumanDnaArgumentException(string[] dna)
        {
            Assert.Throws<ArgumentException>(() => CrearHumanDna(dna));
        }
    
        private static HumanDna CrearHumanDna(string[] dna)
        {
            return new HumanDnaBuilder().AddDna(dna).BuildHumanDna();
        }
    }

}
