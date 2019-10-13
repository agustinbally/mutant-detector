using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Abstractions
{
    public interface IDnaEvaluator
    {
        bool IsMutant(HumanDna dna);
    }
}
