using DrillWebApi.Domain;

namespace DrillWebApi.Persistence.Interfaces
{
    public interface IDrillBlockRepository
    {
        DrillBlock? GetDrillBlock(Guid id);
        IEnumerable<DrillBlock> GetDrillBlocks();
        void CreateDrillBlock(DrillBlock block);
        void UpdateDrillBlock(DrillBlock block);
        void DeleteDrillBlock(Guid id);
    }
}
