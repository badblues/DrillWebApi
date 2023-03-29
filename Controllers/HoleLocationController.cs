using DrillWebApi.Domain;
using DrillWebApi.Dtos;
using DrillWebApi.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrillWebApi.Controllers
{
    [ApiController]
    [Route("hole_location")]
    public class HoleLocationController : ControllerBase
    {
        private readonly IHoleLocationRepository repository;
        public HoleLocationController(IHoleLocationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<HoleLocation> GetHoleLocations()
        {
            var holeLocations = repository.GetHoleLocations();
            return holeLocations;
        }

        [HttpGet("{id}")]
        public ActionResult<HoleLocation> GetHoleLocation(Guid id)
        {
            var holeLocation = repository.GetHoleLocation(id);
            if (holeLocation == null)
                return NotFound();
            return holeLocation;
        }

        [HttpPost]
        public ActionResult<HoleLocation> CreateHoleLocation(InputHoleLocationDto holeLocationDto)
        {
            HoleLocation holeLocation = new()
            {
                Id = Guid.NewGuid(),
                HoleId = holeLocationDto.HoleId,
                X = holeLocationDto.X,
                Y = holeLocationDto.Y,
                Z = holeLocationDto.Z
            };
            if (!repository.CreateHoleLocation(holeLocation))
                return NotFound();
            return holeLocation;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHoleLocation(Guid id, InputHoleLocationDto holeLocationDto)
        {
            var existingHoleLocation = repository.GetHoleLocation(id);
            if (existingHoleLocation == null)
            {
                return NotFound();
            }
            HoleLocation updatedHole = existingHoleLocation with
            {
                HoleId = holeLocationDto.HoleId,
                X = holeLocationDto.X,
                Y = holeLocationDto.Y,
                Z = holeLocationDto.Z
            };
            if (!repository.UpdateHoleLocation(updatedHole))
                return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteHoleLocation(Guid id)
        {
            var existingHoleLocation = repository.GetHoleLocation(id);
            if (existingHoleLocation is null)
            {
                return NotFound();
            }
            repository.DeleteHoleLocation(id);
            return NoContent();
        }
    }
}