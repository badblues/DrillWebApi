namespace DrillWebApi.Domain
{
    public record DrillBlockPoint
    {
        public Guid Id { get; init; }
        public Guid DrillBlockId { get; set; }
        public uint SequenceNumber { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
