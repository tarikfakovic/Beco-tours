using System;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto.Lokacija;
using Microsoft.AspNetCore.Mvc;

namespace Beco_tours.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LokacijaController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public LokacijaController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetLokacije()
        {
            var response = await _serviceManager.LokacijaService.GetAllLokacije();
            return Ok(response);
        }

        [HttpGet("{lokacijaID}")]
        public async Task<IActionResult> GetLokacijaByID(int lokacijaID)
        {
            var response = await _serviceManager.LokacijaService.GetLokacijaByID(lokacijaID);
            if (response is not null)
                return Ok(response);
            return NotFound("Lokacija not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateLokacija(LokacijaCreateDto lokacijaCreateDto)
        {
            var response = await _serviceManager.LokacijaService.CreateLokacija(lokacijaCreateDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{lokacijaID}")]
        public async Task<IActionResult> UpdateLokacija(LokacijaUpdateDto lokacijaUpdateDto, int lokacijaID)
        {
            if (!lokacijaID.Equals(lokacijaUpdateDto.LokacijaID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.LokacijaService.UpdateLokacija(lokacijaID, lokacijaUpdateDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{lokacijaID}")]
        public async Task<IActionResult> DeleteLokacija(int lokacijaID)
        {
            var response = await _serviceManager.LokacijaService.DeleteLokacija(lokacijaID);
            if (response) return Ok("Lokacija Deleted");

            return BadRequest("Failed to Delete Lokacija.");
        }
    }
}

