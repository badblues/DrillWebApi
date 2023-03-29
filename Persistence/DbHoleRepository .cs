using DrillWebApi.Domain;
using DrillWebApi.Persistence.Interfaces;

namespace DrillWebApi.Persistence
{
    public class DbHoleRepository : IHoleRepository
    {
        private ApplicationContext db;
        public DbHoleRepository(ApplicationContext context)
        {
            db = context;
        }

        public Hole? GetHole(Guid id)
        {
            Hole? hole = db.Holes.Find(id);
            return hole;
        }
        public IEnumerable<Hole> GetHoles()
        {
            List<Hole> list = db.Holes.ToList();
            return list;
        }

        public bool CreateHole(Hole hole)
        {
            if (db.DrillBlocks.Find(hole.DrillBlockId) == null)
                return false;
            db.Holes.Add(hole);
            db.SaveChanges();
            return true;
        }

        public bool UpdateHole(Hole hole)
        {
            if (db.DrillBlocks.Find(hole.DrillBlockId) == null)
                return false;
            var res = db.Holes.SingleOrDefault(h => h.Id == hole.Id);
            if (res == null)
                return false;
            db.Entry(res).CurrentValues.SetValues(hole);
            db.SaveChanges();
            return true;
        }

        public bool DeleteHole(Guid id)
        {
            Hole? hole = db.Holes.Find(id);
            if (hole == null)
                return false;
            db.Remove(hole);
            db.SaveChanges();
            return true;
        }
    }
}
