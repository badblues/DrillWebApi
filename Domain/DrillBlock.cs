namespace DrillWebApi.Domain
{
    public class DrillBlock
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
