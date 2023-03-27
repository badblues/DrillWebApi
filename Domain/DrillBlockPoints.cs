namespace DrillWebApi.Domain
{
    public record DrillBlockPoints
    {
        public Guid Id { get; init; }
        public Guid DrillBlockId { get; init; }
        //TODO Sequence XYZ

    }
}
