using DenounceBeats.Application.Contract;
using DenounceBeats.Application.Dtos.Sector;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeats.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sectorService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _sectorService.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveSectorDto dto)
        {
            var result = await _sectorService.SaveAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSectorDto dto)
        {
            var result = await _sectorService.UpdateAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sectorService.DeleteAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}
