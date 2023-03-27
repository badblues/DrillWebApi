namespace DrillWebApi.Dtos
{
    public class InputHoleDto
    {
        public Guid DrillBlockId { get; init; }
        public string Name { get; set; }
        public double Depth { get; set; }
    }
}
