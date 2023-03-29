using DrillWebApi.Domain;
using DrillWebApi.Persistence.Interfaces;

namespace DrillWebApi.Persistence
{
    public class DbDrillBlockPointRepository : IDrillBlockPointRepository
    {
        private ApplicationContext db;
        public DbDrillBlockPointRepository(ApplicationContext context)
        {
            db = context;
        }

        public DrillBlockPoint? GetDrillBlockPoint(Guid id)
        {
            DrillBlockPoint? drillBlockPoint = db.DrillBlockPoints.Find(id);
            return drillBlockPoint;
        }
        public IEnumerable<DrillBlockPoint> GetDrillBlockPoints()
        {
            List<DrillBlockPoint> list = db.DrillBlockPoints.ToList();
            return list;
        }

        public bool CreateDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            if (db.DrillBlocks.Find(drillBlockPoint.DrillBlockId) == null)
                return false;
            db.DrillBlockPoints.Add(drillBlockPoint);
            db.SaveChanges();
            return true;
        }

        public bool UpdateDrillBlockPoint(DrillBlockPoint drillBlockPoint)
        {
            if (db.DrillBlocks.Find(drillBlockPoint.DrillBlockId) == null)
                return false;
            var res = db.DrillBlockPoints.SingleOrDefault(d => d.Id == drillBlockPoint.Id);
            if (res == null)
                return false;
            db.Entry(res).CurrentValues.SetValues(drillBlockPoint);
            db.SaveChanges();
            return true;
        }

        public bool DeleteDrillBlockPoint(Guid id)
        {
            DrillBlockPoint? drillBlockPoint = db.DrillBlockPoints.Find(id);
            if (drillBlockPoint == null)
                return false;
            db.Remove(drillBlockPoint);
            db.SaveChanges();
            return true;
        }
    }
}
