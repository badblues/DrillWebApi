using DrillWebApi.Domain;
using DrillWebApi.Dtos;
using DrillWebApi.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrillWebApi.Controllers
{
    [ApiController]
    [Route("drill_block")]
    public class DrillBlockController : ControllerBase
    {
        private readonly IDrillBlockRepository repository;
        public DrillBlockController(IDrillBlockRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<DrillBlock> GetDrillBlocks()
        {
            var blocks = repository.GetDrillBlocks();
            return blocks;
        }

        [HttpGet("{id}")]
        public ActionResult<DrillBlock> GetDrillBlock(Guid id)
        {
            var block = repository.GetDrillBlock(id);
            if (block == null)
                return NotFound();
            return block;
        }

        [HttpPost]
        public ActionResult<DrillBlock> CreateDrillBlock(InputDrillBlockDto blockDto)
        {
            DrillBlock block = new()
            {
                Id = Guid.NewGuid(),
                Name = blockDto.Name,
                UpdateDate = blockDto.UpdateDate
            };
            if (!repository.CreateDrillBlock(block))
                return NoContent();
            return block;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDrillBlock(Guid id, InputDrillBlockDto blockDto)
        {
            var existingBlock = repository.GetDrillBlock(id);
            if (existingBlock == null)
            {
                return NotFound();
            }
            DrillBlock updatedBlock = existingBlock with
            {
                Name = blockDto.Name,
                UpdateDate = blockDto.UpdateDate
            };
            if (!repository.UpdateDrillBlock(updatedBlock))
                return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteDrillBlock(Guid id)
        {
            if (!repository.DeleteDrillBlock(id))
                return NotFound();
            return NoContent();
        }
    }
}