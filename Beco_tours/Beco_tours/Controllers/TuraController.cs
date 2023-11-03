using System;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto.Tura;
using Microsoft.AspNetCore.Mvc;

namespace Beco_tours.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TuraController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TuraController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTure()
        {
            var response = await _serviceManager.TuraService.GetAllTure();
            return Ok(response);
        }

        [HttpGet("{turaID}")]
        public async Task<IActionResult> GetTuraByID(int turaID)
        {
            var response = await _serviceManager.TuraService.GetTuraByID(turaID);
            if (response is not null)
                return Ok(response);
            return NotFound("Tura not found.");
        }

        [HttpGet("getAllPutnike")]     //   /{turaID}
        public async Task<IActionResult> GetPutnikByTuraID(int id)
        {
            var response = await _serviceManager.RezervacijaService.GetPutnikByTuraID(id);
            if (response is not null)
                return Ok(response);
            return NotFound("Tura not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTura(TuraCreateDto turaCreateDto)
        {
            var response = await _serviceManager.TuraService.CreateTura(turaCreateDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{turaID}")]
        public async Task<IActionResult> UpdateTura(TuraUpdateDto turaUpdateDto, int turaID)
        {
            if (!turaID.Equals(turaUpdateDto.TuraID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.TuraService.UpdateTura(turaID, turaUpdateDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{turaID}")]
        public async Task<IActionResult> DeleteTura(int turaID)
        {
            var response = await _serviceManager.TuraService.DeleteTura(turaID);
            if (response) return Ok("Tura Deleted");

            return BadRequest("Failed to Delete Tura.");
        }
    }
}

