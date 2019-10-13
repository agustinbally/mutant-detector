using System;

namespace MutantDetector.Domain.Entities
{
    public class HumansDnaSummary
    {
        public long TotalMutantsDna { get; private set; }
        public long TotalHumansDna { get; private set; }
        public decimal Ratio { get; private set; }

        public HumansDnaSummary(long totalMutantsDna, long totalHumansDna)
        {
            if (totalMutantsDna > totalHumansDna) throw new ArgumentException("More mutants than humans.");

            TotalMutantsDna = totalMutantsDna;
            TotalHumansDna = totalHumansDna;
            Ratio = totalMutantsDna == 0 ? 0 : (decimal)totalMutantsDna / totalHumansDna;
        }
    }
}
