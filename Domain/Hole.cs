namespace DrillWebApi.Domain
{
    public record Hole
    {
        public Guid Id { get; init; }
        public Guid DrillBlockId { get; set; }
        public string Name { get; set; }
        public double Depth { get; set; }
        public ICollection<HoleLocation> HoleLocations { get; set; }
    }
}
