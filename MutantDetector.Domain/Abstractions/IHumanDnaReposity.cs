using MutantDetector.Domain.Entities;
using System.Threading.Tasks;

namespace MutantDetector.Domain.Abstractions
{
    public interface IHumanDnaReposity
    {
        Task Save(HumanDna humanDna, bool isMutant);
        Task<HumansDnaSummary> GetSumary();
    }
}
