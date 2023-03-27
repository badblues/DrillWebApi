using DrillWebApi.Domain;
using DrillWebApi.Dtos;
using DrillWebApi.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrillWebApi.Controllers
{
    [ApiController]
    [Route("drill_block_point")]
    public class DrillBlockPointController : ControllerBase
    {
        private readonly IDrillBlockPointRepository repository;
        public DrillBlockPointController(IDrillBlockPointRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<DrillBlockPoint> GetDrillBlockPoints()
        {
            var drillBlockPoints = repository.GetDrillBlockPoints();
            return drillBlockPoints;
        }

        [HttpGet("{id}")]
        public ActionResult<DrillBlockPoint> GetDrillBlockPoint(Guid id)
        {
            var drillBlockPoint = repository.GetDrillBlockPoint(id);
            if (drillBlockPoint == null)
                return NotFound();
            return drillBlockPoint;
        }

        [HttpPost]
        public ActionResult<DrillBlockPoint> CreateDrillBlockPoint(InputDrillBlockPointDto drillBlockPointDto)
        {
            DrillBlockPoint drillBlockPoint = new()
            {
                Id = Guid.NewGuid(),
                DrillBlockId = drillBlockPointDto.DrillBlockId,
                SequenceNumber = drillBlockPointDto.SequenceNumber,
                X = drillBlockPointDto.X,
                Y = drillBlockPointDto.Y,
                Z = drillBlockPointDto.Z
            };
            if (!repository.CreateDrillBlockPoint(drillBlockPoint))
                return NotFound();
            return drillBlockPoint;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDrillBlockPoint(Guid id, InputDrillBlockPointDto drillBlockPointDto)
        {
            var existingDrillBlockPoint = repository.GetDrillBlockPoint(id);
            if (existingDrillBlockPoint == null)
            {
                return NotFound();
            }
            DrillBlockPoint updatedDrillBlockPoint = existingDrillBlockPoint with
            {
                DrillBlockId = drillBlockPointDto.DrillBlockId,
                SequenceNumber = drillBlockPointDto.SequenceNumber,
                X = drillBlockPointDto.X,
                Y = drillBlockPointDto.Y,
                Z = drillBlockPointDto.Z
            };
            repository.UpdateDrillBlockPoint(updatedDrillBlockPoint);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteDrillBlockPoint(Guid id)
        {
            var existingDrillBlockPoint = repository.GetDrillBlockPoint(id);
            if (existingDrillBlockPoint is null)
            {
                return NotFound();
            }
            repository.DeleteDrillBlockPoint(id);
            return NoContent();
        }
    }
}