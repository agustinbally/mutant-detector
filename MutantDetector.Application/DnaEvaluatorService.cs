using MutantDetector.Application.Abstractions;
using MutantDetector.Domain.Abstractions;
using System.Threading.Tasks;

namespace MutantDetector.Application
{
    public class DnaEvaluatorService : IDnaEvaluatorService
    {
        private readonly IDnaEvaluator _dnaEvaluator;        
        private readonly IHumanDnaBuilder _humanDnaBuilder;
        private readonly IHumanDnaReposity _humanDnaReposity;

        public DnaEvaluatorService(IHumanDnaBuilder humanDnaBuilder, IDnaEvaluator dnaEvaluator, IHumanDnaReposity humanDnaReposity)
        {
            _dnaEvaluator = dnaEvaluator;            
            _humanDnaBuilder = humanDnaBuilder;
            _humanDnaReposity = humanDnaReposity;
        }

        public async Task<bool> EvaluateDna(string[] dna)
        {
            var humanDna = _humanDnaBuilder.AddDna(dna).BuildHumanDna();
            var isMutant = _dnaEvaluator.IsMutant(humanDna);

            await _humanDnaReposity.Save(humanDna, isMutant);

            return isMutant;
        }
    }
}
