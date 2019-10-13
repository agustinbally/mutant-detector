using Moq;
using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;
using MutantDetector.Domain.Evaluators;
using System.Collections.Generic;
using Xunit;

namespace MutantDetector.Domain.Tests
{
    public class DnaEvaluatorTests
    {
        private readonly Mock<IMutantConfiguration> _mutantConfigurationMock;
        private readonly int _secuenciaNecesaria;
        private readonly HumanDna _humanDna;

        public DnaEvaluatorTests()
        {
            _secuenciaNecesaria = 5;
            _humanDna = HumanDna.Dummy(_secuenciaNecesaria * 2);
            _mutantConfigurationMock = new Mock<IMutantConfiguration>();
            _mutantConfigurationMock.Setup(mc => mc.SequencesNeeded).Returns(_secuenciaNecesaria);
        }

        [Fact]
        public void DnaConLongitudMenorQueLaSecuenciaNecesariaNoPuedeSerMutante()
        {            
            var sut = new DnaEvaluator(new List<IRangeEvaluator>
            {
                new Mock<IRangeEvaluator>().Object
            }, _mutantConfigurationMock.Object);

            for (var dnaLength = 1; dnaLength < _secuenciaNecesaria; dnaLength++)
            {
                Assert.False(sut.IsMutant(HumanDna.Dummy(dnaLength)));
            }
        }

        [Fact]
        public void SiUnEvaluadorTieneLasSecuenciasNecesariasEntoncesEsMutante()
        {
            var rangeEvaluatorMock1 = new Mock<IRangeEvaluator>();
            var rangeEvaluatorMock2 = new Mock<IRangeEvaluator>();
            var rangeEvaluatorMock3 = new Mock<IRangeEvaluator>();

            rangeEvaluatorMock1.Setup(e => e.GetPatternOccurrences(_humanDna, _secuenciaNecesaria)).Returns(0);
            rangeEvaluatorMock2.Setup(e => e.GetPatternOccurrences(_humanDna, _secuenciaNecesaria)).Returns(_secuenciaNecesaria);
            rangeEvaluatorMock3.Setup(e => e.GetPatternOccurrences(_humanDna, _secuenciaNecesaria)).Returns(0);

            var sut = new DnaEvaluator(new List<IRangeEvaluator>
            {
                rangeEvaluatorMock1.Object,
                rangeEvaluatorMock2.Object,
                rangeEvaluatorMock3.Object,
            }, _mutantConfigurationMock.Object);

            var isMutant =  sut.IsMutant(_humanDna);

            Assert.True(isMutant);
        }

        [Fact]
        public void SiUnEntreMasDeUnEvaluadorSumanLasSecuenciasNecesariasEntoncesEsMutante()
        {
            var rangeEvaluatorMock1 = new Mock<IRangeEvaluator>();
            var rangeEvaluatorMock2 = new Mock<IRangeEvaluator>();
            var rangeEvaluatorMock3 = new Mock<IRangeEvaluator>();

            var secuenciasEvaluador1 = _secuenciaNecesaria / 2;
            var secuenciasRestantes = _secuenciaNecesaria - secuenciasEvaluador1;
            var secuenciasEvaluador3 = secuenciasRestantes;

            rangeEvaluatorMock1.Setup(e => e.GetPatternOccurrences(_humanDna, _secuenciaNecesaria)).Returns(secuenciasEvaluador1);
            rangeEvaluatorMock2.Setup(e => e.GetPatternOccurrences(_humanDna, It.IsAny<int>())).Returns(0);
            rangeEvaluatorMock3.Setup(e => e.GetPatternOccurrences(_humanDna, It.IsAny<int>())).Returns(secuenciasEvaluador3);            

            var sut = new DnaEvaluator(new List<IRangeEvaluator>
            {
                rangeEvaluatorMock1.Object,
                rangeEvaluatorMock2.Object,
                rangeEvaluatorMock3.Object,
            }, _mutantConfigurationMock.Object);

            var isMutant = sut.IsMutant(_humanDna);

            Assert.True(isMutant);
        }

        [Fact]
        public void SiEntreLosEvaluadoresNoSumanLaSecuenciaNecesariaEntoncesNoEsMutante()
        {
            var rangeEvaluatorMock1 = new Mock<IRangeEvaluator>();
            var rangeEvaluatorMock2 = new Mock<IRangeEvaluator>();
            var rangeEvaluatorMock3 = new Mock<IRangeEvaluator>();

            var secuenciasEvaluador1 = 1;
            var secuenciasEvaluador2 = 2;
            var secuenciasEvaluador3 = 3;

            var secuenciaNecesaria = secuenciasEvaluador1 + secuenciasEvaluador2 + secuenciasEvaluador3 + 1;

            rangeEvaluatorMock1.Setup(e => e.GetPatternOccurrences(_humanDna, _secuenciaNecesaria)).Returns(secuenciasEvaluador1);
            rangeEvaluatorMock2.Setup(e => e.GetPatternOccurrences(_humanDna, It.IsAny<int>())).Returns(secuenciasEvaluador2);
            rangeEvaluatorMock3.Setup(e => e.GetPatternOccurrences(_humanDna, It.IsAny<int>())).Returns(secuenciasEvaluador3);

            var mutantConfigurationMock = new Mock<IMutantConfiguration>();
            mutantConfigurationMock.Setup(mc => mc.SequencesNeeded).Returns(secuenciaNecesaria);

            var sut = new DnaEvaluator(new List<IRangeEvaluator>
            {
                rangeEvaluatorMock1.Object,
                rangeEvaluatorMock2.Object,
                rangeEvaluatorMock3.Object,
            }, mutantConfigurationMock.Object);

            var isMutant = sut.IsMutant(_humanDna);

            Assert.False(isMutant);
        }
    }
}

