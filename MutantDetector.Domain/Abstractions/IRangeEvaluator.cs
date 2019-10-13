using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Abstractions
{
    public interface IRangeEvaluator
    {
        int GetPatternOccurrences(HumanDna dna, int atMost);
    }
}
