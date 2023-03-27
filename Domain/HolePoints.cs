namespace DrillWebApi.Domain
{
    public record HolePoints
    {
        public Guid Id { get; init; }
        public Guid HoleId { get; init; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
