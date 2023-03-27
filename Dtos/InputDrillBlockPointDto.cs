namespace DrillWebApi.Dtos
{
    public class InputDrillBlockPointDto
    {
        public Guid DrillBlockId { get; init; }
        public uint SequenceNumber { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
