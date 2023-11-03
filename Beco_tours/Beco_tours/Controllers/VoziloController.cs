using System;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto.Vozilo;
using Microsoft.AspNetCore.Mvc;

namespace Beco_tours.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoziloController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public VoziloController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetVozila()
        {
            var response = await _serviceManager.VoziloService.GetAllVozila();
            return Ok(response);
        }

        [HttpGet("{voziloID}")]
        public async Task<IActionResult> GetVoziloByID(int voziloID)
        {
            var response = await _serviceManager.VoziloService.GetVoziloByID(voziloID);
            if (response is not null)
                return Ok(response);
            return NotFound("Vozilo not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateVozilo(VoziloCreateDto voziloCreateDto)
        {
            var response = await _serviceManager.VoziloService.CreateVozilo(voziloCreateDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{voziloID}")]
        public async Task<IActionResult> UpdateVozilo(VoziloUpdateDto voziloUpdateDto, int voziloID)
        {
            if (!voziloID.Equals(voziloUpdateDto.VoziloID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.VoziloService.UpdateVozilo(voziloID, voziloUpdateDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{voziloID}")]
        public async Task<IActionResult> DeleteVozilo(int voziloID)
        {
            var response = await _serviceManager.VoziloService.DeleteVozilo(voziloID);
            if (response) return Ok("Vozilo Deleted");

            return BadRequest("Failed to Delete Vozilo.");
        }
    }
}

