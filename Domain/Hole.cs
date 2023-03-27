namespace DrillWebApi.Domain
{
    public class Hole
    {
        public Guid Id { get; init; }
        public Guid DrillBlockId { get; init; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
        public double Depth { get; set; }
    }
}
