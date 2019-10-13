using MutantDetector.Domain.Entities;

namespace MutantDetector.Domain.Abstractions
{
    public interface IHumanDnaBuilder
    {
        IHumanDnaBuilder AddDna(string[] dna);
        HumanDna BuildHumanDna();
    }
}
