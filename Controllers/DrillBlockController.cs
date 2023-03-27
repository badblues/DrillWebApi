using DrillWebApi.Domain;
using DrillWebApi.Dtos;
using DrillWebApi.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DrillWebApi.Controllers
{
    [ApiController]
    [Route("drill_blocks")]
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
            repository.CreateDrillBlock(block);
            return CreatedAtAction(nameof(GetDrillBlock), new { id = block.Id }, block);
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
            repository.UpdateDrillBlock(updatedBlock);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteDrillBlock(Guid id)
        {
            var existingDrillBlock= repository.GetDrillBlock(id);
            if (existingDrillBlock is null)
            {
                return NotFound();
            }
            repository.DeleteDrillBlock(id);
            return NoContent();
        }
    }
}