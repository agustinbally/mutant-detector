namespace MutantDetector.Infrastructure
{
    public class HumanDnaData
    {
        public HumanDnaData(string id, string dna, bool isMutant)
        {
            Id = id;
            Dna = dna;
            IsMutant = isMutant;
        }

        public string Id { get; private set; }
        public string Dna { get; private set; }
        public bool IsMutant { get; private set; }
    }
}
