using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MutantDetector.Domain.Evaluators
{
    public class DnaEvaluator : IDnaEvaluator
    {
        private readonly IEnumerable<IRangeEvaluator> _evaluators;
        private readonly IMutantConfiguration _mutantConfiguration;

        public DnaEvaluator(IEnumerable<IRangeEvaluator> evaluators, IMutantConfiguration mutantConfiguration)
        {
            _evaluators = evaluators ?? throw new ArgumentNullException(nameof(evaluators));
            _mutantConfiguration = mutantConfiguration ?? throw new ArgumentNullException(nameof(mutantConfiguration));
        }

        public bool IsMutant(HumanDna dna)
        {
            if (dna.Length < 4) return false;

            int patternCountAggregator(int patternCount, IRangeEvaluator evaluator) 
                => patternCount + evaluator.GetPatternOccurrences(dna, _mutantConfiguration.SequencesNeeded - patternCount);

            var dnaPatternCount = _evaluators.ToList().Aggregate(0, patternCountAggregator);
            
            return dnaPatternCount >= _mutantConfiguration.SequencesNeeded;
        }
    }
}
