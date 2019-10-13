using Microsoft.AspNetCore.Mvc;
using Moq;
using MutantDetector.Api.Controllers;
using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;
using Xunit;

namespace MutantDetector.Api.Tests
{
    
    public class StatsControllerTests
    {
        [Fact]
        public async void DebeRetornarStatsObtenidas()
        {
            var summary = new HumansDnaSummary(10, 20);

            var humanDnaReposity = new Mock<IHumanDnaReposity>();
            humanDnaReposity.Setup(r => r.GetSumary()).ReturnsAsync(summary);            

            var controller = new StatsController(humanDnaReposity.Object);

            var response = await controller.GetStats();

            Assert.IsType<OkObjectResult>(response);                       
        }        
    }
}
