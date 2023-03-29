using DrillWebApi.Domain;
using DrillWebApi.Dtos;
using DrillWebApi.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrillWebApi.Controllers
{
    [ApiController]
    [Route("hole")]
    public class HoleController : ControllerBase
    {
        private readonly IHoleRepository repository;
        public HoleController(IHoleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Hole> GetHoles()
        {
            var holes = repository.GetHoles();
            return holes;
        }

        [HttpGet("{id}")]
        public ActionResult<Hole> GetHole(Guid id)
        {
            var hole = repository.GetHole(id);
            if (hole == null)
                return NotFound();
            return hole;
        }

        [HttpPost]
        public ActionResult<Hole> CreateHole(InputHoleDto holeDto)
        {
            Hole hole = new()
            {
                Id = Guid.NewGuid(),
                DrillBlockId = holeDto.DrillBlockId,
                Name = holeDto.Name,
                Depth = holeDto.Depth
            };
            if (!repository.CreateHole(hole))
                return NotFound();
            return hole;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHole(Guid id, InputHoleDto holeDto)
        {
            var existingHole = repository.GetHole(id);
            if (existingHole == null)
            {
                return NotFound();
            }
            Hole updatedHole = existingHole with
            {
                DrillBlockId = holeDto.DrillBlockId,
                Name = holeDto.Name,
                Depth = holeDto.Depth
            };
            if (!repository.UpdateHole(updatedHole))
                return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteHole(Guid id)
        {
            var existingHole = repository.GetHole(id);
            if (existingHole is null)
            {
                return NotFound();
            }
            repository.DeleteHole(id);
            return NoContent();
        }
    }
}