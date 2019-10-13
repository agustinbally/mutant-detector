using MutantDetector.Domain;
using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities.Builders;
using MutantDetector.Domain.Evaluators;
using MutantDetector.Domain.Evaluators.RangeEvaluators;
using System;

namespace MutantDetector.Program
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(isMutant(args) ? "true" : "false");            
        }

        static bool isMutant(string[] dna)
        {
            var humanDna = new HumanDnaBuilder().AddDna(dna).BuildHumanDna();

            var evaluator = new DnaEvaluator(new IRangeEvaluator[]
            {
                new RowEvaluator(),
                new ColumnEvaluator(),
                new MainDiagonalEvaluator(),
                new AntiDiagonalEvaluator()
            }, new MutantConfiguration());

            return evaluator.IsMutant(humanDna);
        }

        private static void RunExample()
        {
            string[] dnaMutant = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            Console.WriteLine($"{string.Join(",", dnaMutant)} isMutant: {isMutant(dnaMutant)}");

            string[] dnaHuman = { "ATGCGA", "CCGTGC", "TTATGT", "AGAAGG", "TACGTA", "TCACTG" };

            Console.WriteLine($"{string.Join(",", dnaMutant)} isMutant: {isMutant(dnaHuman)}");

            Console.ReadKey();
        }
    }
}
