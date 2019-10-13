using MutantDetector.Domain.Entities;
using System;
using Xunit;

namespace MutantDetector.Domain.Tests
{
    public class HumansDnaSummaryTests
    {
        [Fact]
        public void AlCrearseDebeAsignarCorrectamenteLosTotales()
        {
            var totalMutantsDna = 10;
            var totalHumansDna = 100;

            var humansDnaSummary = new HumansDnaSummary(totalMutantsDna, totalHumansDna);

            Assert.Equal(totalMutantsDna, humansDnaSummary.TotalMutantsDna);
            Assert.Equal(totalHumansDna, humansDnaSummary.TotalHumansDna);
        }

        [Theory]
        [InlineData(10, 100)]
        [InlineData(40, 100)]
        [InlineData(4, 50)]
        [InlineData(100, 100)]
        public void AlCrearseDebeCalcularCorrectamenteElRatio(int totalMutantsDna, int totalHumansDna)
        {
            var humansDnaSummary = new HumansDnaSummary(totalMutantsDna, totalHumansDna);

            Assert.Equal((decimal)totalMutantsDna / totalHumansDna, humansDnaSummary.Ratio);
        }

        [Fact]
        public void AlCrearseSiNoHayMutantesEntoncesElRatioDebeSerCero()
        {
            var humansDnaSummary = new HumansDnaSummary(0, 10);

            Assert.Equal(0, humansDnaSummary.Ratio);
        }

        [Theory]
        [InlineData(100, 10)]
        [InlineData(100, 40)]
        [InlineData(50, 4)]
        [InlineData(1000, 1)]
        public void SiHayMasMutantesQueHumanosDebeLanzarArgumentException(int totalMutantsDna, int totalHumansDna)
        {            
            Assert.Throws<ArgumentException>(() => new HumansDnaSummary(totalMutantsDna, totalHumansDna));
        }
    }
}
