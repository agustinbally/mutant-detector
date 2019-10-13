using MutantDetector.Domain.Abstractions;

namespace MutantDetector.Domain
{
    public class MutantConfiguration : IMutantConfiguration
    {
        public int SequencesNeeded => 2;
    }
}
