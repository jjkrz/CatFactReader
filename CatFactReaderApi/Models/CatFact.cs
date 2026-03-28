namespace CatFactReaderApi.Models
{
    public class CatFact
    {
        public string Fact { get; set; } = null!;
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Fact: {Fact}, Length: {Length}\n";
        }
    }
}
