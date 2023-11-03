using System;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto.Putnik;
using Microsoft.AspNetCore.Mvc;

namespace Beco_tours.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PutnikController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PutnikController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPutnike()
        {
            var response = await _serviceManager.PutnikService.GetAllPutnike();
            return Ok(response);
        }

        [HttpGet("{putnikID}")]
        public async Task<IActionResult> GetPutnikByID(int putnikID)
        {
            var response = await _serviceManager.PutnikService.GetPutnikByID(putnikID);
            if (response is not null)
                return Ok(response);
            return NotFound("Putnik not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePutnik(PutnikCreateDto putnikCreateDto)
        {
            var response = await _serviceManager.PutnikService.CreatePutnik(putnikCreateDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{putnikID}")]
        public async Task<IActionResult> UpdatePutnik(PutnikUpdateDto putnikUpdateDto, int putnikID)
        {
            if (!putnikID.Equals(putnikUpdateDto.PutnikID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.PutnikService.UpdatePutnik(putnikID, putnikUpdateDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{putnikID}")]
        public async Task<IActionResult> DeletePutnik(int putnikID)
        {
            var response = await _serviceManager.PutnikService.DeletePutnik(putnikID);
            if (response) return Ok("Putnik Deleted");

            return BadRequest("Failed to Delete Putnik.");
        }
    }
}

