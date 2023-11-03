using System;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto.Rezervacija;
using Microsoft.AspNetCore.Mvc;

namespace Beco_tours.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezervacijaController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public RezervacijaController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRezervacije()
        {
            var response = await _serviceManager.RezervacijaService.GetAllRezervacije();
            return Ok(response);
        }

        [HttpGet("{rezervacijaID}")]
        public async Task<IActionResult> GetRezervacijaByID(int rezervacijaID)
        {
            var response = await _serviceManager.RezervacijaService.GetRezervacijaByID(rezervacijaID);
            if (response is not null)
                return Ok(response);
            return NotFound("Rezervacija not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRezervacija(RezervacijaCreateDto rezervacijaCreateDto)
        {
            var response = await _serviceManager.RezervacijaService.CreateRezervacija(rezervacijaCreateDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{rezervacijaID}")]
        public async Task<IActionResult> UpdateRezervacija(RezervacijaUpdateDto rezervacijaUpdateDto, int rezervacijaID)
        {
            if (!rezervacijaID.Equals(rezervacijaUpdateDto.RezervacijaID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.RezervacijaService.UpdateRezervacija(rezervacijaID, rezervacijaUpdateDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{rezervacijaID}")]
        public async Task<IActionResult> DeleteRezervacija(int rezervacijaID)
        {
            var response = await _serviceManager.RezervacijaService.DeleteRezervacija(rezervacijaID);
            if (response) return Ok("Rezervacija Deleted");

            return BadRequest("Failed to Delete Rezervacija.");
        }
    }
}

