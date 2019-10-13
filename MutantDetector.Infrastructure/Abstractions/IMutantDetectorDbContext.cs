using MongoDB.Driver;

namespace MutantDetector.Infrastructure.Abstractions
{
    public interface IMutantDetectorDbContext
    {
        IMongoCollection<HumanDnaData> HumansDna { get; }
    }
}
