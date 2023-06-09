﻿namespace DrillWebApi.Domain
{
    public record HoleLocation
    {
        public Guid Id { get; init; }
        public Guid HoleId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
