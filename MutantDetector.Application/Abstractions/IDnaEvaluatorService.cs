using System.Threading.Tasks;

namespace MutantDetector.Application.Abstractions
{
    public interface IDnaEvaluatorService
    {
        Task<bool> EvaluateDna(string[] dna);
    }
}