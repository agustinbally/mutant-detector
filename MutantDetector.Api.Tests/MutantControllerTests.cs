using Microsoft.AspNetCore.Mvc;
using Moq;
using MutantDetector.Api.Controllers;
using MutantDetector.Api.Dtos;
using MutantDetector.Application.Abstractions;
using System;
using Xunit;

namespace MutantDetector.Api.Tests
{
    public class MutantControllerTests
    {
        [Fact]
        public async void CuandoElSeProduceUnArgumentExceptionRetornaBadRequest()
        {
            var dnaEvaluatorServiceMock = new Mock<IDnaEvaluatorService>();

            dnaEvaluatorServiceMock.Setup(e => e.EvaluateDna(It.IsAny<string[]>())).ThrowsAsync(new ArgumentException());

            var controller = new MutantController(dnaEvaluatorServiceMock.Object);

            var response = await controller.Post(new DnaDto());

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void CuandoEsMutanteDebeRetornarHttpStatusCode200()
        {
            ValidarStatusCodeEnRespuestaDeIsMutant(true, 200);            
        }

        [Fact]
        public void CuandoNoEsMutanteDebeRetornarHttpStatusCode403()
        {
            ValidarStatusCodeEnRespuestaDeIsMutant(false, 403);
        }

        private async void ValidarStatusCodeEnRespuestaDeIsMutant(bool isMutant, int statusCode)
        {
            var dnaEvaluatorServiceMock = new Mock<IDnaEvaluatorService>();
            
            dnaEvaluatorServiceMock.Setup(e => e.EvaluateDna(It.IsAny<string[]>())).ReturnsAsync(isMutant);
            
            var controller = new MutantController(dnaEvaluatorServiceMock.Object);

            var response = await controller.Post(new DnaDto());

            Assert.IsAssignableFrom<StatusCodeResult>(response);
            Assert.Equal(((StatusCodeResult)response).StatusCode, statusCode);
        }
    }
}

