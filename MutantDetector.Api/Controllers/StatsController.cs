using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MutantDetector.Domain.Abstractions;

namespace MutantDetector.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IHumanDnaReposity _humanDnaReposity;

        public StatsController(IHumanDnaReposity humanDnaReposity)
        {
            _humanDnaReposity = humanDnaReposity;
        }

        [HttpGet]
        public async Task<ActionResult> GetStats()
        {
            try
            {
                var humansDnaSummary = await _humanDnaReposity.GetSumary();

                return Ok(new
                {
                    count_mutant_dna = humansDnaSummary.TotalMutantsDna,
                    count_human_dna = humansDnaSummary.TotalHumansDna,
                    ratio = humansDnaSummary.Ratio
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }       
    }
}
