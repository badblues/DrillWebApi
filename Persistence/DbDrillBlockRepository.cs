using DrillWebApi.Domain;
using DrillWebApi.Persistence.Interfaces;

namespace DrillWebApi.Persistence
{
    public class DbDrillBlockRepository : IDrillBlockRepository
    {
        private ApplicationContext db;
        public DbDrillBlockRepository(ApplicationContext context)
        {
            db = context;
        }

        public DrillBlock? GetDrillBlock(Guid id)
        {
            DrillBlock? block = db.DrillBlocks.Find(id);
            return block;
        }
        public IEnumerable<DrillBlock> GetDrillBlocks()
        {
            List<DrillBlock> list = db.DrillBlocks.ToList();
            return list;
        }

        public void CreateDrillBlock(DrillBlock block)
        {
            db.DrillBlocks.Add(block);
            db.SaveChanges();
        }

        public void UpdateDrillBlock(DrillBlock block)
        {
            var res = db.DrillBlocks.SingleOrDefault(b => b.Id == block.Id);
            db.Entry(res).CurrentValues.SetValues(block);
            db.SaveChanges();
        }

        public void DeleteDrillBlock(Guid id)
        {
            DrillBlock? block = db.DrillBlocks.Find(id);
            if (block != null)
            {
                db.Remove(block);
                db.SaveChanges();
            }
        }
    }
}
