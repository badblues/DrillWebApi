using DrillWebApi.Domain;

namespace DrillWebApi.Persistence.Interfaces
{
    public interface IDrillBlockRepository
    {
        DrillBlock? GetDrillBlock(Guid id);
        IEnumerable<DrillBlock> GetDrillBlocks();
        bool CreateDrillBlock(DrillBlock block);
        bool UpdateDrillBlock(DrillBlock block);
        bool DeleteDrillBlock(Guid id);
    }
}
