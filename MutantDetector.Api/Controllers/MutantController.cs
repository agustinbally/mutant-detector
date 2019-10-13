using Microsoft.AspNetCore.Mvc;
using MutantDetector.Api.Dtos;
using MutantDetector.Application.Abstractions;
using System;
using System.Threading.Tasks;

namespace MutantDetector.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MutantController : ControllerBase
    {
        private readonly IDnaEvaluatorService _dnaEvaluatorService;        

        public MutantController(IDnaEvaluatorService dnaEvaluatorService)
        {
            _dnaEvaluatorService = dnaEvaluatorService;            
        }
    
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DnaDto dnaDto)
        {
            try
            {
                var isMutant = await _dnaEvaluatorService.EvaluateDna(dnaDto.Dna);

                return isMutant ? Ok() : StatusCode(403);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }        
    }
}
