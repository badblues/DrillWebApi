namespace DrillWebApi.Domain
{
    public record DrillBlock
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<Hole> Holes { get; set; }
    }
}
