namespace DrillWebApi.Dtos
{
    public class InputHoleLocationDto
    {
        public Guid HoleId { get; init; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
