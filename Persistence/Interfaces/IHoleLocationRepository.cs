using DrillWebApi.Domain;

namespace DrillWebApi.Persistence.Interfaces
{
    public interface IHoleLocationRepository
    {
        HoleLocation? GetHoleLocation(Guid id);
        IEnumerable<HoleLocation> GetHoleLocations();
        bool CreateHoleLocation(HoleLocation holeLocation);
        bool UpdateHoleLocation(HoleLocation holeLocation);
        bool DeleteHoleLocation(Guid id);
    }
}
