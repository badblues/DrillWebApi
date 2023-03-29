using DrillWebApi.Domain;

namespace DrillWebApi.Persistence.Interfaces
{
    public interface IHoleRepository
    {
        Hole? GetHole(Guid id);
        IEnumerable<Hole> GetHoles();
        bool CreateHole(Hole hole);
        bool UpdateHole(Hole hole);
        void DeleteHole(Guid id);
    }
}
