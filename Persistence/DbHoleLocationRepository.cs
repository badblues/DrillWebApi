using DrillWebApi.Domain;
using DrillWebApi.Persistence.Interfaces;

namespace DrillWebApi.Persistence
{
    public class DbHoleLocationRepository : IHoleLocationRepository
    {
        private ApplicationContext db;
        public DbHoleLocationRepository(ApplicationContext context)
        {
            db = context;
        }

        public HoleLocation? GetHoleLocation(Guid id)
        {
            HoleLocation? HoleLocation = db.HoleLocations.Find(id);
            return HoleLocation;
        }
        public IEnumerable<HoleLocation> GetHoleLocations()
        {
            List<HoleLocation> list = db.HoleLocations.ToList();
            return list;
        }

        public bool CreateHoleLocation(HoleLocation holeLocation)
        {
            if (db.Holes.Find(holeLocation.HoleId) == null)
                return false;
            db.HoleLocations.Add(holeLocation);
            db.SaveChanges();
            return true;
        }

        public bool UpdateHoleLocation(HoleLocation holeLocation)
        {
            if (db.Holes.Find(holeLocation.HoleId) == null)
                return false;
            var res = db.HoleLocations.SingleOrDefault(h => h.Id == holeLocation.Id);
            db.Entry(res).CurrentValues.SetValues(holeLocation);
            db.SaveChanges();
            return true;
        }

        public bool DeleteHoleLocation(Guid id)
        {
            HoleLocation? holeLocation = db.HoleLocations.Find(id);
            if (holeLocation == null)
                return false;
            db.Remove(holeLocation);
            db.SaveChanges();
            return true;
        }
    }
}
