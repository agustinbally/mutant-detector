using MutantDetector.Domain.Abstractions;
using System;
using System.Linq;

namespace MutantDetector.Domain.Entities.Builders
{
    public class HumanDnaBuilder : IHumanDnaBuilder
    {        
        public string[] Dna { get; private set; }


        public IHumanDnaBuilder AddDna(string[] dna)
        {
            Dna = dna;
            return this;
        }

        private void ValidateHumanDnaData()
        {
            if (Dna == null || Dna.Length == 0) throw new ArgumentException("Empty DNA.");
            if (!Dna.ToList().All(row => row.Length == Dna.Length)) throw new ArgumentException("Invalid DNA format.");
            //if (!dna.ToList().All(row => row.ToArray().All(rowElem => "ATCG".Contains(rowElem))))
            //    throw new ArgumentException("DNA contains invalid elements.");
        }

        public HumanDna BuildHumanDna()
        {
            ValidateHumanDnaData();
            return new HumanDna(this);
        }
    }
}
