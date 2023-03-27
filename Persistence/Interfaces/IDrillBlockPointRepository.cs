using DrillWebApi.Domain;

namespace DrillWebApi.Persistence.Interfaces
{
    public interface IDrillBlockPointRepository
    {
        DrillBlockPoint? GetDrillBlockPoint(Guid id);
        IEnumerable<DrillBlockPoint> GetDrillBlockPoints();
        bool CreateDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        void UpdateDrillBlockPoint(DrillBlockPoint drillBlockPoint);
        void DeleteDrillBlockPoint(Guid id);
    }
}
