using MutantDetector.Domain.Entities.Builders;

namespace MutantDetector.Domain.Entities
{
    public class HumanDna
    {
        string[] _dna;
        public int Length { get;  private set; }

        private HumanDna(string[] dna)
        {
            _dna = dna;
            Length = dna[0].Length;
        }

        private HumanDna(){}

        public HumanDna(HumanDnaBuilder builder) : this(builder.Dna)
        { }

        public char Element(int row, int column) => _dna[row][column];     
        
        public static HumanDna Dummy(int length)
        {
            return new HumanDna { Length = length };
        }

        public override string ToString()
        {
            return string.Join("-", _dna);
        }
    }
}
