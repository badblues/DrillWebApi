using DrillWebApi.Domain;

namespace DrillWebApi.Persistence.Interfaces
{
    public interface IDrillBlockPointRepository
    {
        DrillBlockPoint? GetDrillBlockPoint(Guid id);
        IEnumerable<DrillBlockPoint> GetDrillBlockPoints();
        bool CreateDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        bool UpdateDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        bool DeleteDrillBlockPoint(Guid id);
    }
}
